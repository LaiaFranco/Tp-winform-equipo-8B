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
            try
            {
                if (marca == null)
                   marca = new Marca();

                marca.Descripcion = txtMarca.Text.ToUpper();
                negocio.Agregar(marca);

                MessageBox.Show("Agregado exitosamente");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
