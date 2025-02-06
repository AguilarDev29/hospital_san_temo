using BCrypt.Net;
using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class IngresoMedico : Form
    {
        private PanelAdmin panelAdmin;
        private ModificarMedico modificarMedico;
        private BajaMedico bajaMedico;
        public IngresoMedico()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelAdmin = new PanelAdmin();
            panelAdmin.Show();
            Hide();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico(txtApellido.Text, txtNombre.Text, txtDni.Text, cbSexo.Text,pFechaNac.Value,
                txtTelefono.Text, txtEmail.Text, IdEspecialidad(cbEspecialidad.Text), Convert.ToDecimal(txtPlus.Text));
            
            if (ValidarDni(medico.Dni) > 0)
            {
                MessageBox.Show("El DNI ingresado ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(CargarMedico(medico) > 0)
            {
                MessageBox.Show("Medico ingresado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HashearContraseña(medico);
            }

        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificarMedico = new ModificarMedico();
            modificarMedico.Show();
            Hide();
        }

        private void CargarMedico_Load(object sender, EventArgs e)
        {
            CargarEspecialidad();
        }


        private int CargarMedico(Medico medico)
        {
            string query = "INSERT INTO medico (apellido, nombre, dni, sexo, fecha_nac, telefono, email, id_especialidad, plus)" +
                " VALUES (@apellido, @nombre, @dni, @sexo, @fecha_nac, @telefono, @email, @id_especialidad, @plus);";
            try
            {

                using (SqlConnection conn = Conexion.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@apellido", medico.Apellido);
                    cmd.Parameters.AddWithValue("@nombre", medico.Nombre);
                    cmd.Parameters.AddWithValue("@dni", medico.Dni);
                    cmd.Parameters.AddWithValue("@sexo", medico.Sexo);
                    cmd.Parameters.AddWithValue("@fecha_nac", medico.FechaNac);
                    cmd.Parameters.AddWithValue("@telefono", medico.Telefono);
                    cmd.Parameters.AddWithValue("@email", medico.Email);
                    cmd.Parameters.AddWithValue("@id_especialidad", medico.IdEspecialidad);
                    cmd.Parameters.AddWithValue("@plus", medico.Plus);
                    return cmd.ExecuteNonQuery();
                }
            }catch(SqlException ex)
            {
                MessageBox.Show("Los campos no pueden estar vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
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
            string query = "SELECT id FROM especialidad WHERE nombre = @especialidad;";
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            cbSexo.SelectedIndex = -1;
            txtTelefono.Clear();
            txtEmail.Clear();
            cbEspecialidad.SelectedIndex = -1;
            txtPlus.Clear();
        }

        private void HashearContraseña(Medico medico)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "UPDATE usuario SET clave = @clave WHERE usuario = @usuario;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@clave", BCrypt.Net.BCrypt.HashPassword(medico.Dni));
                cmd.Parameters.AddWithValue("@usuario", medico.Dni);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            bajaMedico = new BajaMedico();
            bajaMedico.Show();
        }

        private int ValidarDni(string dni)
        {
            string query = "SELECT COUNT(*) FROM medico WHERE dni = @dni;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
