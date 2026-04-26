using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoArticulos
{
    public partial class frmOpciones : Form
    {
        private List<Articulo> listaArticulos;
        private ImagenNegocio imgNegocio = new ImagenNegocio();
        private List<Imagen> imagenesDelArticuloActual;

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

                if (listaArticulos.Count > 0)
                {
                    Articulo artInit = listaArticulos[0];
                    dgvArticulos.Rows[0].Selected = true;
                    cargarImagen(artInit.Imagen?.UrlImagen);
                    cargarComboImagenes(artInit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarComboImagenes(Articulo articulo)
        {
            if (articulo == null) return;
            imagenesDelArticuloActual = imgNegocio.ListarPorArticulo(articulo);
            var items = imagenesDelArticuloActual.Select((img, idx) => new { Id = img.Id, Display = $"Imagen {idx + 1}" }).ToList();

            selectImg.DataSource = items;
            selectImg.DisplayMember = "Display";
            selectImg.ValueMember = "Id";

            if (selectImg.Items.Count > 0)
                selectImg.SelectedIndex = 0;
        }

        private void cargarImagen(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                    pctImagen.Load(url);
                else
                    pctImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
            catch
            {
                pctImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Imagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
        }

        private Articulo ObtenerArticuloActual()
        {
            if (dgvArticulos.CurrentRow != null)
                return (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            return listaArticulos?.Count > 0 ? listaArticulos[0] : null;
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = ObtenerArticuloActual();
            if (seleccionado != null)
            {
                cargarImagen(seleccionado.Imagen?.UrlImagen);
                cargarComboImagenes(seleccionado);
            }
        }

        private void selectImg_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (selectImg.SelectedValue != null && imagenesDelArticuloActual != null)
            {
                int idSeleccionado = (int)selectImg.SelectedValue;
                Imagen img = imagenesDelArticuloActual.FirstOrDefault(i => i.Id == idSeleccionado);
                if (img != null)
                    cargarImagen(img.UrlImagen);
            }
        }

        private void frmOpciones_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.AddRange(new[] { "Cod.Articulo", "Nombre", "Descripcion", "Marca", "Categoria", "Precio" });
            selectImg.SelectedIndexChanged += selectImg_SelectedIndexChanged;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = ObtenerArticuloActual();
            if (seleccionado != null)
            {
                frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
                modificar.ShowDialog(this);
                cargar();
            }
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void eliminar(bool logico = false)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = ObtenerArticuloActual();
            if (articulo == null) return;

            DialogResult respuesta = MessageBox.Show("¿Estás seguro/a de querer eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                negocio.Eliminar(articulo.Id);
                cargar();
            }
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char c in cadena)
                if (!char.IsDigit(c)) return false;
            return true;
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el campo para filtrar.");
                return true;
            }
            if (cblCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el criterio para filtrar.");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtFiltro.Text) || !soloNumeros(txtFiltro.Text))
                {
                    MessageBox.Show("Debe ingresar un número válido para el filtro de precio.");
                    return true;
                }
            }
            return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validarFiltro()) return;
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                dgvArticulos.DataSource = negocio.filtrar(
                    cboCampo.SelectedItem.ToString(),
                    cblCriterio.SelectedItem.ToString(),
                    txtFiltro.Text);
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCampo.SelectedItem == null) return;
            cblCriterio.Items.Clear();
            if (cboCampo.SelectedItem.ToString() == "Precio")
                cblCriterio.Items.AddRange(new[] { "Mayor a", "Menor a", "Igual a" });
            else
                cblCriterio.Items.AddRange(new[] { "Comienza con", "Termina con", "Igual a", "Contiene" });
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAltaMarca().ShowDialog(this);
        }

        private void marcaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmOpcionesMarca().ShowDialog(this);
        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmCategoria().ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmAltaArticulo().ShowDialog(this);
            cargar();
        }

            private void btnNuevaImagen_Click(object sender, EventArgs e)
            {
                Articulo articulo = ObtenerArticuloActual();
                if (articulo != null)
                {
                    frmNuevaImg nuevaImg = new frmNuevaImg(articulo);
                    nuevaImg.ShowDialog(this);
                    cargar();
                }
            }
    }
}