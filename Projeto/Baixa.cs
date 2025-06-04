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
    public partial class Baixa : Form
    {
        public Baixa()
        {
            InitializeComponent();
        }

        private void BBaixaVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
