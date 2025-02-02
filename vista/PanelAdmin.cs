using System;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class PanelAdmin : Form
    {
        private IngresoMedico cargarMedico;
        private Finanzas finanzas;
        public PanelAdmin()
        {
            InitializeComponent();
        }

        private void PanelAdmin_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'hospital_san_telmoDataSet9.vista_turnos_pendientes' Puede moverla o quitarla según sea necesario.
            this.vista_turnos_pendientesTableAdapter1.Fill(this.hospital_san_telmoDataSet9.vista_turnos_pendientes);
            // TODO: esta línea de código carga datos en la tabla 'hospital_san_telmoDataSet8.vista_medicos' Puede moverla o quitarla según sea necesario.
            this.vista_medicosTableAdapter1.Fill(this.hospital_san_telmoDataSet8.vista_medicos);
            // TODO: esta línea de código carga datos en la tabla 'hospital_san_telmoDataSet7.vista_pacientes' Puede moverla o quitarla según sea necesario.
            this.vista_pacientesTableAdapter1.Fill(this.hospital_san_telmoDataSet7.vista_pacientes);

            

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("¿Desea salir del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Application.ExitThread();
                Dispose();
            }
        }


        private void btnCargarMedicos_Click(object sender, EventArgs e)
        {
            cargarMedico = new IngresoMedico();
            cargarMedico.Show();
            Hide();
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            finanzas = new Finanzas();
            finanzas.Show();
            Hide();
        }
    }
}
