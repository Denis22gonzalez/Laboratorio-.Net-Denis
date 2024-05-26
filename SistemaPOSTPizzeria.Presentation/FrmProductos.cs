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
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
            LoadProduct();
            Ocultar();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {

        }
        private async void LoadProduct()
        {
            // listViewProducts.Items.Clear();
            try
            {
                var client2 = new HttpClient();
                client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.JwtToken);
                var response = await client2.GetAsync(ApiPort.UrlBase + "/api/Producto");
                var jsonresp = await response.Content.ReadAsStringAsync();
                List<productos_ViewModel> pedidos;
                pedidos = JsonConvert.DeserializeObject<List<productos_ViewModel>>(jsonresp);
                //dataGridView1.DataSource = productos;
                dataGridProducts.DataSource = pedidos;

            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Error en la solicitud HTTP: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dataGridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            productos_ViewModel product = dataGridProducts.CurrentRow.DataBoundItem as productos_ViewModel;
            ShowDetails(product);

        }
        private void ShowDetails(productos_ViewModel product)
        {

            FrmProductos_Acciones frmproductAcciones = new FrmProductos_Acciones(product);
            this.Hide();

            frmproductAcciones.Show();
        }
        private void Ocultar()
        {
            lblNombre.Visible = false;
            lblDescrip.Visible = false;
            lblPrecio.Visible = false;
            lblStock.Visible = false;

            txtNombre.Visible = false;
            txtDescrip.Visible = false;
            txtPrecio.Visible = false;
            txtStock.Visible = false;

            button2.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lblNombre.Visible = true;
            lblDescrip.Visible = true;
            lblPrecio.Visible = true;
            lblStock.Visible = true;

            txtNombre.Visible = true;
            txtDescrip.Visible = true;
            txtPrecio.Visible = true;
            txtStock.Visible = true;
            button2.Visible = true;
            button2.BackColor = Color.Green;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var modeltoSend = new productos_ViewModel()
            {
                Producto_Nombre = txtNombre.Text,
                Producto_Descripcion = txtDescrip.Text,
                Producto_Precio = Convert.ToDecimal(txtPrecio.Text),
                Producto_Stok = Convert.ToInt32(txtStock.Text),
                Producto_Imagen = "_"


            };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.JwtToken);

            var jsonContent = JsonConvert.SerializeObject(modeltoSend);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(ApiPort.UrlBase + "/api/Producto/Insert", contentString);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Producto insertado con éxito.");
                FrmInicio frmInicio = new FrmInicio();
                this.Hide();
                frmInicio.Show();
            }
            else
            {
                MessageBox.Show($"Error al insertar el producto: {response.ReasonPhrase}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            this.Hide();
            frmInicio.Show();
        }
    }
}
