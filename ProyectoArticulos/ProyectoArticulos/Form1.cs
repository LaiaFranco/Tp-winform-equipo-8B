using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoArticulos
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void lblBienvenidos_Click(object sender, EventArgs e)
        {

        }

        private void lblBienvenidos2_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmOpciones opciones = new frmOpciones();
            opciones.ShowDialog();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
