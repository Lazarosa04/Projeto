// Equipamento.cs atualizado para uso de stored procedures
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Equipamento : Form
    {
        public Equipamento()
        {
            InitializeComponent();
            CarregarDados();
            this.BEReturn.Click += new EventHandler(BEReturn_Click);
            this.listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            this.BEAdd.Click += new EventHandler(BEAdd_Click);
            this.BERem.Click += new EventHandler(BERemove_Click);
            this.button1.Click += new EventHandler(BENovo_Click);
            this.BEEdit.Click += new EventHandler(BEEditar_Click);
            this.BVMRemove.Click += new EventHandler(BERemoveManutencao_Click);
            this.BVMAdd.Click += new EventHandler(BEAdicionarManutencao_Click);
        }

        private class EquipamentoInfo
        {
            public int ID_Equipamento { get; set; }
            public string Nome_Equipamento { get; set; }
            public int Quantidade { get; set; }
            public string Nome_Viatura { get; set; }
            public int ID_Viatura { get; set; }
        }

        private class ManutencaoInfo
        {
            public int ID_Manutencao { get; set; }
            public int ID_Viatura { get; set; }
            public int ID_Equipamento { get; set; }
            public DateTime DataManutencao { get; set; }
            public string Descricao { get; set; }
        }

        private List<ManutencaoInfo> manutencoes = new List<ManutencaoInfo>();


        private void Equipamento_Load(object sender, EventArgs e)
        {
            // Evento de carregamento do formulário Equipamento
            CarregarDados();
        }

        private List<EquipamentoInfo> equipamentos = new List<EquipamentoInfo>();

        private void CarregarDados()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            try
            {
                listBox1.Items.Clear();
                equipamentos.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarEquipamentos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var info = new EquipamentoInfo
                                {
                                    ID_Equipamento = Convert.ToInt32(reader["ID_Equipamento"]),
                                    Nome_Equipamento = reader["Nome_Equipamento"].ToString(),
                                    Quantidade = Convert.ToInt32(reader["Quantidade"]),
                                    Nome_Viatura = reader["Matricula"] == DBNull.Value ? "Sem viatura" : reader["Matricula"].ToString(),
                                    ID_Viatura = reader["ID_Viatura"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ID_Viatura"])
                                };
                                equipamentos.Add(info);
                                listBox1.Items.Add($"({info.ID_Equipamento}) {info.Nome_Equipamento} - {info.Quantidade}" +(info.ID_Viatura > 0 ? $" | Viatura: {info.Nome_Viatura}" : "")
);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }


        private void LimparCampos()
        {
            listBox1.ClearSelected();
            TEV1.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void BENovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void AdicionarEquipamento(string nome, int quantidade, int? idViatura)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command;

                    if (idViatura.HasValue && idViatura.Value > 0)
                    {
                        // Se o ID da viatura for válido, associa o equipamento à viatura
                        command = new SqlCommand("spAdicionarEquipamentoViatura", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Quantidade", quantidade);
                        command.Parameters.AddWithValue("@ID_Viatura", idViatura.Value);
                    }
                    else
                    {
                        // Caso contrário, adiciona equipamento geral (não associado a viatura)
                        command = new SqlCommand("spAdicionarEquipamento", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Quantidade", quantidade);
                    }

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Equipamento adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar equipamento: {ex.Message}");
            }
        }


        private void BEAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = TEV1.Text;
                int quantidade = int.Parse(textBox1.Text);

                // Tenta converter o ID da viatura. Se estiver vazio ou inválido, usa null
                int? idViatura = null;
                if (int.TryParse(textBox2.Text, out int id))
                {
                    idViatura = id;
                }

                AdicionarEquipamento(nome, quantidade, idViatura);
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar equipamento: {ex.Message}");
            }
        }


        private void BERemove_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx >= 0 && idx < equipamentos.Count)
            {
                var equipamentoSelecionado = equipamentos[idx];
                var confirm = MessageBox.Show(
                    $"Tem certeza que deseja remover o equipamento \"{equipamentoSelecionado.Nome_Equipamento}\"?",
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
                            using (SqlCommand command = new SqlCommand("spRemoverEquipamento", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@ID", equipamentoSelecionado.ID_Equipamento);
                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Equipamento removido com sucesso!");
                        CarregarDados();
                        LimparCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover equipamento: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um equipamento para remover.");
            }
        }

        private void EditarEquipamento(int idEquipamento, string nome, int quantidade, int? idViatura)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spEditarEquipamento", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Equipamento", idEquipamento);
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Quantidade", quantidade);

                        if (idViatura.HasValue && idViatura.Value > 0)
                            command.Parameters.AddWithValue("@ID_Viatura", idViatura.Value);
                        else
                            command.Parameters.AddWithValue("@ID_Viatura", DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Equipamento editado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar equipamento: {ex.Message}");
            }
        }


        private void BEReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BEEditar_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx >= 0 && idx < equipamentos.Count)
            {
                var eq = equipamentos[idx];

                string nome = TEV1.Text;
                int quantidade = int.Parse(textBox1.Text);

                int? idViatura = null;
                if (int.TryParse(textBox2.Text, out int id))
                    idViatura = id;

                EditarEquipamento(eq.ID_Equipamento, nome, quantidade, idViatura);
                CarregarDados();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Selecione um equipamento para editar.");
            }
        }
        private void CarregarManutencoesEquipamento(int idEquipamento)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            try
            {
                manutencoes.Clear();
                LBVManu.Items.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarManutencoesPorEquipamento", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Equipamento", idEquipamento);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var manut = new ManutencaoInfo
                                {
                                    ID_Manutencao = Convert.ToInt32(reader["ID_Manutenção"]),
                                    ID_Equipamento = Convert.ToInt32(reader["ID_Equipamento"]),
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
            int idx = listBox1.SelectedIndex;
            if (idx >= 0 && idx < equipamentos.Count)
            {
                int idEquipamentoSelecionado = equipamentos[idx].ID_Equipamento;

                // Cria a instância do form Manutenção
                Manutenção manutForm = new Manutenção();

                // Passa o ID do equipamento selecionado
                manutForm.ID_Equipamento = idEquipamentoSelecionado;

                // Mostra o form como modal
                if (manutForm.ShowDialog() == DialogResult.OK)
                {
                    CarregarManutencoesEquipamento(idEquipamentoSelecionado); // Atualiza a lista de manutenções após adicionar
                }
            }
            else
            {
                MessageBox.Show("Selecione um equipamento para adicionar manutenção.");
            }
        }



        private void BERemoveManutencao_Click(object sender, EventArgs e)
        {
            int idxManut = LBVManu.SelectedIndex;
            int idxEquip = listBox1.SelectedIndex;

            if (idxManut >= 0 && idxManut < manutencoes.Count && idxEquip >= 0 && idxEquip < equipamentos.Count)
            {
                var manutencaoSelecionada = manutencoes[idxManut];
                var idEquipSelecionado = equipamentos[idxEquip].ID_Equipamento;

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
                        CarregarManutencoesEquipamento(idEquipSelecionado); // Atualiza listagem das manutenções do equipamento
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






        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx >= 0 && idx < equipamentos.Count)
            {
                var eq = equipamentos[idx];
                TEV1.Text = eq.Nome_Equipamento;
                textBox1.Text = eq.Quantidade.ToString();
                textBox2.Text = eq.ID_Viatura.ToString();
                CarregarManutencoesEquipamento(eq.ID_Equipamento); // Carrega as manutenções relacionadas ao equipamento selecionado
            }
        }
    }
}
