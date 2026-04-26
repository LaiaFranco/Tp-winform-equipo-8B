namespace ProyectoArticulos
{
    partial class frmCategoria
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
            this.gridCategoria = new System.Windows.Forms.DataGridView();
            this.btnModificarCat = new System.Windows.Forms.Button();
            this.btnEliminarCat = new System.Windows.Forms.Button();
            this.btnCrearCat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "CATEGORIAS";
            // 
            // gridCategoria
            // 
            this.gridCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCategoria.Location = new System.Drawing.Point(76, 163);
            this.gridCategoria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridCategoria.Name = "gridCategoria";
            this.gridCategoria.RowHeadersWidth = 62;
            this.gridCategoria.Size = new System.Drawing.Size(251, 231);
            this.gridCategoria.TabIndex = 1;
            this.gridCategoria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCategoria_CellContentClick);
            // 
            // btnModificarCat
            // 
            this.btnModificarCat.Location = new System.Drawing.Point(162, 511);
            this.btnModificarCat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModificarCat.Name = "btnModificarCat";
            this.btnModificarCat.Size = new System.Drawing.Size(112, 35);
            this.btnModificarCat.TabIndex = 2;
            this.btnModificarCat.Text = "Modificar";
            this.btnModificarCat.UseVisualStyleBackColor = true;
            this.btnModificarCat.Click += new System.EventHandler(this.btnModificarCat_Click);
            // 
            // btnEliminarCat
            // 
            this.btnEliminarCat.Location = new System.Drawing.Point(298, 511);
            this.btnEliminarCat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminarCat.Name = "btnEliminarCat";
            this.btnEliminarCat.Size = new System.Drawing.Size(112, 35);
            this.btnEliminarCat.TabIndex = 3;
            this.btnEliminarCat.Text = "Eliminar";
            this.btnEliminarCat.UseVisualStyleBackColor = true;
            this.btnEliminarCat.Click += new System.EventHandler(this.btnEliminarCat_Click);
            // 
            // btnCrearCat
            // 
            this.btnCrearCat.Location = new System.Drawing.Point(27, 511);
            this.btnCrearCat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCrearCat.Name = "btnCrearCat";
            this.btnCrearCat.Size = new System.Drawing.Size(112, 35);
            this.btnCrearCat.TabIndex = 4;
            this.btnCrearCat.Text = "Crear";
            this.btnCrearCat.UseVisualStyleBackColor = true;
            this.btnCrearCat.Click += new System.EventHandler(this.btnCrearCat_Click);
            // 
            // frmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 594);
            this.Controls.Add(this.btnCrearCat);
            this.Controls.Add(this.btnEliminarCat);
            this.Controls.Add(this.btnModificarCat);
            this.Controls.Add(this.gridCategoria);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categoria";
            this.Load += new System.EventHandler(this.frmCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridCategoria;
        private System.Windows.Forms.Button btnModificarCat;
        private System.Windows.Forms.Button btnEliminarCat;
        private System.Windows.Forms.Button btnCrearCat;
    }
}