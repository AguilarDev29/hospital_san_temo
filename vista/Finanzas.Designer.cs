namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    partial class Finanzas
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
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.pFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewFinanzas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFinanzas)).BeginInit();
            this.SuspendLayout();
            // 
            // hospital_san_telmoDataSet11
            // 
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.Location = new System.Drawing.Point(296, 396);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(109, 52);
            this.btnExportarExcel.TabIndex = 3;
            this.btnExportarExcel.Text = "Exportar a Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(411, 398);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(101, 46);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // pFechaDesde
            // 
            this.pFechaDesde.Location = new System.Drawing.Point(90, 396);
            this.pFechaDesde.Name = "pFechaDesde";
            this.pFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.pFechaDesde.TabIndex = 1;
            this.pFechaDesde.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.pFechaDesde.ValueChanged += new System.EventHandler(this.pFechaDesde_ValueChanged);
            // 
            // pFechaHasta
            // 
            this.pFechaHasta.Location = new System.Drawing.Point(90, 428);
            this.pFechaHasta.Name = "pFechaHasta";
            this.pFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.pFechaHasta.TabIndex = 2;
            this.pFechaHasta.ValueChanged += new System.EventHandler(this.pFechaHasta_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hasta";
            // 
            // dataGridViewFinanzas
            // 
            this.dataGridViewFinanzas.BackgroundColor = System.Drawing.Color.LawnGreen;
            this.dataGridViewFinanzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFinanzas.GridColor = System.Drawing.Color.Black;
            this.dataGridViewFinanzas.Location = new System.Drawing.Point(-1, -1);
            this.dataGridViewFinanzas.Name = "dataGridViewFinanzas";
            this.dataGridViewFinanzas.Size = new System.Drawing.Size(527, 385);
            this.dataGridViewFinanzas.TabIndex = 0;
            // 
            // Finanzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Final_TallerdeProgramacion_Aguilar_Juarez.Properties.Resources.Minimalist_Hospital_and_Medical_Health_Logo__1_;
            this.ClientSize = new System.Drawing.Size(524, 454);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pFechaHasta);
            this.Controls.Add(this.pFechaDesde);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.dataGridViewFinanzas);
            this.Name = "Finanzas";
            this.Text = "Finanzas";
            this.Load += new System.EventHandler(this.Finanzas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFinanzas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DateTimePicker pFechaDesde;
        private System.Windows.Forms.DateTimePicker pFechaHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewFinanzas;
    }
}