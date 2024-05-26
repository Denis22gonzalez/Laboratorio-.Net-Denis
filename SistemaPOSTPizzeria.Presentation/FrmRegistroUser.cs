using Newtonsoft.Json;
using SistemaPOSTPizzeria.Presentation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPOSTPizzeria.Presentation
{
    public partial class FrmRegistroUser : Form
    {
        public FrmRegistroUser()
        {
            InitializeComponent();
        }

        private async void btnRegistroUser_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var usuario = new usuario_ViewModel() { UsuarioNombre = txtNombreRegistro.Text, UsuarioPassword = txtPasswordRegistro.Text };



            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response1 = await client.PostAsync(ApiPort.UrlBase + "/api/Authentication/Registrar", content);
            var json_respuesta1 = await response1.Content.ReadAsStringAsync();

            //var ob_respuesta = JsonConvert.DeserializeObject<response_ViewModel>(json_respuesta1);
            if (json_respuesta1!= "")
            {
                
                FrmLogin frmlogin = new FrmLogin();
                MessageBox.Show("Listo, ahora puedes iniciar sesion");
                this.Hide();

                frmlogin.Show();
            }
            else
            {

            }
        }
    }
}
