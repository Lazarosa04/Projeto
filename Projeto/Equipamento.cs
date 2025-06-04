// Equipamento.cs atualizado para uso de stored procedures
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Equipamento : Form
    {
        public Equipamento()
        {
            InitializeComponent();
            CarregarDados();
            this.BEReturn.Click += new EventHandler(BEReturn_Click);
            this.listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            this.BEAdd.Click += new EventHandler(BEAdd_Click);
            this.BERem.Click += new EventHandler(BERemove_Click);
            this.button1.Click += new EventHandler(BENovo_Click);
        }

        private class EquipamentoInfo
        {
            public int ID_Equipamento { get; set; }
            public string Nome_Equipamento { get; set; }
            public int Quantidade { get; set; }
            public string Nome_Viatura { get; set; }
            public int ID_Viatura { get; set; }
        }
        private void Equipamento_Load(object sender, EventArgs e)
        {
            // Evento de carregamento do formulário Equipamento
            CarregarDados();
        }

        private List<EquipamentoInfo> equipamentos = new List<EquipamentoInfo>();

        private void CarregarDados()
        {
            string connectionString = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";
            try
            {
                listBox1.Items.Clear();
                equipamentos.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spListarEquipamentos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var info = new EquipamentoInfo
                                {
                                    ID_Equipamento = Convert.ToInt32(reader["ID_Equipamento"]),
                                    Nome_Equipamento = reader["Nome_Equipamento"].ToString(),
                                    Quantidade = Convert.ToInt32(reader["Quantidade"]),
                                    Nome_Viatura = reader["Matricula"].ToString(),
                                    ID_Viatura = Convert.ToInt32(reader["ID_Viatura"])
                                };
                                equipamentos.Add(info);
                                listBox1.Items.Add($"({info.ID_Equipamento}) {info.Nome_Equipamento} - {info.Quantidade} | ({info.ID_Viatura}) Viatura: {info.Nome_Viatura}");
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

        private void LimparCampos()
        {
            listBox1.ClearSelected();
            TEV1.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void BENovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void AdicionarEquipamento(string nome, int quantidade, int idViatura)
        {
            string connectionString = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spAdicionarEquipamento", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Quantidade", quantidade);
                        command.Parameters.AddWithValue("@ID_Viatura", idViatura);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Equipamento adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar equipamento: {ex.Message}");
            }
        }

        private void BEAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionarEquipamento(
                    TEV1.Text,
                    int.Parse(textBox1.Text),
                    int.Parse(textBox2.Text)
                );
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar equipamento: {ex.Message}");
            }
        }

        private void BERemove_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx >= 0 && idx < equipamentos.Count)
            {
                var equipamentoSelecionado = equipamentos[idx];
                var confirm = MessageBox.Show(
                    $"Tem certeza que deseja remover o equipamento \"{equipamentoSelecionado.Nome_Equipamento}\"?",
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
                            using (SqlCommand command = new SqlCommand("spRemoverEquipamento", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@ID", equipamentoSelecionado.ID_Equipamento);
                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Equipamento removido com sucesso!");
                        CarregarDados();
                        LimparCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover equipamento: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um equipamento para remover.");
            }
        }

        private void BEReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx >= 0 && idx < equipamentos.Count)
            {
                var eq = equipamentos[idx];
                TEV1.Text = eq.Nome_Equipamento;
                textBox1.Text = eq.Quantidade.ToString();
                textBox2.Text = eq.ID_Viatura.ToString();
            }
        }
    }
}
