using negocio;
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

namespace ProyectoArticulos
{
    public partial class frmOpcionesMarca : Form
    {
        private List<Marca> listaMarcas; 
        public frmOpcionesMarca()
        {
            InitializeComponent();
        }
        private void cargar()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                listaMarcas = negocio.listar();
                dgvMarca.DataSource = listaMarcas; 

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private void frmOpcionesMarca_Load(object sender, EventArgs e)
        {
            cargar(); 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmAltaMarca altaMarca = new frmAltaMarca();
            altaMarca.ShowDialog(this);
        }
    }
}
