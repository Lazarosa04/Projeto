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
    }
}
