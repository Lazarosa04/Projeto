using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Bombeiro : Form
    {
        private List<BombeiroInfo> bombeiros = new List<BombeiroInfo>();

        private class BombeiroInfo
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Nascimento { get; set; }
            public string Morada { get; set; }
            public string Email { get; set; }
            public string NIF { get; set; }
            public string Telemovel { get; set; }

            public override string ToString() => $"{Nome} ({Id})";
        }

        public Bombeiro()
        {
            InitializeComponent();
            CarregarDados();
            this.BBReturn.Click += BBReturn_Click;
            this.listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            this.BBRem.Click += BBRem_Click;
            this.button1.Click += button1_Click;
            this.BBAdd.Click += BBAdd_Click;
            this.BBEdit.Click += BBEdit_Click;
        }

        private void CarregarDados()
        {
            string connectionString = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";
            try
            {
                listBox1.Items.Clear();
                bombeiros.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarBombeiros", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var info = new BombeiroInfo
                                {
                                    Id = Convert.ToInt32(reader["ID_Bombeiro"]),
                                    Nome = reader["Nome_Bombeiro"].ToString(),
                                    Nascimento = Convert.ToDateTime(reader["Data_Nascimento"]).ToString("dd/MM/yyyy"),
                                    Morada = reader["Morada"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    NIF = reader["NIF"].ToString(),
                                    Telemovel = reader["Telemóvel"].ToString()
                                };
                                bombeiros.Add(info);
                                listBox1.Items.Add(info);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var selecionado = bombeiros[listBox1.SelectedIndex];
                TBV1.Text = selecionado.Nome;
                textBox1.Text = selecionado.Morada;
                textBox2.Text = selecionado.Email;
                textBox3.Text = selecionado.NIF;
                textBox4.Text = selecionado.Telemovel;
                textBox5.Text = selecionado.Nascimento;
            }
        }

        private void BBReturn_Click(object sender, EventArgs e) => this.Close();

        private void Bombeiro_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            TBV1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void BBAdd_Click(object sender, EventArgs e)
        {
            string nome = TBV1.Text.Trim();
            string morada = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string nif = textBox3.Text.Trim();
            string telemovel = textBox4.Text.Trim();
            string nascimento = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(nascimento))
            {
                MessageBox.Show("Preencha pelo menos o nome e a data de nascimento.");
                return;
            }

            if (!DateTime.TryParse(nascimento, out DateTime dataNascimento))
            {
                MessageBox.Show("Data de nascimento inválida.");
                return;
            }

            string connectionString = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spAdicionarBombeiro", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                        command.Parameters.AddWithValue("@Morada", morada);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@NIF", nif);
                        command.Parameters.AddWithValue("@Telemovel", telemovel);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Bombeiro adicionado com sucesso!");
                CarregarDados();
                TBV1.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar bombeiro: {ex.Message}");
            }
        }

        private void BBRem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um bombeiro para remover.");
                return;
            }

            var selecionado = bombeiros[listBox1.SelectedIndex];
            var confirm = MessageBox.Show($"Tem certeza que deseja remover '{selecionado.Nome}'?", "Confirmar Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string connectionString = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("spRemoverBombeiro", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@Id", selecionado.Id);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Bombeiro removido com sucesso.");
                    CarregarDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover bombeiro: {ex.Message}");
                }
            }
        }

        private void BBEdit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um bombeiro para editar.");
                return;
            }

            var selecionado = bombeiros[listBox1.SelectedIndex];
            string nome = TBV1.Text.Trim();
            string morada = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string nif = textBox3.Text.Trim();
            string telemovel = textBox4.Text.Trim();
            string nascimento = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(nascimento))
            {
                MessageBox.Show("Preencha pelo menos o nome e a data de nascimento.");
                return;
            }

            if (!DateTime.TryParse(nascimento, out DateTime dataNascimento))
            {
                MessageBox.Show("Data de nascimento inválida.");
                return;
            }

            string connectionString = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spAtualizarBombeiro", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", selecionado.Id);
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                        command.Parameters.AddWithValue("@Morada", morada);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@NIF", nif);
                        command.Parameters.AddWithValue("@Telemovel", telemovel);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Bombeiro atualizado com sucesso!");
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar bombeiro: {ex.Message}");
            }
        }
    }
}
