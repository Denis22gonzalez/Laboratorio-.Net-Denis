using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using SistemaPOSTPizzeria.Presentation.Models;

namespace SistemaPOSTPizzeria.Presentation
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

   

        //private async void btnLogin_Click(object sender, EventArgs e)
        //{
        //    var client = new HttpClient();
        //    var usuario = new usuario_ViewModel() { UsuarioNombre=txtUser.Text,UsuarioPassword=txtPassword.Text};

           

        //    var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
        //    var response1 = await client.PostAsync("https://localhost:44323/api/Authentication/Login", content);
        //    var json_respuesta1 = await response1.Content.ReadAsStringAsync();

        //    var ob_respuesta = JsonConvert.DeserializeObject<response_ViewModel>(json_respuesta1);
        //    if (ob_respuesta.Token!="")
        //    {
        //        FrmInicio Inicio = new FrmInicio();
        //        this.Hide();
        //        Inicio.Show();
        //    }
        //    else
        //    {

        //    }
        //}

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var usuario = new usuario_ViewModel() { UsuarioNombre = txtUser.Text, UsuarioPassword = txtPassword.Text };



            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response1 = await client.PostAsync(ApiPort.UrlBase+"/api/Authentication/Login", content);
            var json_respuesta1 = await response1.Content.ReadAsStringAsync();

            var ob_respuesta = JsonConvert.DeserializeObject<response_ViewModel>(json_respuesta1);
            if (ob_respuesta.Token != "")
            {
                TokenManager.JwtToken = ob_respuesta.Token;
                FrmInicio Inicio = new FrmInicio();
                this.Hide();
                
                Inicio.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmRegistroUser frmregistro = new FrmRegistroUser();
            this.Hide();

            frmregistro.Show();
        }
    }
}
