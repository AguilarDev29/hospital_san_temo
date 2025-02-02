using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class Finanzas : Form
    {
        private SqlDataAdapter dataAdapter;
        private System.Data.DataTable dataTable;
        private PanelAdmin panelAdmin;
        public Finanzas()
        {
            InitializeComponent();
        }

        private void Finanzas_Load(object sender, EventArgs e)
        {
            LoadData(pFechaDesde.Value, pFechaHasta.Value);

        }

        private void LoadData(DateTime fechaInicio, DateTime fechaFin)
        {
            string query = "EXECUTE spFiltrar_pagos @fecha_inicio, @fecha_fin;";
            using (SqlConnection conn = Conexion.Conectar()) 
            {
                    dataAdapter = new SqlDataAdapter(query, conn);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@fecha_inicio", fechaInicio);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@fecha_fin", fechaFin);
                    dataTable = new System.Data.DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewFinanzas.DataSource = dataTable;
                    dataGridViewFinanzas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
                
        }

        private void FiltrarDatos()
        {
            DateTime fechaInicio = pFechaDesde.Value;
            DateTime fechaFin = pFechaHasta.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.");
                return;
            }

            LoadData(fechaInicio, fechaFin);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelAdmin = new PanelAdmin();
            panelAdmin.Show();
            Hide();
        }

        private void pFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void pFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarAExcel();
        }

        private void ExportarAExcel()
        {
            // Verificar si el DataGridView tiene datos
            if (dataGridViewFinanzas.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear un DataTable con los datos del DataGridView
            DataTable dt = new DataTable();

            // Agregar columnas
            foreach (DataGridViewColumn column in dataGridViewFinanzas.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            // Agregar filas
            foreach (DataGridViewRow row in dataGridViewFinanzas.Rows)
            {
                if (!row.IsNewRow)
                {
                    dt.Rows.Add(row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString()).ToArray());
                }
            }

            // Guardar el archivo Excel
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Guardar archivo Excel";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Datos");
                            wb.SaveAs(filePath);
                        }

                        MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
