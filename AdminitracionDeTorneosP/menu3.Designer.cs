
namespace AdminitracionDeTorneosP
{
    partial class menu3
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu3));
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.iconoMinimizar = new System.Windows.Forms.PictureBox();
            this.iconoCerrar = new System.Windows.Forms.PictureBox();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.MenuVertical.SuspendLayout();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconoCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuVertical
            // 
            this.MenuVertical.AutoScroll = true;
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.MenuVertical.Controls.Add(this.button13);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 0);
            this.MenuVertical.Margin = new System.Windows.Forms.Padding(2);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(188, 528);
            this.MenuVertical.TabIndex = 0;
            // 
            // button13
            // 
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.Location = new System.Drawing.Point(12, 72);
            this.button13.Margin = new System.Windows.Forms.Padding(2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(172, 37);
            this.button13.TabIndex = 15;
            this.button13.Text = "Reportería";
            this.button13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BarraTitulo.Controls.Add(this.button1);
            this.BarraTitulo.Controls.Add(this.label1);
            this.BarraTitulo.Controls.Add(this.iconoMinimizar);
            this.BarraTitulo.Controls.Add(this.iconoCerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(188, 0);
            this.BarraTitulo.Margin = new System.Windows.Forms.Padding(2);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(787, 41);
            this.BarraTitulo.TabIndex = 1;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 5;
            // 
            // iconoMinimizar
            // 
            this.iconoMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconoMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("iconoMinimizar.Image")));
            this.iconoMinimizar.Location = new System.Drawing.Point(711, 7);
            this.iconoMinimizar.Margin = new System.Windows.Forms.Padding(2);
            this.iconoMinimizar.Name = "iconoMinimizar";
            this.iconoMinimizar.Size = new System.Drawing.Size(26, 28);
            this.iconoMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconoMinimizar.TabIndex = 4;
            this.iconoMinimizar.TabStop = false;
            this.iconoMinimizar.Click += new System.EventHandler(this.iconoMinimizar_Click);
            // 
            // iconoCerrar
            // 
            this.iconoCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconoCerrar.Image = ((System.Drawing.Image)(resources.GetObject("iconoCerrar.Image")));
            this.iconoCerrar.Location = new System.Drawing.Point(751, 7);
            this.iconoCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.iconoCerrar.Name = "iconoCerrar";
            this.iconoCerrar.Size = new System.Drawing.Size(26, 28);
            this.iconoCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconoCerrar.TabIndex = 2;
            this.iconoCerrar.TabStop = false;
            this.iconoCerrar.Click += new System.EventHandler(this.iconoCerrar_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(188, 41);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(2);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(787, 487);
            this.panelContenedor.TabIndex = 2;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Cerrar Sesion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // menu3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 528);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.MenuVertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "menu3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MenuVertical.ResumeLayout(false);
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconoCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.PictureBox iconoMinimizar;
        private System.Windows.Forms.PictureBox iconoCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button1;
    }
}

