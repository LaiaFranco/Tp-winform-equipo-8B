namespace ProyectoArticulos
{
    partial class frmOpciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpciones));
            this.pctOpciones = new System.Windows.Forms.PictureBox();
            this.btnListado = new System.Windows.Forms.Button();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.bntEliminar = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctOpciones)).BeginInit();
            this.SuspendLayout();
            // 
            // pctOpciones
            // 
            this.pctOpciones.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pctOpciones.ErrorImage")));
            this.pctOpciones.Image = ((System.Drawing.Image)(resources.GetObject("pctOpciones.Image")));
            this.pctOpciones.InitialImage = ((System.Drawing.Image)(resources.GetObject("pctOpciones.InitialImage")));
            this.pctOpciones.Location = new System.Drawing.Point(-2, 0);
            this.pctOpciones.Name = "pctOpciones";
            this.pctOpciones.Size = new System.Drawing.Size(785, 288);
            this.pctOpciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctOpciones.TabIndex = 0;
            this.pctOpciones.TabStop = false;
            // 
            // btnListado
            // 
            this.btnListado.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnListado.Location = new System.Drawing.Point(567, 314);
            this.btnListado.Name = "btnListado";
            this.btnListado.Size = new System.Drawing.Size(129, 55);
            this.btnListado.TabIndex = 1;
            this.btnListado.Text = "Listado";
            this.btnListado.UseVisualStyleBackColor = false;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBusqueda.Location = new System.Drawing.Point(325, 314);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(129, 55);
            this.btnBusqueda.TabIndex = 2;
            this.btnBusqueda.Text = "Busqueda";
            this.btnBusqueda.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnModificar.Location = new System.Drawing.Point(70, 419);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(129, 52);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAgregar.Location = new System.Drawing.Point(70, 314);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(124, 55);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // bntEliminar
            // 
            this.bntEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bntEliminar.Location = new System.Drawing.Point(325, 416);
            this.bntEliminar.Name = "bntEliminar";
            this.bntEliminar.Size = new System.Drawing.Size(129, 55);
            this.bntEliminar.TabIndex = 5;
            this.bntEliminar.Text = "Eliminar";
            this.bntEliminar.UseVisualStyleBackColor = false;
            this.bntEliminar.Click += new System.EventHandler(this.bntEliminar_Click);
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVerDetalle.Location = new System.Drawing.Point(567, 416);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(129, 55);
            this.btnVerDetalle.TabIndex = 6;
            this.btnVerDetalle.Text = "VerDetalle";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            // 
            // frmOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(783, 568);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.bntEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnListado);
            this.Controls.Add(this.pctOpciones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOpciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones";
            ((System.ComponentModel.ISupportInitialize)(this.pctOpciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctOpciones;
        private System.Windows.Forms.Button btnListado;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button bntEliminar;
        private System.Windows.Forms.Button btnVerDetalle;
    }
}