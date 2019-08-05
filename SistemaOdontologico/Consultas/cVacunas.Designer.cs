namespace SistemaOdontologico.Consultas
{
    partial class cVacunas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cVacunas));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CriterioTextBox = new System.Windows.Forms.TextBox();
            this.FiltroComboBox = new System.Windows.Forms.ComboBox();
            this.VacunasDataGridView = new System.Windows.Forms.DataGridView();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.ImprimirButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VacunasDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.CriterioTextBox);
            this.groupBox2.Controls.Add(this.FiltroComboBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 55);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Filtro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Criterio";
            // 
            // CriterioTextBox
            // 
            this.CriterioTextBox.Location = new System.Drawing.Point(134, 28);
            this.CriterioTextBox.Name = "CriterioTextBox";
            this.CriterioTextBox.Size = new System.Drawing.Size(113, 20);
            this.CriterioTextBox.TabIndex = 31;
            // 
            // FiltroComboBox
            // 
            this.FiltroComboBox.FormattingEnabled = true;
            this.FiltroComboBox.Items.AddRange(new object[] {
            "Todo",
            "Id",
            "Descripcion"});
            this.FiltroComboBox.Location = new System.Drawing.Point(7, 27);
            this.FiltroComboBox.Name = "FiltroComboBox";
            this.FiltroComboBox.Size = new System.Drawing.Size(121, 21);
            this.FiltroComboBox.TabIndex = 17;
            // 
            // VacunasDataGridView
            // 
            this.VacunasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VacunasDataGridView.Location = new System.Drawing.Point(13, 73);
            this.VacunasDataGridView.Name = "VacunasDataGridView";
            this.VacunasDataGridView.Size = new System.Drawing.Size(337, 280);
            this.VacunasDataGridView.TabIndex = 48;
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Image = global::SistemaOdontologico.Properties.Resources.Microsoft_Query_icon;
            this.ConsultarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConsultarButton.Location = new System.Drawing.Point(273, 37);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(77, 23);
            this.ConsultarButton.TabIndex = 50;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // ImprimirButton
            // 
            this.ImprimirButton.Image = global::SistemaOdontologico.Properties.Resources.print_icon;
            this.ImprimirButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImprimirButton.Location = new System.Drawing.Point(281, 359);
            this.ImprimirButton.Name = "ImprimirButton";
            this.ImprimirButton.Size = new System.Drawing.Size(69, 23);
            this.ImprimirButton.TabIndex = 49;
            this.ImprimirButton.Text = "Imprimir";
            this.ImprimirButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ImprimirButton.UseVisualStyleBackColor = true;
            this.ImprimirButton.Click += new System.EventHandler(this.ImprimirButton_Click);
            // 
            // cVacunas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 388);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ConsultarButton);
            this.Controls.Add(this.ImprimirButton);
            this.Controls.Add(this.VacunasDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "cVacunas";
            this.Text = "Consulta de Vacunas";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VacunasDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CriterioTextBox;
        private System.Windows.Forms.ComboBox FiltroComboBox;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.Button ImprimirButton;
        private System.Windows.Forms.DataGridView VacunasDataGridView;
    }
}