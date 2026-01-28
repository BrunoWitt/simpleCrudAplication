namespace simpleCrudAplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTexto = new TextBox();
            numNumero = new NumericUpDown();
            dgvDados = new DataGridView();
            btnAdicionar = new Button();
            btnAtualizar = new Button();
            btnAjuda = new Button();
            ((System.ComponentModel.ISupportInitialize)numNumero).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDados).BeginInit();
            SuspendLayout();
            // 
            // txtTexto
            // 
            txtTexto.Location = new Point(94, 70);
            txtTexto.Name = "txtTexto";
            txtTexto.Size = new Size(100, 23);
            txtTexto.TabIndex = 0;
            // 
            // numNumero
            // 
            numNumero.Location = new Point(200, 71);
            numNumero.Name = "numNumero";
            numNumero.Size = new Size(35, 23);
            numNumero.TabIndex = 2;
            // 
            // dgvDados
            // 
            dgvDados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDados.Location = new Point(293, 70);
            dgvDados.Name = "dgvDados";
            dgvDados.Size = new Size(408, 150);
            dgvDados.TabIndex = 3;
            dgvDados.CellContentClick += dgvDados_CellContentClick;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(160, 99);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(75, 23);
            btnAdicionar.TabIndex = 4;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(459, 227);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(75, 23);
            btnAtualizar.TabIndex = 5;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnAjuda
            // 
            btnAjuda.Location = new Point(663, 25);
            btnAjuda.Name = "btnAjuda";
            btnAjuda.Size = new Size(38, 23);
            btnAjuda.TabIndex = 6;
            btnAjuda.Text = "?";
            btnAjuda.UseVisualStyleBackColor = true;
            btnAjuda.Click += btnAjuda_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAjuda);
            Controls.Add(btnAtualizar);
            Controls.Add(btnAdicionar);
            Controls.Add(dgvDados);
            Controls.Add(numNumero);
            Controls.Add(txtTexto);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numNumero).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTexto;
        private NumericUpDown numNumero;
        private DataGridView dgvDados;
        private Button btnAdicionar;
        private Button btnAtualizar;
        private Button btnAjuda;
    }
}
