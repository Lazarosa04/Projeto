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
            CarregarDados();
        }

        private void CarregarDados()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = "SELECT * FROM Viatura";

            try
            {
                LBV_List.Items.Clear();
                viaturas.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var info = new ViaturaInfo
                                {
                                    Id = Convert.ToInt32(reader["ID_Viatura"]),
                                    Tipo = reader["ID_TipoViatura"].ToString(),
                                    Matricula = reader["Matricula"].ToString(),
                                    Ano = reader["Ano"].ToString()
                                    // Adicione outros campos conforme necessário
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
                // Exiba outros campos conforme necessário
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
