namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    partial class HistoriaClinica
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
            this.dataGridViewHistoriaClinica = new System.Windows.Forms.DataGridView();
            this.spListarhistoriaclinicaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hospital_san_telmoDataSet10 = new Final_TallerdeProgramacion_Aguilar_Juarez.hospital_san_telmoDataSet10();
            this.spListar_historia_clinicaTableAdapter = new Final_TallerdeProgramacion_Aguilar_Juarez.hospital_san_telmoDataSet10TableAdapters.spListar_historia_clinicaTableAdapter();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoriaClinica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListarhistoriaclinicaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hospital_san_telmoDataSet10)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHistoriaClinica
            // 
            this.dataGridViewHistoriaClinica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHistoriaClinica.BackgroundColor = System.Drawing.Color.LawnGreen;
            this.dataGridViewHistoriaClinica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistoriaClinica.GridColor = System.Drawing.Color.Black;
            this.dataGridViewHistoriaClinica.Location = new System.Drawing.Point(-1, -2);
            this.dataGridViewHistoriaClinica.Name = "dataGridViewHistoriaClinica";
            this.dataGridViewHistoriaClinica.Size = new System.Drawing.Size(437, 322);
            this.dataGridViewHistoriaClinica.TabIndex = 0;
            // 
            // spListarhistoriaclinicaBindingSource
            // 
            this.spListarhistoriaclinicaBindingSource.DataMember = "spListar_historia_clinica";
            this.spListarhistoriaclinicaBindingSource.DataSource = this.hospital_san_telmoDataSet10;
            // 
            // hospital_san_telmoDataSet10
            // 
            this.hospital_san_telmoDataSet10.DataSetName = "hospital_san_telmoDataSet10";
            this.hospital_san_telmoDataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spListar_historia_clinicaTableAdapter
            // 
            this.spListar_historia_clinicaTableAdapter.ClearBeforeFill = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(157, 326);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(120, 41);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // HistoriaClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Final_TallerdeProgramacion_Aguilar_Juarez.Properties.Resources.Minimalist_Hospital_and_Medical_Health_Logo__1_;
            this.ClientSize = new System.Drawing.Size(436, 377);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dataGridViewHistoriaClinica);
            this.Name = "HistoriaClinica";
            this.Text = "HistoriaClinica";
            this.Load += new System.EventHandler(this.HistoriaClinica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoriaClinica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListarhistoriaclinicaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hospital_san_telmoDataSet10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHistoriaClinica;
        private System.Windows.Forms.BindingSource spListarhistoriaclinicaBindingSource;
        private hospital_san_telmoDataSet10 hospital_san_telmoDataSet10;
        private hospital_san_telmoDataSet10TableAdapters.spListar_historia_clinicaTableAdapter spListar_historia_clinicaTableAdapter;
        private System.Windows.Forms.Button btnVolver;
    }
}