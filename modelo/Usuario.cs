namespace Final_TallerdeProgramacion_Aguilar_Juarez.modelo
{
    internal class Usuario
    {
        private int id;
        private string username;
        private string password;
        private string rol;
        private bool activo;

        public Usuario(string username, string password, bool isHashed = false)
        {
            this.username = username;
            this.password = isHashed ? password : BCrypt.Net.BCrypt.HashPassword(password);
        }

        public Usuario(string username, string password, string rol, bool activo, bool isHashed = false)
        {
            this.username = username;
            this.password = isHashed ? password : BCrypt.Net.BCrypt.HashPassword(password);
            this.rol = rol;
            this.activo = activo;
        }



        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Rol { get => rol; set => rol = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
