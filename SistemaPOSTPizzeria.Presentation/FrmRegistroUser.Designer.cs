
namespace SistemaPOSTPizzeria.Presentation
{
    partial class FrmRegistroUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreRegistro = new System.Windows.Forms.TextBox();
            this.txtPasswordRegistro = new System.Windows.Forms.TextBox();
            this.btnRegistroUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // txtNombreRegistro
            // 
            this.txtNombreRegistro.Location = new System.Drawing.Point(220, 78);
            this.txtNombreRegistro.Name = "txtNombreRegistro";
            this.txtNombreRegistro.Size = new System.Drawing.Size(127, 23);
            this.txtNombreRegistro.TabIndex = 2;
            // 
            // txtPasswordRegistro
            // 
            this.txtPasswordRegistro.Location = new System.Drawing.Point(220, 123);
            this.txtPasswordRegistro.Name = "txtPasswordRegistro";
            this.txtPasswordRegistro.PasswordChar = '*';
            this.txtPasswordRegistro.Size = new System.Drawing.Size(127, 23);
            this.txtPasswordRegistro.TabIndex = 3;
            // 
            // btnRegistroUser
            // 
            this.btnRegistroUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRegistroUser.Location = new System.Drawing.Point(195, 226);
            this.btnRegistroUser.Name = "btnRegistroUser";
            this.btnRegistroUser.Size = new System.Drawing.Size(165, 47);
            this.btnRegistroUser.TabIndex = 6;
            this.btnRegistroUser.Text = "Registrarme";
            this.btnRegistroUser.UseVisualStyleBackColor = false;
            this.btnRegistroUser.Click += new System.EventHandler(this.btnRegistroUser_Click);
            // 
            // FrmRegistroUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegistroUser);
            this.Controls.Add(this.txtPasswordRegistro);
            this.Controls.Add(this.txtNombreRegistro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmRegistroUser";
            this.Text = "FrmRegistroUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreRegistro;
        private System.Windows.Forms.TextBox txtPasswordRegistro;
        private System.Windows.Forms.Button btnRegistroUser;
    }
}