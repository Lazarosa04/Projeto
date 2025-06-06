using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Bombeiro : Form
    {
        private List<BombeiroInfo> bombeiros = new List<BombeiroInfo>();


        public class BaixaInfo
        {
            public int ID_Baixa { get; set; }
            public DateTime DataInicio { get; set; }
            public DateTime DataFim { get; set; }
            public string Razao { get; set; }

            public override string ToString()
            {
                return $"{DataInicio.ToShortDateString()} - {DataFim.ToShortDateString()} : {Razao}";
            }
        }

        public class EspecializacaoInfo
        {
            public int ID_Especializacao { get; set; }
            public string Nome { get; set; }
        }


        public class FeriasInfo
        {
            public int ID_Ferias { get; set; }
            public DateTime DataInicio { get; set; }
            public DateTime DataFim { get; set; }

            public override string ToString()
            {
                return $"{DataInicio.ToShortDateString()} - {DataFim.ToShortDateString()}";
            }
        }



        private class BombeiroInfo
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Nascimento { get; set; }
            public string Morada { get; set; }
            public string Email { get; set; }
            public string NIF { get; set; }
            public string Telemovel { get; set; }

            public override string ToString() => $"{Nome} ({Id})";
        }

        public Bombeiro()
        {
            InitializeComponent();
            CarregarDados();
            this.BBReturn.Click += BBReturn_Click;
            this.listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            this.BBRem.Click += BBRem_Click;
            this.button1.Click += button1_Click;
            this.BBAdd.Click += BBAdd_Click;
            this.BBEdit.Click += BBEdit_Click;
            this.BBRemoveFérias.Click += BBRemoveFerias_Click;
            this.BRemoveBaixa.Click += BBRemoveBaixa_Click;
            this.BAddBaixa.Click += BAddBaixa_Click_1;
            this.BAddEspecializações.Click += BaddEspecializacao_Click;
            this.BRemoveEspecializações.Click += BremEspecializacao_Click;
        }

        private void CarregarDados()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            try
            {
                listBox1.Items.Clear();
                bombeiros.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarBombeiros", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var info = new BombeiroInfo
                                {
                                    Id = Convert.ToInt32(reader["ID_Bombeiro"]),
                                    Nome = reader["Nome_Bombeiro"].ToString(),
                                    Nascimento = Convert.ToDateTime(reader["Data_Nascimento"]).ToString("dd/MM/yyyy"),
                                    Morada = reader["Morada"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    NIF = reader["NIF"].ToString(),
                                    Telemovel = reader["Telemóvel"].ToString()
                                };
                                bombeiros.Add(info);
                                listBox1.Items.Add(info);
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

        private void CarregarBaixas(int idBombeiro)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            List<BaixaInfo> baixas = new List<BaixaInfo>();

            try
            {
                LBBBaixa.Items.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarBaixasPorBombeiro", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idBombeiro", idBombeiro);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BaixaInfo baixa = new BaixaInfo
                                {
                                    ID_Baixa = Convert.ToInt32(reader["ID_Baixa"]),
                                    DataInicio = Convert.ToDateTime(reader["Data_Inicio"]),
                                    DataFim = Convert.ToDateTime(reader["Data_Fim"]),
                                    Razao = reader["Razão"].ToString()
                                };
                                baixas.Add(baixa);
                            }

                        }
                    }
                }

                foreach (var baixa in baixas)
                {
                    LBBBaixa.Items.Add(baixa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar baixas: {ex.Message}");
            }
        }

        private void CarregarFerias(int idBombeiro)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            List<FeriasInfo> feriasList = new List<FeriasInfo>();

            try
            {
                LBBFérias.Items.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarFeriasPorBombeiro", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idBombeiro", idBombeiro);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FeriasInfo ferias = new FeriasInfo
                                {
                                    ID_Ferias = Convert.ToInt32(reader["ID_Férias"]),
                                    DataInicio = Convert.ToDateTime(reader["Data_Inicio"]),
                                    DataFim = Convert.ToDateTime(reader["Data_Fim"])
                                };
                                feriasList.Add(ferias);
                            }
                        }
                    }
                }

                foreach (var ferias in feriasList)
                {
                    LBBFérias.Items.Add(ferias);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar férias: {ex.Message}");
            }
        }





        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var selecionado = bombeiros[listBox1.SelectedIndex];
                TBV1.Text = selecionado.Nome;
                textBox1.Text = selecionado.Morada;
                textBox2.Text = selecionado.Email;
                textBox3.Text = selecionado.NIF;
                textBox4.Text = selecionado.Telemovel;
                textBox5.Text = selecionado.Nascimento;

                CarregarBaixas(selecionado.Id);
                CarregarFerias(selecionado.Id);
                CarregarEspecializacoes(selecionado.Id);
            }
            else
            {
                LBBBaixa.Items.Clear();
            }
        }


        private void BBReturn_Click(object sender, EventArgs e) => this.Close();

        private void Bombeiro_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            TBV1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void BBAdd_Click(object sender, EventArgs e)
        {
            string nome = TBV1.Text.Trim();
            string morada = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string nif = textBox3.Text.Trim();
            string telemovel = textBox4.Text.Trim();
            string nascimento = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(nascimento))
            {
                MessageBox.Show("Preencha pelo menos o nome e a data de nascimento.");
                return;
            }

            if (!DateTime.TryParse(nascimento, out DateTime dataNascimento))
            {
                MessageBox.Show("Data de nascimento inválida.");
                return;
            }

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spAdicionarBombeiro", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                        command.Parameters.AddWithValue("@Morada", morada);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@NIF", nif);
                        command.Parameters.AddWithValue("@Telemovel", telemovel);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Bombeiro adicionado com sucesso!");
                CarregarDados();
                TBV1.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar bombeiro: {ex.Message}");
            }
        }

        private void BBRem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um bombeiro para remover.");
                return;
            }

            var selecionado = bombeiros[listBox1.SelectedIndex];
            var confirm = MessageBox.Show($"Tem certeza que deseja remover '{selecionado.Nome}'?", "Confirmar Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("spRemoverBombeiro", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@Id", selecionado.Id);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Bombeiro removido com sucesso.");
                    CarregarDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover bombeiro: {ex.Message}");
                }
            }
        }

        private void BBEdit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um bombeiro para editar.");
                return;
            }

            var selecionado = bombeiros[listBox1.SelectedIndex];
            string nome = TBV1.Text.Trim();
            string morada = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string nif = textBox3.Text.Trim();
            string telemovel = textBox4.Text.Trim();
            string nascimento = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(nascimento))
            {
                MessageBox.Show("Preencha pelo menos o nome e a data de nascimento.");
                return;
            }

            if (!DateTime.TryParse(nascimento, out DateTime dataNascimento))
            {
                MessageBox.Show("Data de nascimento inválida.");
                return;
            }

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spAtualizarBombeiro", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", selecionado.Id);
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                        command.Parameters.AddWithValue("@Morada", morada);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@NIF", nif);
                        command.Parameters.AddWithValue("@Telemovel", telemovel);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Bombeiro atualizado com sucesso!");
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar bombeiro: {ex.Message}");
            }
        }

        private void Bombeiro_Load_1(object sender, EventArgs e)
        {

        }

        private void BAddBaixa_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um bombeiro antes de adicionar baixa.");
                return;
            }

            var selecionado = bombeiros[listBox1.SelectedIndex];
            Baixa baixa = new Baixa(selecionado.Id);
            baixa.ShowDialog();

            CarregarBaixas(selecionado.Id);
        }




        private void BAddFerias_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um bombeiro antes de adicionar Férias.");
                return;
            }
            var selecionado = bombeiros[listBox1.SelectedIndex];
            Férias ferias = new Férias(selecionado.Id);
            ferias.ShowDialog();
            CarregarFerias(selecionado.Id);

        }

        public void RemoverFerias(int idFerias)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("RemoverFerias", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Ferias", idFerias);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Férias removidas com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover férias: {ex.Message}");
            }
        }


        public void RemoverBaixa(int idBaixa)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spRemoverBaixa", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Baixa", idBaixa);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Baixa removida com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover baixa: {ex.Message}");
            }
        }

        private void BBRemoveBaixa_Click(object sender, EventArgs e)
        {
            if (LBBBaixa.SelectedItem is BaixaInfo baixaSelecionada)
            {
                RemoverBaixa(baixaSelecionada.ID_Baixa);
                var selecionado = bombeiros[listBox1.SelectedIndex];
                CarregarBaixas(selecionado.Id); // Atualiza a lista após remover
            }
            else
            {
                MessageBox.Show("Por favor selecione uma baixa para remover.");
            }
        }

        private void BBRemoveFerias_Click(object sender, EventArgs e)
        {
            if (LBBFérias.SelectedItem is FeriasInfo feriasSelecionada)
            {
                RemoverFerias(feriasSelecionada.ID_Ferias);
                var selecionado = bombeiros[listBox1.SelectedIndex];
                CarregarFerias(selecionado.Id); // Atualiza a lista após remover
            }
            else
            {
                MessageBox.Show("Por favor selecione umas férias para remover.");
            }
        }


        private List<EspecializacaoInfo> especializacoes = new List<EspecializacaoInfo>();

        private void CarregarEspecializacoes(int idBombeiro)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                especializacoes.Clear();
                LBEspecializações.Items.Clear(); // Assumindo que tens um ListBox chamado LBEspecializacoes

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarEspecializacoesDoBombeiro", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Bombeiro", idBombeiro);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var esp = new EspecializacaoInfo
                                {
                                    ID_Especializacao = Convert.ToInt32(reader["ID_Especialização"]),
                                    Nome = reader["Nome_Especialização"].ToString()
                                };
                                especializacoes.Add(esp);
                                LBEspecializações.Items.Add($"({esp.ID_Especializacao}) {esp.Nome}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar especializações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void BaddEspecializacao_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex; // ou listViewBombeiros.SelectedItems[0].Index;

            if (idx >= 0 && idx < bombeiros.Count)
            {
                int idBombeiroSelecionado = bombeiros[idx].Id;

                // Instanciar o formulário da especialização
                Especialização formEspecializacao = new Especialização();

                // Passar o ID do bombeiro selecionado
                formEspecializacao.ID_Bombeiro = idBombeiroSelecionado;

                // Mostrar o formulário como modal
                if (formEspecializacao.ShowDialog() == DialogResult.OK)
                {
                    // Se quiseres, atualiza a lista de especializações aqui
                    CarregarEspecializacoes(idBombeiroSelecionado);
                }
            }
            else
            {
                MessageBox.Show("Selecione um bombeiro para adicionar especialização.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void BremEspecializacao_Click(object sender, EventArgs e)
        {
            int idxEspecializacao = LBEspecializações.SelectedIndex;
            int idxBombeiro = listBox1.SelectedIndex;

            if (idxBombeiro < 0)
            {
                MessageBox.Show("Selecione um bombeiro primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idxEspecializacao < 0)
            {
                MessageBox.Show("Selecione uma especialização para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idBombeiro = bombeiros[idxBombeiro].Id;
            int idEspecializacao = especializacoes[idxEspecializacao].ID_Especializacao; // suposição: tens uma lista com as especializações carregadas

            var confirm = MessageBox.Show($"Tem certeza que deseja remover esta especialização do bombeiro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Bombeiro_Especialização WHERE ID_Bombeiro = @ID_Bombeiro AND ID_Especialização = @ID_Especializacao", connection))
                    {
                        command.Parameters.AddWithValue("@ID_Bombeiro", idBombeiro);
                        command.Parameters.AddWithValue("@ID_Especializacao", idEspecializacao);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Especialização removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarEspecializacoes(idBombeiro);  // Atualiza a lista de especializações do bombeiro
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover especialização: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
