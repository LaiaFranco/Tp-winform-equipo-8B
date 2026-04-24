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
    public partial class frmCategoria : Form
    {
  
        private CategoriaNegocio CatNegocio = new CategoriaNegocio();
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            gridCategoria.DataSource = CatNegocio.listar();
            gridCategoria.Columns["Id"].Visible = false;
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnModificarCat_Click(object sender, EventArgs e)
        {
            Categoria seleccionado;
            seleccionado = (Categoria)gridCategoria.CurrentRow.DataBoundItem;

            frmCrearCategoria modificar = new frmCrearCategoria(seleccionado);
            modificar.ShowDialog(this);

        }

        private void btnCrearCat_Click(object sender, EventArgs e)
        {
            frmCrearCategoria modificar = new frmCrearCategoria();
            modificar.ShowDialog(this);
           
        }

        private void btnEliminarCat_Click(object sender, EventArgs e)
        {
            Categoria seleccionado;
            seleccionado = (Categoria)gridCategoria.CurrentRow.DataBoundItem;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Estas seguro/a de querer eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    CatNegocio.Eliminar(seleccionado.Id);
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
