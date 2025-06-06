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
            this.BEEdit.Click += new EventHandler(BBEdit_Click);

        }

        private void CarregarOcorrencias()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"
        SELECT 
            o.ID_Ocorrência AS ID_Ocorrencia,
            d.Descrição AS Descricao, 
            d.Localização AS Localizacao, 
            d.Nome, 
            d.Número AS Numero, 
            o.Data_Hora
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
                                    Id = Convert.ToInt32(reader["ID_Ocorrencia"]),
                                    Descricao = reader["Descricao"].ToString(),
                                    Data = Convert.ToDateTime(reader["Data_Hora"]).ToString("dd/MM/yyyy"),
                                    Local = reader["Localizacao"].ToString(),
                                    Reportada_por = reader["Nome"].ToString(),
                                    Numero = reader["Numero"].ToString()
                                };
                                ocorrencias.Add(info);

                                // Se a classe OcorrenciaInfo não sobrescreve ToString(),
                                // adiciona um texto legível aqui:
                                LBOcorrList.Items.Add($"{info.Data} - {info.Descricao} ({info.Local})");
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

        private void BBEdit_Click(object sender, EventArgs e)
        {
            EditarOcorrencia();
        }



        private void EditarOcorrencia()
        {
            if (LBOcorrList.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma ocorrência para editar.");
                return;
            }

            var ocorrenciaSelecionada = ocorrencias[LBOcorrList.SelectedIndex];
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            string bombeirosInput = textBox1.Text.Trim(); // Ex: "1,2"
            string viaturasInput = textBox2.Text.Trim();  // Ex: "3,4"
            string chamadaInput = textBox3.Text.Trim();

            if (!int.TryParse(chamadaInput, out int idChamada))
            {
                MessageBox.Show("ID de chamada inválido.");
                return;
            }

            // Validar chamada
            if (!ExisteNaBase("Chamada", "ID_Chamada", idChamada))
            {
                MessageBox.Show($"A chamada com ID {idChamada} não existe.");
                return;
            }

            // Validar bombeiros
            var idsBombeiros = bombeirosInput.Split(',').Select(x => x.Trim()).Where(x => x != "").ToList();
            foreach (var idStr in idsBombeiros)
            {
                if (!int.TryParse(idStr, out int id) || !ExisteNaBase("Bombeiro", "ID_Bombeiro", id))
                {
                    MessageBox.Show($"O bombeiro com ID {idStr} não existe.");
                    return;
                }
            }

            // Validar viaturas
            var idsViaturas = viaturasInput.Split(',').Select(x => x.Trim()).Where(x => x != "").ToList();
            foreach (var idStr in idsViaturas)
            {
                if (!int.TryParse(idStr, out int id) || !ExisteNaBase("Viatura", "ID_Viatura", id))
                {
                    MessageBox.Show($"A viatura com ID {idStr} não existe.");
                    return;
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("spEditarOcorrenciaCompleta", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_Ocorrencia", ocorrenciaSelecionada.Id);
                    cmd.Parameters.AddWithValue("@ID_Quartel", 11111); // fixo
                    cmd.Parameters.AddWithValue("@DataHora", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ID_Chamada", idChamada);
                    cmd.Parameters.AddWithValue("@ListaBombeiros", bombeirosInput);
                    cmd.Parameters.AddWithValue("@ListaViaturas", viaturasInput);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Ocorrência atualizada com sucesso!");
                    CarregarOcorrencias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar ocorrência: {ex.Message}");
            }
        }



        private bool ExisteNaBase(string tabela, string campo, int id)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            string query = $"SELECT COUNT(*) FROM {tabela} WHERE {campo} = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
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

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spRemoverOcorrenciaCompleta", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID_Ocorrencia", ocorrenciaSelecionada.Id);

                            try
                            {
                                connection.Open();
                                cmd.ExecuteNonQuery();
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

            string bombeirosInput = textBox1.Text.Trim(); // ex: "1,2,3"
            string viaturasInput = textBox2.Text.Trim();  // ex: "1,4"
            string chamadaInput = textBox3.Text.Trim();

            if (!int.TryParse(chamadaInput, out int idChamada))
            {
                MessageBox.Show("Insira um ID de chamada válido.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spAdicionarOcorrenciaCompleta", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_Quartel", 11111);
                    cmd.Parameters.AddWithValue("@DataHora", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ID_Chamada", idChamada);
                    cmd.Parameters.AddWithValue("@Bombeiros", bombeirosInput);
                    cmd.Parameters.AddWithValue("@Viaturas", viaturasInput);

                    try
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int idOcorrencia))
                        {
                            MessageBox.Show($"Ocorrência adicionada com sucesso! ID: {idOcorrencia}");
                            CarregarOcorrencias();
                        }
                        else
                        {
                            MessageBox.Show("Ocorrência adicionada, mas não foi possível obter o ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao adicionar ocorrência: {ex.Message}");
                    }
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

                PreencherCamposComIDs(selecionada.Id);
            }
        }

        private void PreencherCamposComIDs(int idOcorrencia)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            // IDs dos bombeiros
            string bombeiroQuery = @"
        SELECT ID_Bombeiro 
        FROM Bombeiro_Ocorrência 
        WHERE ID_Ocorrência = @idOcorrencia";

            // IDs das viaturas
            string viaturaQuery = @"
        SELECT ID_Viatura 
        FROM Viatura_Ocorrência 
        WHERE ID_Ocorrência = @idOcorrencia";

            // ID da chamada
            string chamadaQuery = @"
        SELECT TOP 1 ID_Chamada 
        FROM Chamada 
        WHERE ID_Ocorrência = @idOcorrencia";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Bombeiros
                using (SqlCommand cmd = new SqlCommand(bombeiroQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@idOcorrencia", idOcorrencia);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> ids = new List<string>();
                        while (reader.Read())
                        {
                            ids.Add(reader["ID_Bombeiro"].ToString());
                        }
                        textBox1.Text = string.Join(",", ids);
                    }
                }

                // Viaturas
                using (SqlCommand cmd = new SqlCommand(viaturaQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@idOcorrencia", idOcorrencia);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> ids = new List<string>();
                        while (reader.Read())
                        {
                            ids.Add(reader["ID_Viatura"].ToString());
                        }
                        textBox2.Text = string.Join(",", ids);
                    }
                }

                // Chamada
                using (SqlCommand cmd = new SqlCommand(chamadaQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@idOcorrencia", idOcorrencia);
                    object result = cmd.ExecuteScalar();
                    textBox3.Text = result != null ? result.ToString() : "";
                }
            }
        }





    }
}