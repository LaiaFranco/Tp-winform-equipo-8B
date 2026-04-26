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
    public partial class frmNuevaImg : Form
    {
 
        
        public frmNuevaImg()
        {
            InitializeComponent();
        }

        private void frmNuevaImg_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            cbxCodigo.DataSource = negocio.listarIdxCodigo();
            cbxCodigo.DisplayMember = "CodigoDeArtculo";
            cbxCodigo.ValueMember = "Id";
        }

        public void EnableButton()
        {
            if (txturlmg.Text == "")
                btnGuardar.Enabled = false; 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ImagenNegocio negocio = new ImagenNegocio();

            try
            {
               

                     Imagen  imagen = new Imagen();

                    imagen.UrlImagen = txturlmg.Text;
                    imagen.IdArticulo = (int)cbxCodigo.SelectedValue;
                    negocio.agregar(imagen);
                    MessageBox.Show("Se agrego exitosamente!");

              

            }
            catch (Exception ex)
            {

                throw ex;
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
