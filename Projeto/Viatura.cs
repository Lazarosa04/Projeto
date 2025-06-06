// Viatura.cs com stored procedures: spAdicionarViatura, spEditarViatura, spRemoverViatura
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Viatura : Form
    {
        private List<ViaturaInfo> viaturas = new List<ViaturaInfo>();

        private class ViaturaInfo
        {
            public int Id { get; set; }
            public string Tipo { get; set; }
            public string Matricula { get; set; }
            public string Ano { get; set; }
            public override string ToString() => $"({Id}) {Tipo} {Matricula}";
        }

        private Dictionary<int, string> tiposViatura = new Dictionary<int, string>();


        private class ManutencaoInfo
        {
            public int ID_Manutencao { get; set; }
            public int ID_Viatura { get; set; }
            public int ID_Equipamento { get; set; }
            public DateTime DataManutencao { get; set; }
            public string Descricao { get; set; }
        }

        private List<ManutencaoInfo> manutencoes = new List<ManutencaoInfo>();

        public Viatura()
        {
            InitializeComponent();
            BVReturn.Click += BVReturn_Click;
            LBV_List.SelectedIndexChanged += LBV_List_SelectedIndexChanged;
            BVRem.Click += BVRem_Click;
            BVAdd.Click += BVAdd_Click;
            BVEdit.Click += BVEdit_Click;
            button1.Click += button1_Click;
            CarregarDados();
            this.BVMRemove.Click += new EventHandler(BERemoveManutencao_Click);
            this.BVMAdd.Click += new EventHandler(BEAdicionarManutencao_Click);
        }

        private void CarregarDados()
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            try
            {
                LBV_List.Items.Clear();
                viaturas.Clear();
                tiposViatura.Clear();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    using (SqlCommand cmdTipos = new SqlCommand("SELECT * FROM TipoViatura", conn))
                    using (SqlDataReader rTipos = cmdTipos.ExecuteReader())
                        while (rTipos.Read())
                            tiposViatura[Convert.ToInt32(rTipos["ID_TipoViatura"])] = rTipos["Nome_TipoViatura"].ToString();

                    using (SqlCommand cmdViaturas = new SqlCommand("SELECT * FROM Viatura", conn))
                    using (SqlDataReader r = cmdViaturas.ExecuteReader())
                        while (r.Read())
                        {
                            int idTipo = Convert.ToInt32(r["ID_TipoViatura"]);
                            var v = new ViaturaInfo
                            {
                                Id = Convert.ToInt32(r["ID_Viatura"]),
                                Tipo = tiposViatura.ContainsKey(idTipo) ? tiposViatura[idTipo] : "Desconhecido",
                                Matricula = r["Matricula"].ToString(),
                                Ano = r["Ano"].ToString()
                            };
                            viaturas.Add(v);
                            LBV_List.Items.Add(v);
                        }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Erro ao carregar dados: {ex.Message}"); }
        }

        private void LBV_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBV_List.SelectedIndex >= 0)
            {
                var v = viaturas[LBV_List.SelectedIndex];
                TBV1.Text = v.Matricula;
                TBV2.Text = v.Ano;
                comboBox1.SelectedItem = v.Tipo;
                CarregarEquipamentosDaViatura(v.Id);
                CarregarManutencoesViatura(v.Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LBV_List.ClearSelected(); TBV1.Clear(); TBV2.Clear(); comboBox1.SelectedIndex = -1;
        }
        private void Viatura_Load(object sender, EventArgs e)
        {
            // Evento de carregamento do formulário Viatura
            CarregarDados();
        }
        private void BVReturn_Click(object sender, EventArgs e) => this.Close();

        private void BVAdd_Click(object sender, EventArgs e)
        {
            string matricula = TBV1.Text.Trim();
            string anoStr = TBV2.Text.Trim();
            string tipoSel = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(matricula) || string.IsNullOrWhiteSpace(anoStr) || string.IsNullOrWhiteSpace(tipoSel))
            { MessageBox.Show("Preencha todos os campos."); return; }

            if (!int.TryParse(anoStr, out int ano))
            { MessageBox.Show("Ano inválido."); return; }

            int idTipo = tiposViatura.FirstOrDefault(x => x.Value == tipoSel).Key;
            if (idTipo == 0) { MessageBox.Show("Tipo inválido."); return; }

            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spAdicionarViatura", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Quartel", 11111);
                        cmd.Parameters.AddWithValue("@ID_TipoViatura", idTipo);
                        cmd.Parameters.AddWithValue("@Matricula", matricula);
                        cmd.Parameters.AddWithValue("@Ano", ano);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Viatura adicionada com sucesso!");
                CarregarDados(); button1_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show($"Erro ao adicionar: {ex.Message}"); }
        }


        private void BVRem_Click(object sender, EventArgs e)
        {
            if (LBV_List.SelectedIndex < 0) { MessageBox.Show("Selecione uma viatura."); return; }
            var v = viaturas[LBV_List.SelectedIndex];
            var confirm = MessageBox.Show($"Remover viatura '{v.Matricula}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Teste;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("spRemoverViatura", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", v.Id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Viatura removida.");
                    CarregarDados();
                }
                catch (Exception ex) { MessageBox.Show($"Erro: {ex.Message}"); }
            }
        }

        private void BVEdit_Click(object sender, EventArgs e)
        {
            if (LBV_List.SelectedIndex < 0) { MessageBox.Show("Selecione uma viatura."); return; }
            var v = viaturas[LBV_List.SelectedIndex];

            string matricula = TBV1.Text.Trim();
            string anoStr = TBV2.Text.Trim();
            string tipoSel = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(matricula) || string.IsNullOrWhiteSpace(anoStr) || string.IsNullOrWhiteSpace(tipoSel))
            { MessageBox.Show("Preencha todos os campos."); return; }

            if (!int.TryParse(anoStr, out int ano))
            { MessageBox.Show("Ano inválido."); return; }

            int idTipo = tiposViatura.FirstOrDefault(x => x.Value == tipoSel).Key;
            if (idTipo == 0) { MessageBox.Show("Tipo inválido."); return; }

            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spEditarViatura", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", v.Id);
                        cmd.Parameters.AddWithValue("@ID_TipoViatura", idTipo);
                        cmd.Parameters.AddWithValue("@Matricula", matricula);
                        cmd.Parameters.AddWithValue("@Ano", ano);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Viatura atualizada.");
                CarregarDados();
            }
            catch (Exception ex) { MessageBox.Show($"Erro ao atualizar: {ex.Message}"); }
        }

        private void CarregarEquipamentosDaViatura(int idViatura)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"
        SELECT ID_Equipamento, Nome_Equipamento, Quantidade
        FROM Equipamento
        WHERE ID_Viatura = @idViatura";

            LBVEquip.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idViatura", idViatura);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string equipamentoInfo = $"({reader["ID_Equipamento"]}) {reader["Nome_Equipamento"]} - Quantidade: {reader["Quantidade"]}";
                                LBVEquip.Items.Add(equipamentoInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar equipamentos da viatura: {ex.Message}");
            }
        }

        private void CarregarManutencoesViatura(int idViatura)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            try
            {
                manutencoes.Clear();
                LBVManu.Items.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarManutencoesPorViatura", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Viatura", idViatura);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var manut = new ManutencaoInfo
                                {
                                    ID_Manutencao = Convert.ToInt32(reader["ID_Manutenção"]),
                                    ID_Viatura = Convert.ToInt32(reader["ID_Viatura"]),
                                    DataManutencao = Convert.ToDateTime(reader["Data_Manutenção"]),
                                    Descricao = reader["Descrição"].ToString()
                                };
                                manutencoes.Add(manut);
                                LBVManu.Items.Add($"({manut.ID_Manutencao}) {manut.DataManutencao.ToShortDateString()} - {manut.Descricao}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar manutenções: {ex.Message}");
            }
        }

        

        private void BEAdicionarManutencao_Click(object sender, EventArgs e)
        {
            int idx = LBV_List.SelectedIndex;  // índice do veículo selecionado
            if (idx >= 0 && idx < viaturas.Count)
            {
                int idViaturaSelecionada = viaturas[idx].Id; // pega o ID da viatura selecionada

                // Cria a instância do form Manutenção
                Manutenção manutForm = new Manutenção();

                // Passa o ID da viatura selecionada para o formulário de manutenção
                manutForm.ID_Viatura = idViaturaSelecionada;

                // Mostra o form como modal
                if (manutForm.ShowDialog() == DialogResult.OK)
                {
                    CarregarManutencoesViatura(idViaturaSelecionada); // Atualiza a lista de manutenções após adicionar
                }
            }
            else
            {
                MessageBox.Show("Selecione um veículo para adicionar manutenção.");
            }
        }




        private void BERemoveManutencao_Click(object sender, EventArgs e)
        {
            int idxManut = LBVManu.SelectedIndex;        // Lista de manutenções
            int idxViatura = LBV_List.SelectedIndex;  // Lista de viaturas

            if (idxManut >= 0 && idxManut < manutencoes.Count && idxViatura >= 0 && idxViatura < viaturas.Count)
            {
                var manutencaoSelecionada = manutencoes[idxManut];
                var idViaturaSelecionada = viaturas[idxViatura].Id;

                var confirm = MessageBox.Show(
                    $"Tem certeza que deseja remover a manutenção: \"{manutencaoSelecionada.Descricao}\"?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand("spRemoverManutencao", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@ID_Manutencao", manutencaoSelecionada.ID_Manutencao);
                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Manutenção removida com sucesso!");
                        CarregarManutencoesViatura(idViaturaSelecionada); // Atualiza listagem das manutenções do veículo
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover manutenção: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma manutenção para remover.");
            }
        }


    }
}