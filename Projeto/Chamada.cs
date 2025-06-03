using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            public string OrigemTexto => Origem == 0 ? "Direta" : "Redirecionada";

            public int Origem { get; set; }

            public override string ToString()
            {
                return $"({Id}) {Nome}: {DataHora} - ({OrigemTexto})";
            }
        }

        private List<ChamadaInfo> chamadas = new List<ChamadaInfo>();



        public Chamada()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Chamada_Load);
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            this.BBAdd.Click += new EventHandler(BBAdd_Click);
            this.BBRem.Click += new EventHandler(BBRemove_Click);
            this.button1.Click += new EventHandler(BBNovo_Click);
        }


        private void CarregarChamadas()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = "SELECT * FROM Chamada";

            chamadas.Clear();
            listBox1.Items.Clear(); // ou outro controlo

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar chamadas: {ex.Message}");
            }
        }

        private void LimparCampos()
        {
            listBox1.ClearSelected();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            TBV1.Clear();
            richTextBox1.Clear();
        }

        private void BBNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
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
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                TBV1.Text = "";
                richTextBox1.Text = "";
            }
        }


        private void Chamada_Load(object sender, EventArgs e)
        {
            CarregarChamadas();
        }





        private void BBReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BBRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is ChamadaInfo chamadaSelecionada)
            {
                var confirm = MessageBox.Show(
                    $"Tem certeza que deseja remover a chamada \"{chamadaSelecionada.Nome}\"?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
                    string query = "DELETE FROM Chamada WHERE ID_Chamada = @id";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@id", chamadaSelecionada.Id);
                                command.ExecuteNonQuery();
                            }
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


        private void BBAdd_Click(object sender, EventArgs e)
        {
            // Captura os valores dos campos
            string nome = textBox5.Text.Trim();
            string descricao = richTextBox1.Text.Trim();
            string dataHoraStr = textBox2.Text.Trim();
            string numero = textBox3.Text.Trim();
            string localizacao = textBox1.Text.Trim();
            string origemTexto = TBV1.Text.Trim();

            // Validação simples
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(descricao) ||
                string.IsNullOrWhiteSpace(dataHoraStr) || string.IsNullOrWhiteSpace(numero) ||
                string.IsNullOrWhiteSpace(localizacao) || string.IsNullOrWhiteSpace(origemTexto))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            DateTime dataHora;
            if (!DateTime.TryParse(dataHoraStr, out dataHora))
            {
                MessageBox.Show("Data/Hora inválida.");
                return;
            }

            // Determina o valor de origem (0 = Direta, 1 = Redirecionada)
            int origem = origemTexto.Equals("Redirecionada", StringComparison.OrdinalIgnoreCase) ? 1 : 0;

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"INSERT INTO Chamada (Nome, [Descrição], Data_Hora_Chamada, [Número], [Localização], Origem)
                     VALUES (@nome, @descricao, @dataHora, @numero, @localizacao, @origem)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nome", nome);
                        command.Parameters.AddWithValue("@descricao", descricao);
                        command.Parameters.AddWithValue("@dataHora", dataHora);
                        command.Parameters.AddWithValue("@numero", numero);
                        command.Parameters.AddWithValue("@localizacao", localizacao);
                        command.Parameters.AddWithValue("@origem", origem);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Chamada adicionada com sucesso!");
                CarregarChamadas(); // Atualiza a lista
                                    // Limpa os campos após adicionar
                textBox5.Clear();
                richTextBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Clear();
                TBV1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar chamada: {ex.Message}");
            }
        }
    }
}
