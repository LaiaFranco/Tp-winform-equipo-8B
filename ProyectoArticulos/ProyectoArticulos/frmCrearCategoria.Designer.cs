namespace ProyectoArticulos
{
    partial class frmCrearCategoria
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
            this.label1 = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crear";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(18, 144);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(265, 20);
            this.textDescripcion.TabIndex = 1;
            this.textDescripcion.TextChanged += new System.EventHandler(this.textDescripcion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion";
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(37, 271);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarCategoria.TabIndex = 3;
            this.btnAgregarCategoria.Text = "Crear";
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(170, 271);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmCrearCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAgregarCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDescripcion);
            this.Controls.Add(this.label1);
            this.Name = "frmCrearCategoria";
            this.Text = "frmCrearCategoria";
            this.Load += new System.EventHandler(this.frmCrearCategoria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.Button btnCerrar;
    }
}