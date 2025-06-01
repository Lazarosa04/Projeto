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
                                    Nascimento = reader["Data_Nascimento"].ToString(),
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
    }
}

