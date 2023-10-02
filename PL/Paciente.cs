

namespace PL
{
    public class Paciente
    {
        public static void GetAll()
        {
            ML.Result result = BL.Paciente.GetAll();
            if (result.Correct)
            {
                foreach(ML.Paciente paciente in result.Objects)
                {
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Id paciente: "+paciente.IdPaciente);
                    Console.WriteLine("Nombre: "+paciente.Nombre);
                    Console.WriteLine("Apellido Paterno: "+paciente.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: "+paciente.ApellidoMaterno);
                    Console.WriteLine("-----------------");
                }
            }
        }
    }
}
