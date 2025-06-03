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
    public partial class Ocorrencias : Form
    {
        // Lista para armazenar as ocorrências
        private List<OcorrenciaInfo> ocorrencias = new List<OcorrenciaInfo>();

        // Classe interna para representar uma ocorrência
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
            this.BOcorrReturn.Click += new EventHandler(BOcorrReturn_Click);
            this.LBOcorrList.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            this.LBOcorrVia.SelectedIndexChanged += LBOcorrVia_SelectedIndexChanged;
            this.BEAdd.Click += new EventHandler(BEAdd_Click);
            this.button1.Click += new EventHandler(BOcorrNovo_Click);
            this.BERem.Click += new EventHandler(BOcorrRem_Click);

        }

        private void CarregarOcorrencias()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"
        SELECT o.ID_Ocorrência, d.Descrição, d.Localização, d.Nome, d.Número, o.Data_Hora
        FROM Ocorrência o
        INNER JOIN Chamada d ON o.ID_Ocorrência = d.ID_Ocorrência";

            try
            {
                LBOcorrList.Items.Clear();
                ocorrencias.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var info = new OcorrenciaInfo
                                {
                                    Id = Convert.ToInt32(reader["ID_Ocorrência"]),
                                    Descricao = reader["Descrição"].ToString(),
                                    Data = Convert.ToDateTime(reader["Data_Hora"]).ToString("dd/MM/yyyy"),
                                    Local = reader["Localização"].ToString(),
                                    Reportada_por = reader["Nome"].ToString(),
                                    Numero = reader["Número"].ToString()
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


        private void BOcorrReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ocorrencias_Load(object sender, EventArgs e)
        {

        }

        private void CarregarChamadasDaOcorrencia(int idOcorrencia)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"SELECT ID_Chamada, Número, Nome, Localização, Descrição, Data_Hora_Chamada
                     FROM Chamada
                     WHERE ID_Ocorrência = @idOcorrencia";

            LBOcorrCham.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idOcorrencia", idOcorrencia);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Exemplo: mostra o número e o nome de quem reportou
                                string chamadaInfo = $"({reader["ID_Chamada"]}) {reader["Nome"]}: {reader["Número"]}";
                                LBOcorrCham.Items.Add(chamadaInfo);
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

        private void CarregarBombeirosDaOcorrencia(int idOcorrencia)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"
        SELECT b.ID_Bombeiro, b.Nome_Bombeiro, b.NIF, b.Email, b.Telemóvel
        FROM Bombeiro b
        INNER JOIN Bombeiro_Ocorrência bo ON b.ID_Bombeiro = bo.ID_Bombeiro
        WHERE bo.ID_Ocorrência = @idOcorrencia";

            LBOcorrBomb.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idOcorrencia", idOcorrencia);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string bombeiroInfo = $"({reader["ID_Bombeiro"]}) {reader["Nome_Bombeiro"]}";
                                LBOcorrBomb.Items.Add(bombeiroInfo);
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

        private void CarregarViaturasDaOcorrencia(int idOcorrencia)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"
        SELECT v.ID_Viatura, v.Matricula, v.Ano, t.Nome_TipoViatura
        FROM Viatura v
        INNER JOIN Viatura_Ocorrência vo ON v.ID_Viatura = vo.ID_Viatura
        INNER JOIN TipoViatura t ON v.ID_TipoViatura = t.ID_TipoViatura
        WHERE vo.ID_Ocorrência = @idOcorrencia";

            LBOcorrVia.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idOcorrencia", idOcorrencia);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string viaturaInfo = $"({reader["ID_Viatura"]}) {reader["Nome_TipoViatura"]} {reader["Matricula"]} {reader["Ano"]}";
                                LBOcorrVia.Items.Add(viaturaInfo);
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
            // Limpe outros campos de texto se existirem
        }

        private void BOcorrNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
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
                    string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {
                                // Remove referências em Bombeiro_Ocorrência
                                using (SqlCommand cmd = new SqlCommand("DELETE FROM Bombeiro_Ocorrência WHERE ID_Ocorrência = @id", connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@id", ocorrenciaSelecionada.Id);
                                    cmd.ExecuteNonQuery();
                                }
                                // Remove referências em Viatura_Ocorrência
                                using (SqlCommand cmd = new SqlCommand("DELETE FROM Viatura_Ocorrência WHERE ID_Ocorrência = @id", connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@id", ocorrenciaSelecionada.Id);
                                    cmd.ExecuteNonQuery();
                                }
                                // Desvincula a ocorrência das chamadas (não apaga a chamada!)
                                using (SqlCommand cmd = new SqlCommand("UPDATE Chamada SET ID_Ocorrência = NULL WHERE ID_Ocorrência = @id", connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@id", ocorrenciaSelecionada.Id);
                                    cmd.ExecuteNonQuery();
                                }
                                // Remove a ocorrência
                                using (SqlCommand cmd = new SqlCommand("DELETE FROM Ocorrência WHERE ID_Ocorrência = @id", connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@id", ocorrenciaSelecionada.Id);
                                    cmd.ExecuteNonQuery();
                                }
                                transaction.Commit();
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

        private void CarregarEquipamentosDaOcorrencia(int idOcorrencia)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"
        SELECT e.ID_Equipamento, e.Nome_Equipamento, e.Quantidade
        FROM Equipamento e
        INNER JOIN Viatura v ON e.ID_Viatura = v.ID_Viatura
        INNER JOIN Viatura_Ocorrência vo ON v.ID_Viatura = vo.ID_Viatura
        WHERE vo.ID_Ocorrência = @idOcorrencia";

            LBOcorrEquip.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idOcorrencia", idOcorrencia);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string equipamentoInfo = $"({reader["ID_Equipamento"]}) {reader["Nome_Equipamento"]} - Quantidade: {reader["Quantidade"]}";
                                LBOcorrEquip.Items.Add(equipamentoInfo);
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


        private void CarregarEquipamentosDaViatura(int idViatura)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"
        SELECT ID_Equipamento, Nome_Equipamento, Quantidade
        FROM Equipamento
        WHERE ID_Viatura = @idViatura";

            LBOcorrEquip.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idViatura", idViatura);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string equipamentoInfo = $"({reader["ID_Equipamento"]}) {reader["Nome_Equipamento"]} - Quantidade: {reader["Quantidade"]}";
                                LBOcorrEquip.Items.Add(equipamentoInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar equipamentos da viatura: {ex.Message}");
            }
        }

        private void LBOcorrVia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBOcorrVia.SelectedIndex >= 0)
            {
                string itemSelecionado = LBOcorrVia.SelectedItem.ToString();

                // Extrair o ID da viatura do início da string: "({ID}) ..."
                int idInicio = itemSelecionado.IndexOf('(') + 1;
                int idFim = itemSelecionado.IndexOf(')');
                string idString = itemSelecionado.Substring(idInicio, idFim - idInicio);

                if (int.TryParse(idString, out int idViatura))
                {
                    CarregarEquipamentosDaViatura(idViatura);
                }
            }
        }


        private void BEAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            string bombeirosInput = textBox1.Text.Trim();
            string viaturasInput = textBox2.Text.Trim();
            string chamadaInput = textBox3.Text.Trim(); // Aqui é só o ID da chamada

            if (!int.TryParse(chamadaInput, out int idChamada))
            {
                MessageBox.Show("Insira um ID de chamada válido.");
                return;
            }

            int idOcorrencia = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1. Inserir Ocorrência
                    string insertOcorrencia = "INSERT INTO Ocorrência (ID_Quartel, Data_Hora) OUTPUT INSERTED.ID_Ocorrência VALUES (11111, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(insertOcorrencia, connection, transaction))
                    {
                        idOcorrencia = (int)cmd.ExecuteScalar();
                    }

                    // 2. Atualizar chamada existente para associar à nova ocorrência
                    string updateChamada = "UPDATE Chamada SET ID_Ocorrência = @idOcorrencia WHERE ID_Chamada = @idChamada";
                    using (SqlCommand cmd = new SqlCommand(updateChamada, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idOcorrencia", idOcorrencia);
                        cmd.Parameters.AddWithValue("@idChamada", idChamada);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                        {
                            throw new Exception("ID de chamada não encontrado.");
                        }
                    }

                    // 3. Associar Bombeiros
                    foreach (var idStr in bombeirosInput.Split(','))
                    {
                        if (int.TryParse(idStr.Trim(), out int idBombeiro))
                        {
                            string insertBO = "INSERT INTO Bombeiro_Ocorrência (ID_Ocorrência, ID_Bombeiro) VALUES (@idO, @idB)";
                            using (SqlCommand cmd = new SqlCommand(insertBO, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idO", idOcorrencia);
                                cmd.Parameters.AddWithValue("@idB", idBombeiro);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // 4. Associar Viaturas
                    foreach (var idStr in viaturasInput.Split(','))
                    {
                        if (int.TryParse(idStr.Trim(), out int idViatura))
                        {
                            string insertVO = "INSERT INTO Viatura_Ocorrência (ID_Ocorrência, ID_Viatura) VALUES (@idO, @idV)";
                            using (SqlCommand cmd = new SqlCommand(insertVO, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idO", idOcorrencia);
                                cmd.Parameters.AddWithValue("@idV", idViatura);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Ocorrência adicionada com sucesso!");
                    CarregarOcorrencias();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Erro ao adicionar ocorrência: {ex.Message}");
                }
            }
        }




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBOcorrList.SelectedIndex >= 0)
            {
                var selecionada = ocorrencias[LBOcorrList.SelectedIndex];
                // Preencha outros campos conforme necessário

                // Carrega as chamadas associadas
                CarregarChamadasDaOcorrencia(selecionada.Id);
                CarregarBombeirosDaOcorrencia(selecionada.Id);
                CarregarViaturasDaOcorrencia(selecionada.Id);
                CarregarEquipamentosDaOcorrencia(selecionada.Id);
            }
        }




    }
}