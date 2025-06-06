using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Férias : Form
    {
        private int idBombeiro;

        public Férias(int idBombeiro)
        {
            InitializeComponent();
            this.idBombeiro = idBombeiro;
            this.BFeriasAdd.Click += BFeriasAdd_Click;
        }

        private void Férias_Load(object sender, EventArgs e)
        {
            // Inicializações, se necessário
        }

        private void BFeriasVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BFeriasAdd_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = dateTimePickerInicio.Value.Date;
            DateTime dataFim = dateTimePickerFim.Value.Date;

            if (dataFim < dataInicio)
            {
                MessageBox.Show("A data de fim não pode ser anterior à data de início.");
                return;
            }

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("AdicionarFerias", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Bombeiro", idBombeiro);
                        command.Parameters.AddWithValue("@Data_Inicio", dataInicio);
                        command.Parameters.AddWithValue("@Data_Fim", dataFim);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Férias adicionadas com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar férias: {ex.Message}");
            }
        }
    }
}
