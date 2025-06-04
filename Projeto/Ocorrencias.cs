// Ocorrencias.cs com uso de Stored Procedures para listar e remover ocorrências
// Adaptações feitas para utilizar spListarOcorrencias e spRemoverOcorrencia

// IMPORTANTE: Certifica-te de que as SPs estão corretamente criadas na tua base de dados SQL Server.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Ocorrencias : Form
    {
        private List<OcorrenciaInfo> ocorrencias = new List<OcorrenciaInfo>();

        private class OcorrenciaInfo
        {
            public int Id { get; set; }
            public string Descricao { get; set; }
            public string Data { get; set; }
            public string Local { get; set; }
            public string Reportada_por { get; set; }
            public string Numero { get; set; }
            public override string ToString() => $"({Id}) {Descricao}";
        }

        public Ocorrencias()
        {
            InitializeComponent();
            CarregarOcorrencias();
            BOcorrReturn.Click += BOcorrReturn_Click;
            LBOcorrList.SelectedIndexChanged += LBOcorrList_SelectedIndexChanged;
            BERem.Click += BOcorrRem_Click;
            button1.Click += BOcorrNovo_Click;
        }

        private void CarregarOcorrencias()
        {
            string connectionString = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";
            try
            {
                LBOcorrList.Items.Clear();
                ocorrencias.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarOcorrencias", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var info = new OcorrenciaInfo
                                {
                                    Id = Convert.ToInt32(reader["ID_Ocorrência"]),
                                    Descricao = reader["Descrição"].ToString(),
                                    Local = reader["Localização"].ToString(),
                                    Reportada_por = reader["Nome"].ToString(),
                                    Numero = reader["Número"].ToString(),
                                    Data = Convert.ToDateTime(reader["Data_Hora"]).ToString("dd/MM/yyyy")
                                };
                                ocorrencias.Add(info);
                                LBOcorrList.Items.Add(info);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar ocorrências: {ex.Message}");
            }
        }

        private void BOcorrRem_Click(object sender, EventArgs e)
        {
            int idx = LBOcorrList.SelectedIndex;
            if (idx >= 0 && idx < ocorrencias.Count)
            {
                var ocorrenciaSelecionada = ocorrencias[idx];
                var confirm = MessageBox.Show(
                    $"Tem certeza que deseja remover a ocorrência \"{ocorrenciaSelecionada.Descricao}\"?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    string connectionString = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand("spRemoverOcorrencia", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@ID", ocorrenciaSelecionada.Id);
                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Ocorrência removida com sucesso!");
                        CarregarOcorrencias();
                        LimparCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover ocorrência: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma ocorrência para remover.");
            }
        }

        private void BOcorrReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BOcorrNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            LBOcorrList.ClearSelected();
            LBOcorrCham.Items.Clear();
            LBOcorrBomb.Items.Clear();
            LBOcorrVia.Items.Clear();
            LBOcorrEquip.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void LBOcorrList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBOcorrList.SelectedIndex >= 0 && LBOcorrList.SelectedIndex < ocorrencias.Count)
            {
                var selecionada = ocorrencias[LBOcorrList.SelectedIndex];
                CarregarChamadasDaOcorrencia(selecionada.Id);
                CarregarBombeirosDaOcorrencia(selecionada.Id);
                CarregarViaturasDaOcorrencia(selecionada.Id);
                CarregarEquipamentosDaOcorrencia(selecionada.Id);
            }
        }
        private void CarregarBombeirosDaOcorrencia(int idOcorrencia)
        {
            LBOcorrBomb.Items.Clear();
            string cs = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT b.Nome_Bombeiro FROM Bombeiro b INNER JOIN Bombeiro_Ocorrência bo ON b.ID_Bombeiro = bo.ID_Bombeiro WHERE bo.ID_Ocorrência = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", idOcorrencia);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                LBOcorrBomb.Items.Add(r["Nome_Bombeiro"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar bombeiros: {ex.Message}");
            }
        }
        private void CarregarChamadasDaOcorrencia(int idOcorrencia)
        {
            LBOcorrCham.Items.Clear();
            string cs = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Nome, [Descrição], Data_Hora_Chamada FROM Chamada WHERE ID_Ocorrência = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", idOcorrencia);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string linha = $"{r["Nome"]} - {r["Descrição"]} ({Convert.ToDateTime(r["Data_Hora_Chamada"]).ToShortTimeString()})";
                                LBOcorrCham.Items.Add(linha);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar chamadas: {ex.Message}");
            }
        }

        private void CarregarViaturasDaOcorrencia(int idOcorrencia)
        {
            LBOcorrVia.Items.Clear();
            string cs = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT v.Matricula FROM Viatura v INNER JOIN Viatura_Ocorrência vo ON v.ID_Viatura = vo.ID_Viatura WHERE vo.ID_Ocorrência = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", idOcorrencia);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                LBOcorrVia.Items.Add(r["Matricula"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar viaturas: {ex.Message}");
            }
        }
        private void Ocorrencias_Load(object sender, EventArgs e)
        {
            // Evento de carregamento do formulário Ocorrencias
            CarregarOcorrencias();
        }

        private void CarregarEquipamentosDaOcorrencia(int idOcorrencia)
        {
            LBOcorrEquip.Items.Clear();
            string cs = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT e.Nome_Equipamento, e.Quantidade
                        FROM Equipamento e
                        JOIN Viatura v ON e.ID_Viatura = v.ID_Viatura
                        JOIN Viatura_Ocorrência vo ON v.ID_Viatura = vo.ID_Viatura
                        WHERE vo.ID_Ocorrência = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", idOcorrencia);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string nome = r["Nome_Equipamento"].ToString();
                                string qtd = r["Quantidade"].ToString();
                                LBOcorrEquip.Items.Add($"{nome} ({qtd})");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar equipamentos: {ex.Message}");
            }
        }
    }
}
