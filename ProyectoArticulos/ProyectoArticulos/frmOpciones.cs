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
    public partial class frmOpciones : Form
    {
        private List<Articulo> listaArticulos;
        public frmOpciones()
        {
            InitializeComponent();
        }
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                listaArticulos = negocio.Listar();
                dgvArticulos.DataSource = listaArticulos;
                ocultarColumnas();
                cargarImagen(listaArticulos[0].Imagen.UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void bntEliminar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAltaArticulo altaArticulo = new frmAltaArticulo();
            altaArticulo.ShowDialog(this);
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.Imagen.UrlImagen);
            }

        }


        private void frmOpciones_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Cod.Articulo");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");
            cboCampo.Items.Add("Precio");

        }


        private void cargarImagen(string imagen)
        {
            try
            {
                pctImagen.Load(imagen);
            }
            catch (Exception)
            {
                pctImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Imagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
        }

       
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
            modificar.ShowDialog(this);
            cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar(true); 

        }
        private void eliminar(bool logico = false)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Estas seguro/a de querer eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    negocio.Eliminar(articulo.Id);
                    cargar(); 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }
        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar.");
                return true;
            }
            if (cblCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar.");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtFiltro.Text))
                {
                    MessageBox.Show("Debes cargar el filtro para numéricos...");
                    return true;
                }
                if (!(soloNumeros(txtFiltro.Text)))
                {
                    MessageBox.Show("Solo nros para filtrar por un campo numérico...");
                    return true;
                }

            }

            return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cblCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;
                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void cblCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCampo.SelectedItem == null)
                return;

            string opcion = cboCampo.SelectedItem.ToString(); 

            cblCriterio.Items.Clear();
            if(opcion == "Precio")
            {
                cblCriterio.Items.Add("Mayor a");
                cblCriterio.Items.Add("Menor a");
                cblCriterio.Items.Add("Igual a"); 
            }else
            {
              
                cblCriterio.Items.Add("Comienza con");
                cblCriterio.Items.Add("Termina con");
                cblCriterio.Items.Add("Igual a");
                cblCriterio.Items.Add("Contiene");
            }


        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaMarca altaMarca = new frmAltaMarca();
            altaMarca.ShowDialog(this); 
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}
