using System;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.modelo
{
    internal class Paciente
    {
        private int id;
        private string apellido;
        private string nombre;
        private string dni;
        private string sexo;
        private string direccion;
        private string localidad;
        private DateTime fechaNacimiento;
        private string telefono;
        private string email;
        private int idObraSocial;


        public Paciente(string apellido, string nombre, 
            string sexo, string direccion, string localidad, DateTime
            fechaNacimiento, string telefono, string email, int idObraSocial)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.sexo = sexo;
            this.direccion = direccion;
            this.localidad = localidad;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
            this.email = email;
            this.idObraSocial = idObraSocial;
        }

        public Paciente(string apellido, string nombre, string dni,
            string sexo, string direccion, string localidad, DateTime
            fechaNacimiento, string telefono, string email, int idObraSocial)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.dni = dni;
            this.sexo = sexo;
            this.direccion = direccion;
            this.localidad = localidad;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
            this.email = email;
            this.idObraSocial = idObraSocial;
        }

        public Paciente(int id, string apellido, string nombre,
            string dni, string sexo, string direccion, string localidad,
            DateTime fechaNacimiento, string telefono, string email, int idObraSocial)
        {
            this.id = id;
            this.apellido = apellido;
            this.nombre = nombre;
            this.dni = dni;
            this.sexo = sexo;
            this.direccion = direccion;
            this.localidad = localidad;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
            this.email = email;
            this.idObraSocial = idObraSocial;
        }

        public int Id { get => id; set => id = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public int IdObraSocial { get => idObraSocial; set => idObraSocial = value; }
    }
}
