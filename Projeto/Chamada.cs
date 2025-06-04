// Chamada.cs atualizado para uso de stored procedures
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Chamada : Form
    {
        private class ChamadaInfo
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public DateTime DataHora { get; set; }
            public string Numero { get; set; }
            public string Localizacao { get; set; }
            public int Origem { get; set; }
            public string OrigemTexto => Origem == 0 ? "Direta" : "Redirecionada";
            public override string ToString() => $"({Id}) {Nome}: {DataHora} - ({OrigemTexto})";
        }

        private List<ChamadaInfo> chamadas = new List<ChamadaInfo>();

        public Chamada()
        {
            InitializeComponent();
            this.Load += Chamada_Load;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            BBAdd.Click += BBAdd_Click;
            BBRem.Click += BBRemove_Click;
            button1.Click += BBNovo_Click;
          

        }
        private void BBReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarChamadas()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            chamadas.Clear();
            listBox1.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarChamadas", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var origemBytes = reader["Origem"] as byte[];
                                int origem = (origemBytes != null && origemBytes.Length > 0 && origemBytes[0] == 1) ? 1 : 0;

                                var chamada = new ChamadaInfo
                                {
                                    Id = Convert.ToInt32(reader["ID_Chamada"]),
                                    Nome = reader["Nome"].ToString(),
                                    Descricao = reader["Descrição"].ToString(),
                                    DataHora = Convert.ToDateTime(reader["Data_Hora_Chamada"]),
                                    Numero = reader["Número"].ToString(),
                                    Localizacao = reader["Localização"].ToString(),
                                    Origem = origem
                                };
                                chamadas.Add(chamada);
                                listBox1.Items.Add(chamada);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar chamadas: {ex.Message}");
            }
        }

        private void BBAdd_Click(object sender, EventArgs e)
        {
            string nome = textBox5.Text.Trim();
            string descricao = richTextBox1.Text.Trim();
            string dataHoraStr = textBox2.Text.Trim();
            string numero = textBox3.Text.Trim();
            string localizacao = textBox1.Text.Trim();
            string origemTexto = TBV1.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(descricao) ||
                string.IsNullOrWhiteSpace(dataHoraStr) || string.IsNullOrWhiteSpace(numero) ||
                string.IsNullOrWhiteSpace(localizacao) || string.IsNullOrWhiteSpace(origemTexto))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            if (!DateTime.TryParse(dataHoraStr, out DateTime dataHora))
            {
                MessageBox.Show("Data/Hora inválida.");
                return;
            }

            int origem = origemTexto.Equals("Redirecionada", StringComparison.OrdinalIgnoreCase) ? 1 : 0;
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spAdicionarChamada", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Descricao", descricao);
                        command.Parameters.AddWithValue("@DataHora", dataHora);
                        command.Parameters.AddWithValue("@Numero", numero);
                        command.Parameters.AddWithValue("@Localizacao", localizacao);
                        command.Parameters.AddWithValue("@Origem", origem);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Chamada adicionada com sucesso!");
                CarregarChamadas();
                BBNovo_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar chamada: {ex.Message}");
            }
        }

        private void BBRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is ChamadaInfo chamadaSelecionada)
            {
                var confirm = MessageBox.Show($"Tem certeza que deseja remover a chamada '{chamadaSelecionada.Nome}'?", "Confirmação", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand("spRemoverChamada", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@Id", chamadaSelecionada.Id);
                                command.ExecuteNonQuery();
                            }
                            BBNovo_Click(null, null);
                        }
                        MessageBox.Show("Chamada removida com sucesso!");
                        CarregarChamadas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover chamada: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma chamada para remover.");
            }
        }

        private void BBNovo_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            textBox5.Clear();
            richTextBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Clear();
            TBV1.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is ChamadaInfo chamada)
            {
                textBox1.Text = chamada.Localizacao;
                textBox2.Text = chamada.DataHora.ToString("g");
                textBox3.Text = chamada.Numero;
                textBox5.Text = chamada.Nome;
                TBV1.Text = chamada.OrigemTexto;
                richTextBox1.Text = chamada.Descricao;
            }
        }

        private void Chamada_Load(object sender, EventArgs e)
        {
            CarregarChamadas();
        }

        private void Chamada_Load_1(object sender, EventArgs e)
        {

        }
    }
}
