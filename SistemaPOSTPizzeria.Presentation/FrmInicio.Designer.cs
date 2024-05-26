
namespace SistemaPOSTPizzeria.Presentation
{
    partial class FrmInicio
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridPedidos = new System.Windows.Forms.DataGridView();
            this.btnGestionarProd = new System.Windows.Forms.Button();
            this.btnGestionarCli = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(57, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sistema Pos Pizzeria";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dataGridPedidos
            // 
            this.dataGridPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPedidos.Location = new System.Drawing.Point(71, 136);
            this.dataGridPedidos.Name = "dataGridPedidos";
            this.dataGridPedidos.RowTemplate.Height = 25;
            this.dataGridPedidos.Size = new System.Drawing.Size(686, 265);
            this.dataGridPedidos.TabIndex = 2;
            this.dataGridPedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPedidos_CellContentClick);
            // 
            // btnGestionarProd
            // 
            this.btnGestionarProd.Location = new System.Drawing.Point(274, 12);
            this.btnGestionarProd.Name = "btnGestionarProd";
            this.btnGestionarProd.Size = new System.Drawing.Size(125, 36);
            this.btnGestionarProd.TabIndex = 3;
            this.btnGestionarProd.Text = "Gestionar Productos";
            this.btnGestionarProd.UseVisualStyleBackColor = true;
            this.btnGestionarProd.Click += new System.EventHandler(this.btnGestionarProd_Click);
            // 
            // btnGestionarCli
            // 
            this.btnGestionarCli.Location = new System.Drawing.Point(405, 12);
            this.btnGestionarCli.Name = "btnGestionarCli";
            this.btnGestionarCli.Size = new System.Drawing.Size(125, 36);
            this.btnGestionarCli.TabIndex = 4;
            this.btnGestionarCli.Text = "Gestionar Clientes";
            this.btnGestionarCli.UseVisualStyleBackColor = true;
            this.btnGestionarCli.Click += new System.EventHandler(this.btnGestionarCli_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(622, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Agregar pedido";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pedidos";
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGestionarCli);
            this.Controls.Add(this.btnGestionarProd);
            this.Controls.Add(this.dataGridPedidos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmInicio";
            this.Text = "FrmInicio";
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridPedidos;
        private System.Windows.Forms.Button btnGestionarProd;
        private System.Windows.Forms.Button btnGestionarCli;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}