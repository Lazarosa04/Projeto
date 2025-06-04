using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Quartel : Form
    {
        public Quartel()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BOcor_Click(object sender, EventArgs e)
        {
            Ocorrencias ocorrencias = new Ocorrencias();
            ocorrencias.ShowDialog();
        }

        private void BViat_Click(object sender, EventArgs e)
        {
            Viatura viatura = new Viatura();
            viatura.ShowDialog(); 
        }

        private void BBomb_Click(object sender, EventArgs e)
        {
            Bombeiro bombeiro = new Bombeiro();
            bombeiro.ShowDialog();
        }

        private void BEquip_Click(object sender, EventArgs e)
        {
            Equipamento equipamento = new Equipamento();
            equipamento.ShowDialog();
        }

        private void Quartel_Load(object sender, EventArgs e)
        {

        }


        private void BChamadas_Click_1(object sender, EventArgs e)
        {
            Chamada chamada = new Chamada();
            chamada.ShowDialog();
        }
    }
}
