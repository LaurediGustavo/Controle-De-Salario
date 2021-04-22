namespace ControleDeValor
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.chGraficos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.btnGanho = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnGasto = new System.Windows.Forms.Button();
            this.btnResgatar = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEconomizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chGraficos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(770, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(30, 30);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "X";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnHistorico
            // 
            this.btnHistorico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorico.FlatAppearance.BorderSize = 0;
            this.btnHistorico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnHistorico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorico.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorico.ForeColor = System.Drawing.Color.White;
            this.btnHistorico.Location = new System.Drawing.Point(0, 0);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(83, 30);
            this.btnHistorico.TabIndex = 1;
            this.btnHistorico.Text = "Histórico";
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // chGraficos
            // 
            this.chGraficos.BackColor = System.Drawing.Color.Black;
            this.chGraficos.BackImageTransparentColor = System.Drawing.Color.Black;
            this.chGraficos.BackSecondaryColor = System.Drawing.Color.Black;
            this.chGraficos.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.BackImageTransparentColor = System.Drawing.Color.Black;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea1";
            this.chGraficos.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Black;
            legend2.ForeColor = System.Drawing.Color.MediumPurple;
            legend2.Name = "Legend1";
            this.chGraficos.Legends.Add(legend2);
            this.chGraficos.Location = new System.Drawing.Point(168, 36);
            this.chGraficos.Name = "chGraficos";
            this.chGraficos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series2.BackImageTransparentColor = System.Drawing.Color.Black;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.LabelBackColor = System.Drawing.Color.Black;
            series2.LabelBorderColor = System.Drawing.Color.Black;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chGraficos.Series.Add(series2);
            this.chGraficos.Size = new System.Drawing.Size(620, 479);
            this.chGraficos.TabIndex = 2;
            this.chGraficos.Text = "chart1";
            this.chGraficos.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.DarkViolet;
            this.lblValorTotal.Location = new System.Drawing.Point(650, 102);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(42, 16);
            this.lblValorTotal.TabIndex = 9;
            this.lblValorTotal.Text = "label3";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.Color.DarkViolet;
            this.lblData.Location = new System.Drawing.Point(650, 137);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(50, 18);
            this.lblData.TabIndex = 10;
            this.lblData.Text = "label3";
            // 
            // btnGanho
            // 
            this.btnGanho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGanho.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGanho.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnGanho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnGanho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGanho.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGanho.ForeColor = System.Drawing.Color.White;
            this.btnGanho.Location = new System.Drawing.Point(4, 52);
            this.btnGanho.Name = "btnGanho";
            this.btnGanho.Size = new System.Drawing.Size(199, 40);
            this.btnGanho.TabIndex = 11;
            this.btnGanho.Text = "Ganho";
            this.btnGanho.UseVisualStyleBackColor = true;
            this.btnGanho.Click += new System.EventHandler(this.btnGanho_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(3, 98);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 40);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnGasto
            // 
            this.btnGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGasto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGasto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnGasto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGasto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGasto.ForeColor = System.Drawing.Color.White;
            this.btnGasto.Location = new System.Drawing.Point(4, 6);
            this.btnGasto.Name = "btnGasto";
            this.btnGasto.Size = new System.Drawing.Size(199, 40);
            this.btnGasto.TabIndex = 13;
            this.btnGasto.Text = "Gasto";
            this.btnGasto.UseVisualStyleBackColor = true;
            this.btnGasto.Click += new System.EventHandler(this.btnGasto_Click);
            // 
            // btnResgatar
            // 
            this.btnResgatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResgatar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnResgatar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnResgatar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnResgatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResgatar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResgatar.ForeColor = System.Drawing.Color.White;
            this.btnResgatar.Location = new System.Drawing.Point(4, 144);
            this.btnResgatar.Name = "btnResgatar";
            this.btnResgatar.Size = new System.Drawing.Size(199, 40);
            this.btnResgatar.TabIndex = 14;
            this.btnResgatar.Text = "Resgatar";
            this.btnResgatar.UseVisualStyleBackColor = true;
            this.btnResgatar.Click += new System.EventHandler(this.btnResgatar_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(83, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(83, 30);
            this.btnMenu.TabIndex = 15;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnEconomizar);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnGasto);
            this.panel1.Controls.Add(this.btnGanho);
            this.panel1.Controls.Add(this.btnResgatar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Location = new System.Drawing.Point(-206, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 498);
            this.panel1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(4, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 40);
            this.button1.TabIndex = 15;
            this.button1.Text = "Visualizar Gastos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEconomizar
            // 
            this.btnEconomizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEconomizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEconomizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnEconomizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEconomizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEconomizar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEconomizar.ForeColor = System.Drawing.Color.White;
            this.btnEconomizar.Location = new System.Drawing.Point(4, 236);
            this.btnEconomizar.Name = "btnEconomizar";
            this.btnEconomizar.Size = new System.Drawing.Size(199, 40);
            this.btnEconomizar.TabIndex = 16;
            this.btnEconomizar.Text = "Economizar p/ compra";
            this.btnEconomizar.UseVisualStyleBackColor = true;
            this.btnEconomizar.Click += new System.EventHandler(this.btnEconomizar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.chGraficos);
            this.Controls.Add(this.btnHistorico);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chGraficos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.DataVisualization.Charting.Chart chGraficos;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Button btnGanho;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnGasto;
        private System.Windows.Forms.Button btnResgatar;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEconomizar;
    }
}

