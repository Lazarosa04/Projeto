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
    public partial class Bombeiro : Form
    {
        // Adicione este campo à sua classe para armazenar os bombeiros
        private List<BombeiroInfo> bombeiros = new List<BombeiroInfo>();

        // Classe para armazenar os dados do bombeiro
        private class BombeiroInfo
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Nascimento { get; set; }
            public string Morada    { get; set; }
            public string Email { get; set; }
            public string NIF { get; set; }
            public string Telemovel { get; set; }


            public override string ToString() => $"{Nome} ({Id})";
        }

        public Bombeiro()
        {
            InitializeComponent();
            CarregarDados();
            this.BBReturn.Click += new EventHandler(BBReturn_Click);
            this.listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged; // Associa o evento
            this.BBRem.Click += new EventHandler(BBRem_Click); // Associa o evento do botão remover
            this.button1.Click += new EventHandler(button1_Click);
            this.BBAdd.Click += new EventHandler(BBAdd_Click);
        }

        private void CarregarDados()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = "SELECT * FROM Bombeiro";

            try
            {
                listBox1.Items.Clear();
                bombeiros.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        // Evento para exibir os dados ao selecionar um bombeiro
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
                // Exiba outros dados em outros controles, se necessário
            }
        }

        private void BBReturn_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulário ao clicar em "Voltar"
        }

        private void Bombeiro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            // Opcional: Limpar os campos de texto
            TBV1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }


        private void BBAdd_Click(object sender, EventArgs e)
        {
            // Captura os valores dos campos
            string nome = TBV1.Text.Trim();
            string morada = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string nif = textBox3.Text.Trim();
            string telemovel = textBox4.Text.Trim();
            string nascimento = textBox5.Text.Trim();

            // Validação simples (pode ser expandida)
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(nascimento))
            {
                MessageBox.Show("Preencha pelo menos o nome e a data de nascimento.");
                return;
            }

            DateTime dataNascimento;
            if (!DateTime.TryParse(nascimento, out dataNascimento))
            {
                MessageBox.Show("Data de nascimento inválida.");
                return;
            }

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"INSERT INTO Bombeiro 
        (Nome_Bombeiro, Data_Nascimento, Morada, Email, NIF, Telemóvel)
        VALUES (@nome, @nascimento, @morada, @email, @nif, @telemovel)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nome", nome);
                        command.Parameters.AddWithValue("@nascimento", dataNascimento);
                        command.Parameters.AddWithValue("@morada", morada);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@nif", nif);
                        command.Parameters.AddWithValue("@telemovel", telemovel);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Bombeiro adicionado com sucesso!");
                CarregarDados(); // Atualiza a lista
                                 // Limpa os campos após adicionar
                TBV1.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
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
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // 1. Remover as ligações com Formação
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Bombeiro_Formação WHERE ID_Bombeiro = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", selecionado.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Remover as ligações com Ocorrência
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Bombeiro_Ocorrência WHERE ID_Bombeiro = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", selecionado.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Remover as ligações com Especialização
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Bombeiro_Especialização WHERE ID_Bombeiro = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", selecionado.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Remover Baixas
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Baixa WHERE ID_Bombeiro = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", selecionado.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 5. Remover Férias
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Férias WHERE ID_Bombeiro = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", selecionado.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 6. Por fim, remover o bombeiro
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Bombeiro WHERE ID_Bombeiro = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", selecionado.Id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Bombeiro removido com sucesso.");
                    CarregarDados(); // Atualiza a lista
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover bombeiro: {ex.Message}");
                }
            }
        }
    }
}

