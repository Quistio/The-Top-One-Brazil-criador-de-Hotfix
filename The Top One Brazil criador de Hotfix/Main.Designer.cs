namespace The_Top_One_Brazil_criador_de_Hotfix
{
    partial class Main
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.CaminhoApp = new System.Windows.Forms.TextBox();
			this.labelCaminhoApp = new System.Windows.Forms.Label();
			this.NomesProgramas = new System.Windows.Forms.TextBox();
			this.labelNomesProgramas = new System.Windows.Forms.Label();
			this.labelDataHoraModificao = new System.Windows.Forms.Label();
			this.NumeroProtocolo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.PorDataHora = new System.Windows.Forms.CheckBox();
			this.PorNomePrograma = new System.Windows.Forms.CheckBox();
			this.GroupPorDataHora = new System.Windows.Forms.GroupBox();
			this.DataHoraModificao = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.error = new System.Windows.Forms.ErrorProvider(this.components);
			this.pastaTemporaria = new System.Windows.Forms.TextBox();
			this.labelPastaTemporaria = new System.Windows.Forms.Label();
			this.Total = new System.Windows.Forms.Label();
			this.GroupPorDataHora.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
			this.SuspendLayout();
			// 
			// CaminhoApp
			// 
			this.CaminhoApp.Location = new System.Drawing.Point(21, 76);
			this.CaminhoApp.Multiline = true;
			this.CaminhoApp.Name = "CaminhoApp";
			this.CaminhoApp.Size = new System.Drawing.Size(478, 20);
			this.CaminhoApp.TabIndex = 0;
			// 
			// labelCaminhoApp
			// 
			this.labelCaminhoApp.AutoSize = true;
			this.labelCaminhoApp.Location = new System.Drawing.Point(18, 60);
			this.labelCaminhoApp.Name = "labelCaminhoApp";
			this.labelCaminhoApp.Size = new System.Drawing.Size(97, 13);
			this.labelCaminhoApp.TabIndex = 1;
			this.labelCaminhoApp.Text = "Caminho aplicação";
			// 
			// NomesProgramas
			// 
			this.NomesProgramas.Location = new System.Drawing.Point(9, 32);
			this.NomesProgramas.Multiline = true;
			this.NomesProgramas.Name = "NomesProgramas";
			this.NomesProgramas.Size = new System.Drawing.Size(478, 198);
			this.NomesProgramas.TabIndex = 2;
			// 
			// labelNomesProgramas
			// 
			this.labelNomesProgramas.AutoSize = true;
			this.labelNomesProgramas.Location = new System.Drawing.Point(6, 16);
			this.labelNomesProgramas.Name = "labelNomesProgramas";
			this.labelNomesProgramas.Size = new System.Drawing.Size(256, 13);
			this.labelNomesProgramas.TabIndex = 4;
			this.labelNomesProgramas.Text = "Nome dos programas (separador por ponto e vírgula)";
			// 
			// labelDataHoraModificao
			// 
			this.labelDataHoraModificao.AutoSize = true;
			this.labelDataHoraModificao.Location = new System.Drawing.Point(6, 21);
			this.labelDataHoraModificao.Name = "labelDataHoraModificao";
			this.labelDataHoraModificao.Size = new System.Drawing.Size(161, 13);
			this.labelDataHoraModificao.TabIndex = 5;
			this.labelDataHoraModificao.Text = "Data hora modificação dos class";
			// 
			// NumeroProtocolo
			// 
			this.NumeroProtocolo.Location = new System.Drawing.Point(21, 120);
			this.NumeroProtocolo.Name = "NumeroProtocolo";
			this.NumeroProtocolo.Size = new System.Drawing.Size(478, 20);
			this.NumeroProtocolo.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(193, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Nome Hotfix (Ex.: FIXNúmeroProtocolo)";
			// 
			// PorDataHora
			// 
			this.PorDataHora.AutoSize = true;
			this.PorDataHora.Location = new System.Drawing.Point(481, 0);
			this.PorDataHora.Name = "PorDataHora";
			this.PorDataHora.Size = new System.Drawing.Size(15, 14);
			this.PorDataHora.TabIndex = 8;
			this.PorDataHora.UseVisualStyleBackColor = true;
			this.PorDataHora.CheckedChanged += new System.EventHandler(this.PorDataHora_CheckedChanged);
			// 
			// PorNomePrograma
			// 
			this.PorNomePrograma.AutoSize = true;
			this.PorNomePrograma.Location = new System.Drawing.Point(481, 0);
			this.PorNomePrograma.Name = "PorNomePrograma";
			this.PorNomePrograma.Size = new System.Drawing.Size(15, 14);
			this.PorNomePrograma.TabIndex = 9;
			this.PorNomePrograma.UseVisualStyleBackColor = true;
			this.PorNomePrograma.CheckedChanged += new System.EventHandler(this.PorNomePrograma_CheckedChanged);
			// 
			// GroupPorDataHora
			// 
			this.GroupPorDataHora.Controls.Add(this.DataHoraModificao);
			this.GroupPorDataHora.Controls.Add(this.labelDataHoraModificao);
			this.GroupPorDataHora.Controls.Add(this.PorDataHora);
			this.GroupPorDataHora.Location = new System.Drawing.Point(12, 153);
			this.GroupPorDataHora.Name = "GroupPorDataHora";
			this.GroupPorDataHora.Size = new System.Drawing.Size(502, 70);
			this.GroupPorDataHora.TabIndex = 10;
			this.GroupPorDataHora.TabStop = false;
			this.GroupPorDataHora.Text = "Por datahora";
			// 
			// DataHoraModificao
			// 
			this.DataHoraModificao.Location = new System.Drawing.Point(9, 37);
			this.DataHoraModificao.Name = "DataHoraModificao";
			this.DataHoraModificao.Size = new System.Drawing.Size(478, 20);
			this.DataHoraModificao.TabIndex = 9;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.PorNomePrograma);
			this.groupBox1.Controls.Add(this.NomesProgramas);
			this.groupBox1.Controls.Add(this.labelNomesProgramas);
			this.groupBox1.Location = new System.Drawing.Point(12, 229);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(502, 243);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Por nome dos programas";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(439, 478);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "Gerar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// error
			// 
			this.error.ContainerControl = this;
			// 
			// pastaTemporaria
			// 
			this.pastaTemporaria.Location = new System.Drawing.Point(21, 34);
			this.pastaTemporaria.Name = "pastaTemporaria";
			this.pastaTemporaria.Size = new System.Drawing.Size(478, 20);
			this.pastaTemporaria.TabIndex = 13;
			// 
			// labelPastaTemporaria
			// 
			this.labelPastaTemporaria.AutoSize = true;
			this.labelPastaTemporaria.Location = new System.Drawing.Point(18, 18);
			this.labelPastaTemporaria.Name = "labelPastaTemporaria";
			this.labelPastaTemporaria.Size = new System.Drawing.Size(193, 13);
			this.labelPastaTemporaria.TabIndex = 14;
			this.labelPastaTemporaria.Text = "Pasta temporária para criação do Hotfix";
			// 
			// Total
			// 
			this.Total.AutoSize = true;
			this.Total.Location = new System.Drawing.Point(12, 487);
			this.Total.Name = "Total";
			this.Total.Size = new System.Drawing.Size(124, 13);
			this.Total.TabIndex = 15;
			this.Total.Text = "10 arquivos encontrados";
			this.Total.Click += new System.EventHandler(this.Total_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(525, 508);
			this.Controls.Add(this.Total);
			this.Controls.Add(this.labelPastaTemporaria);
			this.Controls.Add(this.pastaTemporaria);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.NumeroProtocolo);
			this.Controls.Add(this.labelCaminhoApp);
			this.Controls.Add(this.CaminhoApp);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.GroupPorDataHora);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Main";
			this.Text = "The Top One Brazil criador de Hotfix";
			this.GroupPorDataHora.ResumeLayout(false);
			this.GroupPorDataHora.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CaminhoApp;
        private System.Windows.Forms.Label labelCaminhoApp;
        private System.Windows.Forms.TextBox NomesProgramas;
        private System.Windows.Forms.Label labelNomesProgramas;
        private System.Windows.Forms.Label labelDataHoraModificao;
        private System.Windows.Forms.TextBox NumeroProtocolo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox PorDataHora;
        private System.Windows.Forms.CheckBox PorNomePrograma;
        private System.Windows.Forms.GroupBox GroupPorDataHora;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DataHoraModificao;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.TextBox pastaTemporaria;
        private System.Windows.Forms.Label labelPastaTemporaria;
		private System.Windows.Forms.Label Total;
	}
}

