using System;
using System.Collections.Generic;
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

        private List<EquipamentoInfo> equipamentos = new List<EquipamentoInfo>();

        private void CarregarDados()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = @"
        SELECT e.ID_Equipamento, e.Nome_Equipamento, e.Quantidade, v.Matricula, v.ID_Viatura
        FROM Equipamento e
        INNER JOIN Viatura v ON e.ID_Viatura = v.ID_Viatura";

            try
            {
                listBox1.Items.Clear();
                equipamentos.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                                string item = $"({info.ID_Equipamento}) {info.Nome_Equipamento} - {info.Quantidade} | ({info.ID_Viatura}) Viatura: {info.Nome_Viatura}";
                                listBox1.Items.Add(item);
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
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
            string query = "INSERT INTO Equipamento (Nome_Equipamento, Quantidade, ID_Viatura) VALUES (@Nome, @Quantidade, @ID_Viatura)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Quantidade", quantidade);
                    command.Parameters.AddWithValue("@ID_Viatura", idViatura);
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Equipamento adicionado com sucesso!");
        }

        private void BEAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionarEquipamento(
                    TEV1.Text,
                    int.Parse(textBox1.Text),
                    int.Parse(textBox2.Text) // Agora espera o ID da viatura
                );
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar equipamento: {ex.Message}");
            }
        }



        private void BEReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Equipamento_Load(object sender, EventArgs e)
        {

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
                    string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuartelBombeiros;Integrated Security=True";
                    string query = "DELETE FROM Equipamento WHERE ID_Equipamento = @id";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@id", equipamentoSelecionado.ID_Equipamento);
                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Equipamento removido com sucesso!");
                        CarregarDados();
                        // Limpa os campos após remoção
                        TEV1.Clear();
                        textBox1.Clear();
                        textBox2.Clear();
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


    }
}