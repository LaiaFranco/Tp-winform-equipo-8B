using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;

namespace ProyectoArticulos
{
    public partial class frmCrearCategoria : Form
    {


        public frmCrearCategoria()
        {
            InitializeComponent();
        }

        private void textDescripcion_TextChanged(object sender, EventArgs e)
        {

            EnableButton();
        }

        private void frmCrearCategoria_Load(object sender, EventArgs e)
        {
            EnableButton();
        }


        private void EnableButton()
        {
            if (textDescripcion.Text == "")
            {
                btnAgregarCategoria.Enabled = false;

            }

            if (textDescripcion.Text != "")
            {
                btnAgregarCategoria.Enabled = true;

            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Categoria Cat = new Categoria();
            CategoriaNegocio CatNego = new CategoriaNegocio();

            Cat.Descripcion = textDescripcion.Text;

            CatNego.Agregar(Cat);

            textDescripcion.Text = "";

            MessageBox.Show("Categoria creada exitosamente");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
