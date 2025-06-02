using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Projeto
{
    public partial class Viatura : Form
    {
        // 1. Lista para armazenar as viaturas
        private List<ViaturaInfo> viaturas = new List<ViaturaInfo>();

        // 2. Classe para os dados da viatura
        private class ViaturaInfo
        {
            public int Id { get; set; }
            public string Tipo { get; set; }
            public string Matricula { get; set; }
            public string Ano { get; set; }
            // Adicione outros campos conforme sua tabela

            public override string ToString() => $"{Tipo} {Matricula}";
        }

        public Viatura()
        {
            InitializeComponent();
            this.BVReturn.Click += new EventHandler(BVReturn_Click);
            this.LBV_List.SelectedIndexChanged += LBV_List_SelectedIndexChanged; // Associa o evento
            this.BVRem.Click += new EventHandler(BVRem_Click);
            this.BVAdd.Click += new EventHandler(BVAdd_Click);
            this.BVEdit.Click += new EventHandler(BVEdit_Click);
            this.button1.Click += new EventHandler(button1_Click);
            CarregarDados();
        }

        private Dictionary<int, string> tiposViatura = new Dictionary<int, string>();

        private void CarregarDados()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string queryViaturas = "SELECT * FROM Viatura";
            string queryTipos = "SELECT * FROM TipoViatura";

            try
            {
                LBV_List.Items.Clear();
                viaturas.Clear();
                tiposViatura.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 1. Carregar tipos de viatura
                    using (SqlCommand cmdTipos = new SqlCommand(queryTipos, connection))
                    {
                        using (SqlDataReader readerTipos = cmdTipos.ExecuteReader())
                        {
                            while (readerTipos.Read())
                            {
                                int idTipo = Convert.ToInt32(readerTipos["ID_TipoViatura"]);
                                string nomeTipo = readerTipos["Nome_TipoViatura"].ToString();
                                tiposViatura[idTipo] = nomeTipo;
                            }
                        }
                    }

                    // 2. Carregar viaturas
                    using (SqlCommand cmdViaturas = new SqlCommand(queryViaturas, connection))
                    {
                        using (SqlDataReader reader = cmdViaturas.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idTipo = Convert.ToInt32(reader["ID_TipoViatura"]);
                                var info = new ViaturaInfo
                                {
                                    Id = Convert.ToInt32(reader["ID_Viatura"]),
                                    Tipo = tiposViatura.ContainsKey(idTipo) ? tiposViatura[idTipo] : "Desconhecido",
                                    Matricula = reader["Matricula"].ToString(),
                                    Ano = reader["Ano"].ToString()
                                };
                                viaturas.Add(info);
                                LBV_List.Items.Add(info);
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

        // 3. Evento para exibir os dados ao selecionar uma viatura
        private void LBV_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBV_List.SelectedIndex >= 0)
            {
                var selecionada = viaturas[LBV_List.SelectedIndex];
        
                TBV1.Text = selecionada.Matricula;
                TBV2.Text = selecionada.Ano;
                comboBox1.SelectedItem = selecionada.Tipo;
                
            }
        }

        private void Viatura_Load(object sender, EventArgs e)
        {

        }

        private void BVReturn_Click(object sender, EventArgs e)
        {
 
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LBV_List.SelectedIndex = -1;
            TBV1.Clear();
            TBV2.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void BVAdd_Click(object sender, EventArgs e)
        {
            // Captura os valores dos campos
            string matricula = TBV1.Text.Trim();
            string anoStr = TBV2.Text.Trim();
            string tipoSelecionado = comboBox1.SelectedItem?.ToString();

            // Validação simples
            if (string.IsNullOrWhiteSpace(matricula) || string.IsNullOrWhiteSpace(anoStr) || string.IsNullOrWhiteSpace(tipoSelecionado))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            int ano;
            if (!int.TryParse(anoStr, out ano))
            {
                MessageBox.Show("Ano inválido.");
                return;
            }

            // Encontrar o ID do tipo selecionado
            int idTipo = tiposViatura.FirstOrDefault(x => x.Value == tipoSelecionado).Key;
            if (idTipo == 0)
            {
                MessageBox.Show("Tipo de viatura inválido.");
                return;
            }

            
            int idQuartel = 11111;

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"INSERT INTO Viatura (ID_Quartel, ID_TipoViatura, Matricula, Ano)
                     VALUES (@idQuartel, @idTipo, @matricula, @ano)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idQuartel", idQuartel);
                        command.Parameters.AddWithValue("@idTipo", idTipo);
                        command.Parameters.AddWithValue("@matricula", matricula);
                        command.Parameters.AddWithValue("@ano", ano);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Viatura adicionada com sucesso!");
                CarregarDados(); // Atualiza a lista
                                 // Limpa os campos após adicionar
                TBV1.Clear();
                TBV2.Clear();
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar viatura: {ex.Message}");
            }
        }

        private void BVRem_Click(object sender, EventArgs e)
        {
            if (LBV_List.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma viatura para remover.");
                return;
            }

            var selecionada = viaturas[LBV_List.SelectedIndex];
            var confirm = MessageBox.Show(
                $"Tem certeza que deseja remover a viatura '{selecionada.Matricula}'?",
                "Confirmar Remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // 1. Remover ocorrências associadas à viatura
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Viatura_Ocorrência WHERE ID_Viatura = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", selecionada.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Remover manutenções associadas à viatura
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Manutenção WHERE ID_Viatura = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", selecionada.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Desassociar equipamentos da viatura (não apagar o equipamento)
                        using (SqlCommand cmd = new SqlCommand("UPDATE Equipamento SET ID_Viatura = NULL WHERE ID_Viatura = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", selecionada.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Remover a viatura
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Viatura WHERE ID_Viatura = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", selecionada.Id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Viatura removida com sucesso.");
                    CarregarDados(); // Atualiza a lista
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover viatura: {ex.Message}");
                }
            }
        }
        private void BVEdit_Click(object sender, EventArgs e)
        {
            if (LBV_List.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma viatura para editar.");
                return;
            }

            var selecionada = viaturas[LBV_List.SelectedIndex];

            // Captura os valores dos campos
            string matricula = TBV1.Text.Trim();
            string anoStr = TBV2.Text.Trim();
            string tipoSelecionado = comboBox1.SelectedItem?.ToString();

            // Validação simples
            if (string.IsNullOrWhiteSpace(matricula) || string.IsNullOrWhiteSpace(anoStr) || string.IsNullOrWhiteSpace(tipoSelecionado))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            int ano;
            if (!int.TryParse(anoStr, out ano))
            {
                MessageBox.Show("Ano inválido.");
                return;
            }

            // Encontrar o ID do tipo selecionado
            int idTipo = tiposViatura.FirstOrDefault(x => x.Value == tipoSelecionado).Key;
            if (idTipo == 0)
            {
                MessageBox.Show("Tipo de viatura inválido.");
                return;
            }

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"UPDATE Viatura SET 
                        ID_TipoViatura = @idTipo, 
                        Matricula = @matricula, 
                        Ano = @ano
                    WHERE ID_Viatura = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idTipo", idTipo);
                        command.Parameters.AddWithValue("@matricula", matricula);
                        command.Parameters.AddWithValue("@ano", ano);
                        command.Parameters.AddWithValue("@id", selecionada.Id);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Viatura atualizada com sucesso!");
                CarregarDados(); // Atualiza a lista
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar viatura: {ex.Message}");
            }
        }
    }
}
