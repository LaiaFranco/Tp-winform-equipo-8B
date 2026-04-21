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
        private List<Articulo>listaArticulos; 
        public frmOpciones()
        {
            InitializeComponent();
        }
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try { 
            
           
                dgvArticulos.DataSource = negocio.Listar();
               
                //ocultarColumnas();
                //cargarImagen(listaPokemon[0].UrlImagen);
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

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            // Evento reservado para carga de imagen/acciones futuras.
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmOpciones_Load(object sender, EventArgs e)
        {
            cargar();  
        }
    }
}
