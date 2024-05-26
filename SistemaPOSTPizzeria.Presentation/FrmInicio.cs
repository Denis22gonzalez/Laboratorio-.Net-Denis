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
    public partial class FrmInicio : Form
    {
       
       
        public FrmInicio()
        {
            InitializeComponent();
            LoadPedidos();
            InitializeDataGridView();
          

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDataGridView()
        {
           // dataGridView1.AutoGenerateColumns = false; 

            // Definir las columnas del DataGridView
            //dataGridView1.Columns.Add("Id", "ID");
            //dataGridView1.Columns.Add("Nombre", "Nombre");
            //dataGridView1.Columns.Add("Descripcion", "Descripción");
            //dataGridView1.Columns.Add("Precio", "Precio");
            //dataGridView1.Columns.Add("Stock", "Stock");
            //dataGridView1.Columns.Add("Imagen", "Imagen");

            // Asignar el DataGridView al formulario
            //dataGridView1.Dock = DockStyle.Fill;
            //Controls.Add(dataGridView1);
        }

        private async void LoadPedidos()
        {
           // listViewProducts.Items.Clear();
            try
            {
                var client2 = new HttpClient();
                client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.JwtToken);
                var response = await client2.GetAsync(ApiPort.UrlBase + "/api/Pedido");
                var jsonresp = await response.Content.ReadAsStringAsync();
                 List<pedidos_viewModel> pedidos;
        pedidos = JsonConvert.DeserializeObject<List<pedidos_viewModel>>(jsonresp);
                //dataGridView1.DataSource = productos;
                dataGridPedidos.DataSource = pedidos;
               
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
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener el pedido seleccionado
            pedidos_viewModel pedido  = dataGridPedidos.CurrentRow.DataBoundItem as pedidos_viewModel;

            // Mostrar los detalles del pedido en otro formulario o en un cuadro de diálogo
            ShowOrderDetails(pedido);
        }

        private  async void ShowOrderDetails(pedidos_viewModel pedido)
        {
            var client2 = new HttpClient();
            client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.JwtToken);
            var response = await client2.GetAsync(ApiPort.UrlBase + "/api/PedidoDetalle?idpedido=" +pedido.pedido_Id);
            var jsonresp = await response.Content.ReadAsStringAsync();
            List<pedidos_Detalle_viewModel> pedidos;
            pedidos = JsonConvert.DeserializeObject<List<pedidos_Detalle_viewModel >> (jsonresp);
            // Aquí puedes implementar la lógica para mostrar los detalles del pedido
            // Puedes abrir otro formulario o mostrar los detalles en un cuadro de diálogo
            string detalle = "Detalles del pedido:\n";
            foreach (var item in pedidos)
            {
                detalle += $"Producto: {item.Producto_Nombre} | Cantidad: {item.pedido_detalle_cantidad} | Subtotal: {item.pedido_detalle_subtotal}\n";
            }
            
            MessageBox.Show(detalle);
        }

        private void dataGridPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pedidos_viewModel pedido = dataGridPedidos.CurrentRow.DataBoundItem as pedidos_viewModel;

            // Mostrar los detalles del pedido en otro formulario o en un cuadro de diálogo
            ShowOrderDetails(pedido);
        }

        private void btnGestionarCli_Click(object sender, EventArgs e)
        {

        }

        private void btnGestionarProd_Click(object sender, EventArgs e)
        {
            FrmProductos frmprod = new FrmProductos();
            this.Hide();

            frmprod.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
   
}
