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
    }
}
