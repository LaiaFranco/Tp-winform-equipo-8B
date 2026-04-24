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

        private Categoria categoria = null;


        public frmCrearCategoria()
        {
            InitializeComponent();
        }

        public frmCrearCategoria(Categoria cat)
        {
            InitializeComponent();
            categoria = cat;
            Text = "Modificar Categoria";
        }

        private void textDescripcion_TextChanged(object sender, EventArgs e)
        {

            EnableButton();
           
        }

        private void frmCrearCategoria_Load(object sender, EventArgs e)
        {
            EnableButton();

            if (categoria != null)
            {
                textDescripcion.Text = categoria.Descripcion;
            }
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
           
            CategoriaNegocio CatNego = new CategoriaNegocio();

            if (categoria == null)
            {
                Categoria Cat = new Categoria();
                Cat.Descripcion = textDescripcion.Text;

                CatNego.Agregar(Cat);

                textDescripcion.Text = "";

                MessageBox.Show("Categoria creada exitosamente");
            }
            
              

            if (categoria != null)
            {

                categoria.Descripcion = textDescripcion.Text;

                CatNego.Actualizar(categoria);


                MessageBox.Show("Categoria actulizada exitosamente");
            }
 
      
            Close();
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
