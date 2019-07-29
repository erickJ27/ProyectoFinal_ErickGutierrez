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
namespace SistemaOdontologico
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            ContrasenaTextBox.UseSystemPasswordChar = false;
        }
        private void CleanProvider()
        {
            MyErrorProvider.Clear();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            bool paso = true;
            Expression<Func<Usuarios, bool>> filtrar = x => true;
            List<Usuarios> user = new List<Usuarios>();
            Repositorio<Usuarios> db = new Repositorio<Usuarios>();

            //Repositorio<Usuarios> db = new Repositorio<Usuarios>(new DAL.FerreteriaContexto());
            var lista = new List<Usuarios>();

            CleanProvider();
            if (UsuarioTextBox.Text == string.Empty)
            {
                paso = false;
                MyErrorProvider.SetError(UsuarioTextBox, "Incorrecto");

            }
            if (ContrasenaTextBox.Text == string.Empty)
            {
                paso = false;
                MyErrorProvider.SetError(ContrasenaTextBox, "Incorrecto");

            }
            if (paso == false)
            {
                MessageBox.Show("Campos Vacios!!");
                return;
            }
            if ((UsuarioTextBox.Text == "Admin") && (ContrasenaTextBox.Text == "Admin"))
            {
                this.Hide();
                MainForm ver = new MainForm();
                ver.Show();
            }
            else
            {
                filtrar = t => t.Usuario.Equals(UsuarioTextBox.Text);
                user = db.GetList(filtrar);

                if (user.Exists(x => x.Nombres == UsuarioTextBox.Text) && user.Exists(x => x.Clave == ContrasenaTextBox.Text))
                {
                    this.Hide();
                    MainForm ver = new MainForm();
                    ver.Show();
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrecta!!");
                    MyErrorProvider.SetError(ContrasenaTextBox, "Incorrecto");
                    MyErrorProvider.SetError(UsuarioTextBox, "Incorrecto");
                }
            }
        }
    }
}
