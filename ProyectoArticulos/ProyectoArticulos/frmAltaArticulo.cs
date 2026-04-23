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
using System.Xml.Linq;

namespace ProyectoArticulos
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }
        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            cargarComboMarca();
            cargarComboCategoria();

            ArticuloNegocio artNegocio = new ArticuloNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            try
            {
                cmbNMarca.DataSource = marcaNegocio.listar();
                cmbNMarca.ValueMember = "Id";
                cmbNMarca.DisplayMember = "Descripcion";

                cmbCategoria.DataSource = catNegocio.listar();
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.CodigoDeArtculo.ToString();
                    txtNombre.Text = articulo.Nombre.ToString();
                    txtDescripcion.Text = articulo.Descripcion.ToString();
                    txtURLImagen.Text = articulo.Imagen.UrlImagen;
                    cargarImagen(articulo.Imagen.UrlImagen);
                    cmbNMarca.SelectedValue = articulo.Marca.Id;
                    cmbCategoria.SelectedValue = articulo.Categoria.Id;
                    txtPrecio.Text = articulo.Precio.ToString(); 
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarComboMarca()
        {
            MarcaNegocio negocio = new MarcaNegocio(); 
            cmbNMarca.DataSource = negocio.listar();
            cmbNMarca.DisplayMember = "Descripcion";
            cmbNMarca.ValueMember = "Id"; 
        }

        private void cargarComboCategoria()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            cmbCategoria.DataSource = negocio.listar();
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.ValueMember = "Id"; 
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir backspace
            if (e.KeyChar == (char)8)
                return;

            // Permitir un solo separador decimal (coma o punto)
            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                !txtPrecio.Text.Contains(",") &&
                !txtPrecio.Text.Contains("."))
                return;

            // Bloquear todo lo demás
            e.Handled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (articulo == null) 
                    articulo = new Articulo();

                articulo.CodigoDeArtculo = txtCodigo.Text.ToUpper();
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                if (articulo.Imagen == null)
                    articulo.Imagen = new Imagen(); 
                articulo.Imagen.UrlImagen = txtURLImagen.Text;
                articulo.Marca = (Marca)cmbNMarca.SelectedItem;
                articulo.Categoria = (Categoria)cmbCategoria.SelectedItem;
               
                    articulo.Precio = decimal.Parse(txtPrecio.Text);
                
                

                if (articulo.Id != 0)
                {
                    negocio.Modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.Agregar(articulo);

                    AccesoDatos datos = new AccesoDatos();
                    datos.setearConsulta("SELECT MAX(Id) FROM ARTICULOS");
                    int idArt = (int)datos.EjecutarScalar();

                    if (!string.IsNullOrEmpty(txtURLImagen.Text))
                    {
                        AccesoDatos datosImg = new AccesoDatos();
                        datosImg.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @url)");
                        datosImg.setearParametro("@idArticulo", idArt);
                        datosImg.setearParametro("@url", txtURLImagen.Text);
                        datosImg.ejecutarAccion();
                    }

                    MessageBox.Show("Agregado exitosamente");
                }
                Close(); 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();

            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception)
            {
               pbxImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtURLImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);

                //guardo la imagen
                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
            }

        }

        private void txtURLImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtURLImagen.Text);
        }
    }
}
