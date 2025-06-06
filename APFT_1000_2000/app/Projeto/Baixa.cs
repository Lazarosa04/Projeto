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
    public partial class Baixa : Form
    {
        private int idBombeiro;

        public Baixa(int idBombeiro)
        {
            InitializeComponent();
            this.idBombeiro = idBombeiro;
            this.BBaixaAdd.Click += BBaixaAdd_Click;
        }


        private void BBaixaVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Baixa_Load(object sender, EventArgs e)
        {

        }

        private void BBaixaAdd_Click(object sender, EventArgs e)
        {
            string motivo = RBBaixaRazao.Text.Trim();
            DateTime dataInicio = dateTimePickerInicio.Value.Date;
            DateTime dataFim = dateTimePickerFim.Value.Date;

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Por favor, preencha a razão da baixa.");
                return;
            }

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
                    using (SqlCommand command = new SqlCommand("spAdicionarBaixa", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Bombeiro", idBombeiro);
                        command.Parameters.AddWithValue("@Razao", motivo);
                        command.Parameters.AddWithValue("@Data_Inicio", dataInicio);
                        command.Parameters.AddWithValue("@Data_Fim", dataFim);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Baixa adicionada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar baixa: {ex.Message}");
            }
        }

    }
}
