namespace ML
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public List<object> Pacientes { get; set; }
    }
}