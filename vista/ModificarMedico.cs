using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class ModificarMedico : Form
    {
        private IngresoMedico ingresoMedico;

        public ModificarMedico()
        {
            InitializeComponent();
        }
        private void ModificarMedico_Load(object sender, EventArgs e)
        {
            CargarEspecialidad();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {   
            Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico(txtApellido.Text, txtNombre.Text,
                txtDni.Text, cbSexo.Text, pFechaNac.Value, txtTelefono.Text, txtEmail.Text,IdEspecialidad(cbEspecialidad.Text), Convert.ToDecimal(txtPlus.Text));
            if(Modificar(medico) > 0)
            {
                MessageBox.Show("Medico modificado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            ingresoMedico = new IngresoMedico();
            ingresoMedico.Show();
            Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Medico medico = BuscarMedico(txtDni.Text);
            if (medico == null)
            {
                MessageBox.Show("Médico no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtApellido.Text = medico.Apellido;
                txtNombre.Text = medico.Nombre;
                cbSexo.Text = medico.Sexo;
                pFechaNac.Value = medico.FechaNac;
                txtTelefono.Text = medico.Telefono;
                txtEmail.Text = medico.Email;
                txtPlus.Text = medico.Plus.ToString();
            }
        }

        private int Modificar(Medico medico)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "UPDATE medico SET apellido = @apellido, nombre = @nombre, sexo = @sexo," +
                    " fecha_nac = @fechaNac, telefono = @telefono, email = @email, plus = @plus WHERE dni = @dni;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@apellido", medico.Apellido);
                cmd.Parameters.AddWithValue("@nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@sexo", medico.Sexo);
                cmd.Parameters.AddWithValue("@fechaNac", medico.FechaNac);
                cmd.Parameters.AddWithValue("@telefono", medico.Telefono);
                cmd.Parameters.AddWithValue("@email", medico.Email);
                cmd.Parameters.AddWithValue("@plus", medico.Plus);
                cmd.Parameters.AddWithValue("@dni", medico.Dni);
                return cmd.ExecuteNonQuery();
            }
        }

        private Medico BuscarMedico(string dni)
        {
            string query = "SELECT m.apellido, m.nombre , m.sexo, m.fecha_nac," +
            " m.telefono, m.email, m.id_especialidad, m.plus FROM medico m INNER JOIN" +
            " especialidad e ON m.id_Especialidad = e.id WHERE m.dni = @dni";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Medico(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDateTime(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetInt32(6),
                        reader.GetDecimal(7)
                        );
                }
                return null;
            }
        }

        private void CargarEspecialidad()
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "SELECT nombre FROM especialidad;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbEspecialidad.Items.Add(reader.GetString(0));
                }
            }
        }


        private int IdEspecialidad(string especialidad)
        {
            string query = "SELECT id FROM especialidad WHERE nombre = @especialidad";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@especialidad", especialidad);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
