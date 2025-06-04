// Viatura.cs com stored procedures: spAdicionarViatura, spEditarViatura, spRemoverViatura
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Viatura : Form
    {
        private List<ViaturaInfo> viaturas = new List<ViaturaInfo>();

        private class ViaturaInfo
        {
            public int Id { get; set; }
            public string Tipo { get; set; }
            public string Matricula { get; set; }
            public string Ano { get; set; }
            public override string ToString() => $"({Id}) {Tipo} {Matricula}";
        }

        private Dictionary<int, string> tiposViatura = new Dictionary<int, string>();

        public Viatura()
        {
            InitializeComponent();
            BVReturn.Click += BVReturn_Click;
            LBV_List.SelectedIndexChanged += LBV_List_SelectedIndexChanged;
            BVRem.Click += BVRem_Click;
            BVAdd.Click += BVAdd_Click;
            BVEdit.Click += BVEdit_Click;
            button1.Click += button1_Click;
            CarregarDados();
        }

        private void CarregarDados()
        {
            string cs = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";
            try
            {
                LBV_List.Items.Clear();
                viaturas.Clear();
                tiposViatura.Clear();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    using (SqlCommand cmdTipos = new SqlCommand("SELECT * FROM TipoViatura", conn))
                    using (SqlDataReader rTipos = cmdTipos.ExecuteReader())
                        while (rTipos.Read())
                            tiposViatura[Convert.ToInt32(rTipos["ID_TipoViatura"])] = rTipos["Nome_TipoViatura"].ToString();

                    using (SqlCommand cmdViaturas = new SqlCommand("SELECT * FROM Viatura", conn))
                    using (SqlDataReader r = cmdViaturas.ExecuteReader())
                        while (r.Read())
                        {
                            int idTipo = Convert.ToInt32(r["ID_TipoViatura"]);
                            var v = new ViaturaInfo
                            {
                                Id = Convert.ToInt32(r["ID_Viatura"]),
                                Tipo = tiposViatura.ContainsKey(idTipo) ? tiposViatura[idTipo] : "Desconhecido",
                                Matricula = r["Matricula"].ToString(),
                                Ano = r["Ano"].ToString()
                            };
                            viaturas.Add(v);
                            LBV_List.Items.Add(v);
                        }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Erro ao carregar dados: {ex.Message}"); }
        }

        private void LBV_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBV_List.SelectedIndex >= 0)
            {
                var v = viaturas[LBV_List.SelectedIndex];
                TBV1.Text = v.Matricula;
                TBV2.Text = v.Ano;
                comboBox1.SelectedItem = v.Tipo;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LBV_List.ClearSelected(); TBV1.Clear(); TBV2.Clear(); comboBox1.SelectedIndex = -1;
        }
        private void Viatura_Load(object sender, EventArgs e)
        {
            // Evento de carregamento do formulário Viatura
            CarregarDados();
        }
        private void BVReturn_Click(object sender, EventArgs e) => this.Close();

        private void BVAdd_Click(object sender, EventArgs e)
        {
            string matricula = TBV1.Text.Trim();
            string anoStr = TBV2.Text.Trim();
            string tipoSel = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(matricula) || string.IsNullOrWhiteSpace(anoStr) || string.IsNullOrWhiteSpace(tipoSel))
            { MessageBox.Show("Preencha todos os campos."); return; }

            if (!int.TryParse(anoStr, out int ano))
            { MessageBox.Show("Ano inválido."); return; }

            int idTipo = tiposViatura.FirstOrDefault(x => x.Value == tipoSel).Key;
            if (idTipo == 0) { MessageBox.Show("Tipo inválido."); return; }

            string cs = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spAdicionarViatura", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Quartel", 11111);
                        cmd.Parameters.AddWithValue("@ID_TipoViatura", idTipo);
                        cmd.Parameters.AddWithValue("@Matricula", matricula);
                        cmd.Parameters.AddWithValue("@Ano", ano);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Viatura adicionada com sucesso!");
                CarregarDados(); button1_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show($"Erro ao adicionar: {ex.Message}"); }
        }


        private void BVRem_Click(object sender, EventArgs e)
        {
            if (LBV_List.SelectedIndex < 0) { MessageBox.Show("Selecione uma viatura."); return; }
            var v = viaturas[LBV_List.SelectedIndex];
            var confirm = MessageBox.Show($"Remover viatura '{v.Matricula}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string cs = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("spRemoverViatura", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", v.Id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Viatura removida.");
                    CarregarDados();
                }
                catch (Exception ex) { MessageBox.Show($"Erro: {ex.Message}"); }
            }
        }

        private void BVEdit_Click(object sender, EventArgs e)
        {
            if (LBV_List.SelectedIndex < 0) { MessageBox.Show("Selecione uma viatura."); return; }
            var v = viaturas[LBV_List.SelectedIndex];

            string matricula = TBV1.Text.Trim();
            string anoStr = TBV2.Text.Trim();
            string tipoSel = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(matricula) || string.IsNullOrWhiteSpace(anoStr) || string.IsNullOrWhiteSpace(tipoSel))
            { MessageBox.Show("Preencha todos os campos."); return; }

            if (!int.TryParse(anoStr, out int ano))
            { MessageBox.Show("Ano inválido."); return; }

            int idTipo = tiposViatura.FirstOrDefault(x => x.Value == tipoSel).Key;
            if (idTipo == 0) { MessageBox.Show("Tipo inválido."); return; }

            string cs = "Data Source=PC-DIOGO;Initial Catalog=Teste;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spEditarViatura", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", v.Id);
                        cmd.Parameters.AddWithValue("@ID_TipoViatura", idTipo);
                        cmd.Parameters.AddWithValue("@Matricula", matricula);
                        cmd.Parameters.AddWithValue("@Ano", ano);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Viatura atualizada.");
                CarregarDados();
            }
            catch (Exception ex) { MessageBox.Show($"Erro ao atualizar: {ex.Message}"); }
        }
    }
}
