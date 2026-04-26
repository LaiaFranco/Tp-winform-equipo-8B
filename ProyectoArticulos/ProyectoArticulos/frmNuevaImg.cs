using dominio;
using negocio;
using System;
using System.Windows.Forms;

namespace ProyectoArticulos
{
    public partial class frmNuevaImg : Form
    {
        private Articulo articuloActual;

        public frmNuevaImg()
        {
            InitializeComponent();
        }

        public frmNuevaImg(Articulo articulo)
        {
            InitializeComponent();
            articuloActual = articulo;
        }

        private void frmNuevaImg_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            cbxCodigo.DataSource = negocio.listarIdxCodigo();
            cbxCodigo.DisplayMember = "CodigoDeArtculo";
            cbxCodigo.ValueMember = "Id";

            if (articuloActual != null)
                cbxCodigo.SelectedValue = articuloActual.Id;

            EnableButton();
        }

        private void EnableButton()
        {
            btnGuardar.Enabled = !string.IsNullOrWhiteSpace(txturlmg.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txturlmg.Text))
            {
                MessageBox.Show("Debe ingresar una URL de imagen.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ImagenNegocio negocio = new ImagenNegocio();
            try
            {
                Imagen imagen = new Imagen
                {
                    UrlImagen = txturlmg.Text.Trim(),
                    IdArticulo = (int)cbxCodigo.SelectedValue
                };

                negocio.agregar(imagen);
                MessageBox.Show("Imagen agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txturlmg_TextChanged(object sender, EventArgs e)
        {
            EnableButton();
        }
        private void cbxCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}