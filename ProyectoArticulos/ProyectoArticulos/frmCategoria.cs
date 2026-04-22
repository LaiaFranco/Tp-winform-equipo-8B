using negocio;
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
    public partial class frmCategoria : Form
    {

        private CategoriaNegocio CatNegocio = new CategoriaNegocio();
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            gridCategoria.DataSource = CatNegocio.listar();
            gridCategoria.Columns["Id"].Visible = false;
        }
    }
}
