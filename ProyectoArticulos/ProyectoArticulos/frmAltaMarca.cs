using dominio;
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
    public partial class frmAltaMarca : Form
    {
        private Marca marca = null; 
        public frmAltaMarca()
        {
            InitializeComponent();
        }
        public frmAltaMarca(Marca nuevo)
        {
            InitializeComponent();
            marca = nuevo;
            Text = "Modificar Marca";
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            if (marca == null)
            {
                Marca mar = new Marca();
                mar.Descripcion = txtMarca.Text;

                negocio.Agregar(mar);

                txtMarca.Text = "";

                MessageBox.Show("Marca creada exitosamente");
            }
            if (marca != null)
            {

                marca.Descripcion = txtMarca.Text;

                negocio.Modificar(marca);


                MessageBox.Show("Marca actulizada exitosamente");
            }


            Close();


        }

        

        private void EnableButton()
        {
            if(txtMarca.Text == "")
            {
                btnAgregar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = true; 
            }

        }

        private void frmAltaMarca_Load(object sender, EventArgs e)
        {
            EnableButton(); 
            if(marca != null)
            {
                txtMarca.Text = marca.Descripcion; 
            }

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            EnableButton();

        }
    }
}
