using System;
using System.Collections.Generic;
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
        }

        private void CarregarDados()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = "SELECT * FROM Equipamento";

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

        private void BEReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Equipamento_Load(object sender, EventArgs e)
        {

        }
    }
}