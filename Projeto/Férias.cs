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
    public partial class Férias : Form
    {
        public Férias()
        {
            InitializeComponent();
        }

        private void BFeriasVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
