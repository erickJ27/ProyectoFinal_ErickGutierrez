namespace SistemaOdontologico.Registros
{
    partial class rAlergias
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rAlergias));
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.IdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.Location = new System.Drawing.Point(96, 43);
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(191, 20);
            this.DescripcionTextBox.TabIndex = 61;
            this.DescripcionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescripcionTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Descripcion";
            // 
            // EliminarButton
            // 
            this.EliminarButton.Image = global::SistemaOdontologico.Properties.Resources.Close_2_icon1;
            this.EliminarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EliminarButton.Location = new System.Drawing.Point(212, 83);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(67, 23);
            this.EliminarButton.TabIndex = 57;
            this.EliminarButton.Text = "Eliminar";
            this.EliminarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EliminarButton.UseVisualStyleBackColor = true;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // IdNumericUpDown
            // 
            this.IdNumericUpDown.Location = new System.Drawing.Point(96, 16);
            this.IdNumericUpDown.Name = "IdNumericUpDown";
            this.IdNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.IdNumericUpDown.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "Id";
            // 
            // NuevoButton
            // 
            this.NuevoButton.Image = global::SistemaOdontologico.Properties.Resources.new_file_icon1;
            this.NuevoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NuevoButton.Location = new System.Drawing.Point(16, 83);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(64, 23);
            this.NuevoButton.TabIndex = 59;
            this.NuevoButton.Text = "Nuevo";
            this.NuevoButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Image = global::SistemaOdontologico.Properties.Resources.Save_icon1;
            this.GuardarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GuardarButton.Location = new System.Drawing.Point(111, 83);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(70, 23);
            this.GuardarButton.TabIndex = 58;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::SistemaOdontologico.Properties.Resources.search3_icon;
            this.BuscarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuscarButton.Location = new System.Drawing.Point(222, 13);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(65, 23);
            this.BuscarButton.TabIndex = 55;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // rAlergias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 126);
            this.Controls.Add(this.DescripcionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NuevoButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.IdNumericUpDown);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "rAlergias";
            this.Text = "Registro de Alergias";
            ((System.ComponentModel.ISupportInitialize)(this.IdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NuevoButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.NumericUpDown IdNumericUpDown;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
    }
}