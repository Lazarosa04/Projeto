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
        public Bombeiro()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = "SELECT * FROM Bombeiro";

            try
            {
                listBox1.Items.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Monta uma string com todos os campos da linha
                                var campos = new List<string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string nomeCampo = reader.GetName(i);
                                    string valorCampo = reader[i]?.ToString() ?? "";
                                    campos.Add($"{nomeCampo}: {valorCampo}");
                                }
                                listBox1.Items.Add(string.Join(" | ", campos));
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

        private void Bombeiro_Load(object sender, EventArgs e)
        {

        }
    }
}

