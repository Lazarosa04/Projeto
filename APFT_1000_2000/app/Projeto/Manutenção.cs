using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Manutenção : Form
    {

        public int ID_Equipamento { get; set; }
        public int ID_Viatura { get; set; } 

        public Manutenção()
        {
            InitializeComponent();

            // Ligação dos eventos
            BEAdicionar.Click += BEAdicionar_Click;
            BECancelar.Click += BECancelar_Click;
        }

        private void BEAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBDescricao.Text))
            {
                MessageBox.Show("Por favor, insira uma descrição para a manutenção.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime data = DTPDataManutencao.Value;
            string descricao = TBDescricao.Text;

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spAdicionarManutencao", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Se ID_Viatura estiver definido (> 0), usa esse, senão usa ID_Equipamento
                        if (ID_Viatura >= 0)
                        {
                            command.Parameters.AddWithValue("@ID_Viatura", ID_Viatura);
                            command.Parameters.AddWithValue("@ID_Equipamento", DBNull.Value);
                        }
                        else if (ID_Equipamento >= 0)
                        {
                            command.Parameters.AddWithValue("@ID_Equipamento", ID_Equipamento);
                            command.Parameters.AddWithValue("@ID_Viatura", DBNull.Value);
                        }
                        else
                        {
                            MessageBox.Show("Nenhum equipamento ou viatura selecionado para a manutenção.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        command.Parameters.AddWithValue("@Data_Manutencao", data);
                        command.Parameters.AddWithValue("@Descricao", descricao);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Manutenção adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar manutenção: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BECancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
