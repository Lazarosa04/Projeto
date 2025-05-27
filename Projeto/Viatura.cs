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
        public Viatura()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            string connectionString = "Data Source=Laptop-Lazaro;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = "SELECT * FROM Viatura";

            try
            {
                LBV_List.Items.Clear();
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
                                LBV_List.Items.Add(string.Join(" | ", campos));
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

        private void Viatura_Load(object sender, EventArgs e)
        {

        }

        private void BVReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
