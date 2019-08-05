namespace SistemaOdontologico
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDePacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeOdontologosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeConsultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeEspecialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeMaterialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeVacunasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeAlergiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDePacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeOdontologosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeConsultasMedicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeEspecialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeMaterialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeAlergiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.registrosToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desconectarseToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // desconectarseToolStripMenuItem
            // 
            this.desconectarseToolStripMenuItem.Name = "desconectarseToolStripMenuItem";
            this.desconectarseToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.desconectarseToolStripMenuItem.Text = "Desconectarse";
            this.desconectarseToolStripMenuItem.Click += new System.EventHandler(this.DesconectarseToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // registrosToolStripMenuItem
            // 
            this.registrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroDeUsuariosToolStripMenuItem,
            this.registroDePacientesToolStripMenuItem,
            this.registroDeOdontologosToolStripMenuItem,
            this.registroDeConsultasToolStripMenuItem,
            this.registroDeEspecialidadesToolStripMenuItem,
            this.registroDeMaterialesToolStripMenuItem,
            this.registroDeVacunasToolStripMenuItem,
            this.registroDeAlergiasToolStripMenuItem});
            this.registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            this.registrosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.registrosToolStripMenuItem.Text = "Registros";
            // 
            // registroDeUsuariosToolStripMenuItem
            // 
            this.registroDeUsuariosToolStripMenuItem.Name = "registroDeUsuariosToolStripMenuItem";
            this.registroDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.registroDeUsuariosToolStripMenuItem.Text = "Registro de Usuarios";
            this.registroDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.RegistroDeUsuariosToolStripMenuItem_Click);
            // 
            // registroDePacientesToolStripMenuItem
            // 
            this.registroDePacientesToolStripMenuItem.Name = "registroDePacientesToolStripMenuItem";
            this.registroDePacientesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.registroDePacientesToolStripMenuItem.Text = "Registro de Pacientes";
            this.registroDePacientesToolStripMenuItem.Click += new System.EventHandler(this.RegistroDePacientesToolStripMenuItem_Click);
            // 
            // registroDeOdontologosToolStripMenuItem
            // 
            this.registroDeOdontologosToolStripMenuItem.Name = "registroDeOdontologosToolStripMenuItem";
            this.registroDeOdontologosToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.registroDeOdontologosToolStripMenuItem.Text = "Registro de Odontologos";
            this.registroDeOdontologosToolStripMenuItem.Click += new System.EventHandler(this.RegistroDeOdontologosToolStripMenuItem_Click);
            // 
            // registroDeConsultasToolStripMenuItem
            // 
            this.registroDeConsultasToolStripMenuItem.Name = "registroDeConsultasToolStripMenuItem";
            this.registroDeConsultasToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.registroDeConsultasToolStripMenuItem.Text = "Registro de Consultas";
            this.registroDeConsultasToolStripMenuItem.Click += new System.EventHandler(this.RegistroDeConsultasToolStripMenuItem_Click);
            // 
            // registroDeEspecialidadesToolStripMenuItem
            // 
            this.registroDeEspecialidadesToolStripMenuItem.Name = "registroDeEspecialidadesToolStripMenuItem";
            this.registroDeEspecialidadesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.registroDeEspecialidadesToolStripMenuItem.Text = "Registro de Especialidades";
            this.registroDeEspecialidadesToolStripMenuItem.Click += new System.EventHandler(this.RegistroDeEspecialidadesToolStripMenuItem_Click);
            // 
            // registroDeMaterialesToolStripMenuItem
            // 
            this.registroDeMaterialesToolStripMenuItem.Name = "registroDeMaterialesToolStripMenuItem";
            this.registroDeMaterialesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.registroDeMaterialesToolStripMenuItem.Text = "Registro de Materiales";
            this.registroDeMaterialesToolStripMenuItem.Click += new System.EventHandler(this.RegistroDeMaterialesToolStripMenuItem_Click);
            // 
            // registroDeVacunasToolStripMenuItem
            // 
            this.registroDeVacunasToolStripMenuItem.Name = "registroDeVacunasToolStripMenuItem";
            this.registroDeVacunasToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.registroDeVacunasToolStripMenuItem.Text = "Registro de Vacunas";
            this.registroDeVacunasToolStripMenuItem.Click += new System.EventHandler(this.RegistroDeVacunasToolStripMenuItem_Click);
            // 
            // registroDeAlergiasToolStripMenuItem
            // 
            this.registroDeAlergiasToolStripMenuItem.Name = "registroDeAlergiasToolStripMenuItem";
            this.registroDeAlergiasToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.registroDeAlergiasToolStripMenuItem.Text = "Registro de Alergias";
            this.registroDeAlergiasToolStripMenuItem.Click += new System.EventHandler(this.RegistroDeAlergiasToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaDeToolStripMenuItem,
            this.consultaDePacientesToolStripMenuItem,
            this.consultaDeOdontologosToolStripMenuItem,
            this.consultaDeConsultasMedicasToolStripMenuItem,
            this.consultaDeEspecialidadesToolStripMenuItem,
            this.consultaDeMaterialesToolStripMenuItem,
            this.consultaDeToolStripMenuItem1,
            this.consultaDeAlergiasToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // consultaDeToolStripMenuItem
            // 
            this.consultaDeToolStripMenuItem.Name = "consultaDeToolStripMenuItem";
            this.consultaDeToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.consultaDeToolStripMenuItem.Text = "Consulta de Usuarios ";
            this.consultaDeToolStripMenuItem.Click += new System.EventHandler(this.ConsultaDeToolStripMenuItem_Click);
            // 
            // consultaDePacientesToolStripMenuItem
            // 
            this.consultaDePacientesToolStripMenuItem.Name = "consultaDePacientesToolStripMenuItem";
            this.consultaDePacientesToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.consultaDePacientesToolStripMenuItem.Text = "Consulta de Pacientes";
            this.consultaDePacientesToolStripMenuItem.Click += new System.EventHandler(this.ConsultaDePacientesToolStripMenuItem_Click);
            // 
            // consultaDeOdontologosToolStripMenuItem
            // 
            this.consultaDeOdontologosToolStripMenuItem.Name = "consultaDeOdontologosToolStripMenuItem";
            this.consultaDeOdontologosToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.consultaDeOdontologosToolStripMenuItem.Text = "Consulta de Odontologos";
            this.consultaDeOdontologosToolStripMenuItem.Click += new System.EventHandler(this.ConsultaDeOdontologosToolStripMenuItem_Click);
            // 
            // consultaDeConsultasMedicasToolStripMenuItem
            // 
            this.consultaDeConsultasMedicasToolStripMenuItem.Name = "consultaDeConsultasMedicasToolStripMenuItem";
            this.consultaDeConsultasMedicasToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.consultaDeConsultasMedicasToolStripMenuItem.Text = "Consulta de Consultas Odontologicas";
            this.consultaDeConsultasMedicasToolStripMenuItem.Click += new System.EventHandler(this.ConsultaDeConsultasMedicasToolStripMenuItem_Click);
            // 
            // consultaDeEspecialidadesToolStripMenuItem
            // 
            this.consultaDeEspecialidadesToolStripMenuItem.Name = "consultaDeEspecialidadesToolStripMenuItem";
            this.consultaDeEspecialidadesToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.consultaDeEspecialidadesToolStripMenuItem.Text = "Consulta de Especialidades";
            this.consultaDeEspecialidadesToolStripMenuItem.Click += new System.EventHandler(this.ConsultaDeEspecialidadesToolStripMenuItem_Click);
            // 
            // consultaDeMaterialesToolStripMenuItem
            // 
            this.consultaDeMaterialesToolStripMenuItem.Name = "consultaDeMaterialesToolStripMenuItem";
            this.consultaDeMaterialesToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.consultaDeMaterialesToolStripMenuItem.Text = "Consulta de Materiales";
            this.consultaDeMaterialesToolStripMenuItem.Click += new System.EventHandler(this.ConsultaDeMaterialesToolStripMenuItem_Click);
            // 
            // consultaDeToolStripMenuItem1
            // 
            this.consultaDeToolStripMenuItem1.Name = "consultaDeToolStripMenuItem1";
            this.consultaDeToolStripMenuItem1.Size = new System.Drawing.Size(273, 22);
            this.consultaDeToolStripMenuItem1.Text = "Consulta de Vacunas";
            this.consultaDeToolStripMenuItem1.Click += new System.EventHandler(this.ConsultaDeToolStripMenuItem1_Click);
            // 
            // consultaDeAlergiasToolStripMenuItem
            // 
            this.consultaDeAlergiasToolStripMenuItem.Name = "consultaDeAlergiasToolStripMenuItem";
            this.consultaDeAlergiasToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.consultaDeAlergiasToolStripMenuItem.Text = "Consulta de Alergias";
            this.consultaDeAlergiasToolStripMenuItem.Click += new System.EventHandler(this.ConsultaDeAlergiasToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SistemaOdontologico.Properties.Resources.fondo11;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido";
            this.TransparencyKey = System.Drawing.Color.White;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDePacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeOdontologosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeConsultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDePacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeEspecialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeMaterialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeOdontologosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeConsultasMedicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeEspecialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeMaterialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeVacunasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeAlergiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desconectarseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeAlergiasToolStripMenuItem;
    }
}

