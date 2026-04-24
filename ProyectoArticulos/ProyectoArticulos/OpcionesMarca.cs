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
        MarcaNegocio negocio = new MarcaNegocio(); 
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
                dgvMarca.Columns["Id"].Visible = false; 

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Marca marca;
            marca = (Marca)dgvMarca.CurrentRow.DataBoundItem;
            frmAltaMarca modificar = new frmAltaMarca();
            modificar.ShowDialog(this);
            cargar(); 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Marca seleccionado;
            seleccionado = (Marca)dgvMarca.CurrentRow.DataBoundItem;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Estas seguro/a de querer eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    negocio.Eliminar(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
