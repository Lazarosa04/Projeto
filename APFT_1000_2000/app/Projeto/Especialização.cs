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
    public partial class Especialização : Form
    {

        public int ID_Bombeiro { get; set; }

        public Especialização()
        {
            InitializeComponent();
            this.BAddEsp.Click += BAddEsp_Click;
            this.BReturnEsp.Click += BReturnEsp_Click;
        }

        private void BReturnEsp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Especialização_Load(object sender, EventArgs e)
        {

        }

        private void BAddEsp_Click(object sender, EventArgs e)
        {
            string nomeEspecializacao = CBEsp.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomeEspecializacao))
            {
                MessageBox.Show("Por favor, introduza o nome da especialização.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idEspecializacao = -1;
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verifica se a especialização já existe
                    using (SqlCommand checkCmd = new SqlCommand("SELECT ID_Especialização FROM Especialização WHERE Nome_Especialização = @Nome", connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Nome", nomeEspecializacao);
                        object result = checkCmd.ExecuteScalar();

                        if (result != null)
                        {
                            idEspecializacao = Convert.ToInt32(result); // Já existe
                        }
                        else
                        {
                            // Insere nova especialização
                            using (SqlCommand insertCmd = new SqlCommand("INSERT INTO Especialização (Nome_Especialização) OUTPUT INSERTED.ID_Especialização VALUES (@Nome)", connection))
                            {
                                insertCmd.Parameters.AddWithValue("@Nome", nomeEspecializacao);
                                idEspecializacao = (int)insertCmd.ExecuteScalar();
                            }
                        }
                    }

                    // Associa ao bombeiro
                    using (SqlCommand assocCmd = new SqlCommand("INSERT INTO Bombeiro_Especialização (ID_Bombeiro, ID_Especialização) VALUES (@ID_Bombeiro, @ID_Especializacao)", connection))
                    {
                        assocCmd.Parameters.AddWithValue("@ID_Bombeiro", this.ID_Bombeiro);
                        assocCmd.Parameters.AddWithValue("@ID_Especializacao", idEspecializacao);
                        assocCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Especialização adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar especialização: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
