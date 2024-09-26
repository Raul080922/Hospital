using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.Controllers;
using Login.Views.Acesos;
using Login.Views.Bodega;
using Login.Views.Financiero;
using Login.Views;
using Login.Config;

namespace Login
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_contrasenia.Text = "";
            txt_usuario.Text = "";
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            /*
            string usuario = Encriptacion.Encripta(txt_usuario.Text.Trim(),"Esta es la clave secreta");

            MessageBox.Show(usuario);

            string otrousaurio = Encriptacion.Desencripta(usuario, "Esta es la clave secreta");

            MessageBox.Show(otrousaurio);

            string otro = Encriptacion.MD5Encripter(txt_usuario.Text.Trim());
            MessageBox.Show(otro);
            
            string contrasenia = txt_contrasenia.Text.Trim();*/
            #region
              try
              {
                  UsuariosController _usuariosController = new UsuariosController();
                  var usuariomodel = _usuariosController.AutenticarUsuario(txt_usuario.Text.Trim(), txt_contrasenia.Text.Trim());
                  if (usuariomodel != null)
                  {
                      lbl_mensaje.Text = "Ingreso exitoso";
                      this.Hide();

                      ConfiguracionProyecto.IDusuario = (int)usuariomodel.ID;
                      ConfiguracionProyecto.usuario = usuariomodel.NombreUsuario;
                      ConfiguracionProyecto.rol = usuariomodel.Roles;


                      Dashboard _dashboard = new Dashboard();
                      this.Hide();
                      _dashboard.Show();
                      /*
                      if (usuariomodel.Roles == "Admin")
                      {
                          Dashboard _dashboard = new Dashboard();
                          this.Hide();
                          _dashboard.Show();
                      }
                      else if (usuariomodel.Roles == "Guardia")
                      {
                          var _accesos = new frm_Accesos_Principal();
                          _accesos.Show();
                      }
                      else if (usuariomodel.Roles == "Financiero")
                      {
                          //financiero
                          var _fiananciero = new frm_Financiero_Principal();
                          _fiananciero.Show();
                      }
                      else if (usuariomodel.Roles == "Bodega")
                      {
                          var _bodega = new frm_Bodega_Principal();
                          _bodega.Show();
                      }
                      else {
                          lbl_mensaje.Text = "Usted no posee el nivel de acceso necesario";
                      }
                  }
                  else
                  {
                      lbl_mensaje.Text = "El usuario o la contraseña son incorrectos";
                      txt_contrasenia.Text = "";
                      txt_usuario.Text = "";
                  }*/
            }

            }
        catch (Exception)
        {

            throw;
        }
            #endregion
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
