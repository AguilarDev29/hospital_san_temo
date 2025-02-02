using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class BajaMedico : Form
    {
        public BajaMedico()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(DarDeBaja(txtDni.Text) > 0) { 
                MessageBox.Show("Medico dado de baja", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }


        private int DarDeBaja(string dni)
        {
            string query = "UPDATE medico SET activo = 0 WHERE dni = @dni;" +
                            "UPDATE usuario SET activo = 0 WHERE usuario = @usuario;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@usuario", dni);
                return cmd.ExecuteNonQuery();
            }
        }

    }
}
