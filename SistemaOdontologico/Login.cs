using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using BLL;
using DAL;
namespace SistemaOdontologico
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void Logins()
        {
            Repositorio<Usuarios> Repositorio = new Repositorio<Usuarios>();
            Expression<Func<Usuarios, bool>> filtro = x => true;
            List<Usuarios> usuario = new List<Usuarios>();
            var username = UsuarioTextBox.Text;
            var password = ContrasenaTextBox.Text;
            filtro = x => x.Usuario.Equals(username);
            usuario = Repositorio.GetList(filtro);

            if (usuario.Exists(x => x.Usuario.Equals(username)))
            {
                if (usuario.Exists(x => x.Clave.Equals(Eramake.eCryptography.Encrypt(password))))
                {
                    List<Usuarios> id = Repositorio.GetList(U => U.Usuario == UsuarioTextBox.Text);
                    MainForm f = new MainForm(id[0].UsuarioId);
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Clave incorrecta.", "Clinica Dental Dr. Gutierrez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (UsuarioTextBox.Text == string.Empty || ContrasenaTextBox.Text == string.Empty)
                    MessageBox.Show("Ingrese en todos los campos.", "Clinica Dental Dr. Gutierrez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!usuario.Exists(x => x.Usuario.Equals(username)))
                    MessageBox.Show("Usuario no existe.", "Clinica Dental Dr. Gutierrez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Logins();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Repositorio<Usuarios> Repositorio = new Repositorio<Usuarios>();
            List<Usuarios> user = new List<Usuarios>();
            user = Repositorio.GetList(p => true);
            if (user.Count == 0)
            {
                Repositorio.Guardar(new Usuarios()
                {
                    Usuario = "admin",
                    Clave = Eramake.eCryptography.Encrypt("admin"),
                    Nombres = "Erick Josue",
                    Email = "ErickJosue@admin.com",
                    FechaIngreso = DateTime.Now
                });
                MessageBox.Show(this, "Al no existir usuario(s) se ha creado uno por defecto.", "Clinica Dental Dr. Gutierrez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (MostrarCCheckBox.Checked == false)
                ContrasenaTextBox.UseSystemPasswordChar = true;
            else
                ContrasenaTextBox.UseSystemPasswordChar = false;

        }
    }
}
