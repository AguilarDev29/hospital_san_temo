using System;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.modelo
{
    internal class Medico
    {
        private int id;
        private string apellido;
        private string nombre;
        private string dni;
        private string sexo;
        private DateTime fechaNac;
        private string telefono;
        private string email;
        private int idEspecialidad;
        private decimal plus;
        private bool activo;


        public Medico(string apellido, string nombre, string sexo, DateTime fechaNac,
            string telefono, string email, int idEspecialidad, decimal plus)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.sexo = sexo;
            this.fechaNac = fechaNac;
            this.telefono = telefono;
            this.email = email;
            this.idEspecialidad = idEspecialidad;
            this.plus = plus;
        }

        public Medico(string apellido, string nombre, string dni, string sexo,DateTime fechaNac,
            string telefono, string email, int idEspecialidad, decimal plus)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.dni = dni;
            this.sexo = sexo;
            this.fechaNac = fechaNac;
            this.telefono = telefono;
            this.email = email;
            this.idEspecialidad = idEspecialidad;
            this.plus = plus;
        }

        public Medico(string apellido, string nombre, string dni, string sexo,DateTime fechaNac,
            string telefono, string email, int idEspecialidad, decimal plus, bool activo)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.dni = dni;
            this.sexo = sexo;
            this.fechaNac = fechaNac;
            this.telefono = telefono;
            this.email = email;
            this.idEspecialidad = idEspecialidad;
            this.plus = plus;
            this.activo = activo;
        }

        public Medico(int id, string apellido, string nombre, string dni, string sexo,DateTime fechaNac,
            string telefono, string email, int idEspecialidad, decimal plus, bool activo)
        {
            this.id = id;
            this.apellido = apellido;
            this.nombre = nombre;
            this.dni = dni;
            this.sexo = sexo;
            this.fechaNac = fechaNac;
            this.telefono = telefono;
            this.email = email;
            this.plus = plus;
            this.idEspecialidad = idEspecialidad;
            this.activo = activo;
        }

        public int Id { get => id; set => id = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public int IdEspecialidad { get => idEspecialidad; set => idEspecialidad = value; }
        public decimal Plus { get => plus; set => plus = value; }
        public bool Activo { get => activo; set => activo = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    }
}
