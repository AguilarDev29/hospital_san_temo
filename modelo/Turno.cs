using System;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.modelo
{
    internal class Turno
    {
        private int id;
        private int idPaciente;
        private int idMedico;
        private DateTime fechaTurno;
        private string horaTurno;
        private decimal total;
        private string atendido;

        public int Id { get => id; set => id = value; }
        public int IdPaciente { get => idPaciente; set => idPaciente = value; }
        public int IdMedico { get => idMedico; set => idMedico = value; }
        public DateTime FechaTurno { get => fechaTurno; set => fechaTurno = value; }
        public string HoraTurno { get => horaTurno; set => horaTurno = value; }
        public decimal Total { get => total; set => total = value; }
        public string Atendido { get => atendido; set => atendido = value; }

        public Turno(int id, int idPaciente, int idMedico, DateTime fechaTurno, string horaTurno,
            decimal total)
        {
            this.id = id;
            this.idPaciente = idPaciente;
            this.idMedico = idMedico;
            this.fechaTurno = fechaTurno;
            this.horaTurno = horaTurno;
            this.total = total;
        }

        public Turno(int idPaciente, int idMedico, DateTime fechaTurno, string horaTurno, decimal total)
        {
            this.idPaciente = idPaciente;
            this.idMedico = idMedico;
            this.fechaTurno = fechaTurno;
            this.horaTurno = horaTurno;
            this.total = total;
        }

        public Turno(int id, DateTime fechaTurno, string horaTurno)
        {
            this.id = id;
            this.fechaTurno = fechaTurno;
            this.horaTurno = horaTurno;
        }

    }
}
