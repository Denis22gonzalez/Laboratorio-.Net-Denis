using Newtonsoft.Json;
using SistemaPOSTPizzeria.Presentation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPOSTPizzeria.Presentation
{
    public partial class FrmProductos_Acciones : Form
    {
        private productos_ViewModel _model;
        public FrmProductos_Acciones(productos_ViewModel model)
        {
            _model = model;
            InitializeComponent();
            setCampos();
        }


        private void FrmProductos_Acciones_Load(object sender, EventArgs e)
        {

        }

        public void setCampos()
        {
            txtNombre.Text = _model.Producto_Nombre;
            txtDescripcion.Text = _model.Producto_Descripcion;
            txtPrecio.Text= _model.Producto_Precio.ToString();
            txtStock.Text = _model.Producto_Stok.ToString();
           
        }

        //editar
        private async void button1_Click(object sender, EventArgs e)
        {
            var modelActualizar = new productos_ViewModel();
            modelActualizar.Producto_Id = _model.Producto_Id;
            modelActualizar.Producto_Nombre = txtNombre.Text;
            modelActualizar.Producto_Descripcion = txtDescripcion.Text;
            modelActualizar.Producto_Precio = Convert.ToDecimal(txtPrecio.Text);
            modelActualizar.Producto_Stok = Convert.ToInt32(txtStock.Text);
            modelActualizar.Producto_Imagen = "_";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.JwtToken);

            var jsonContent = JsonConvert.SerializeObject(modelActualizar);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(ApiPort.UrlBase + "/api/Producto/Update", contentString);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Producto actualizado con éxito.");
                FrmProductos frmProductos = new FrmProductos();
                this.Hide();
                frmProductos.Show();
            }
        }

        //delete
        private async void button2_Click(object sender, EventArgs e)
        {
            var IdSendDelete = _model.Producto_Id;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.JwtToken);

            var response = await client.DeleteAsync(ApiPort.UrlBase +$"/api/Producto/Delete?id={IdSendDelete}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Producto eliminado con éxito.");
                FrmProductos frmProductos = new FrmProductos();
                this.Hide();
                frmProductos.Show();
            }
            else
            {
                MessageBox.Show($"Error al eliminar el producto: {response.ReasonPhrase}");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmProductos frmPro = new FrmProductos();
            this.Hide();
            frmPro.Show();
        }
    }
}
