
namespace PL
{
    public class RecetaMedica
    {
        public static void GetAll()
        {
            ML.Result result = BL.RecetaMedica.GetAll();
            if (result.Correct)
            {
                foreach(ML.RecetaMedica receta in result.Objects)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine("ID receta: "+receta.IdReceta);
                    Console.WriteLine("Nombre Paciente: "+receta.Paciente.Nombre);
                    Console.WriteLine("Fecha de Consulta: " + receta.FechaConsulta);
                    Console.WriteLine("Diagnostico: " + receta.Diagnostico);
                    Console.WriteLine("Nombre Médico: " + receta.NombreMedico);
                    Console.WriteLine("Notas Adicionales: " + receta.NotasAdicionales);
                }
            }
        }
        public static void GetByIdPaciente(int idPaciente)
        {
            ML.Result result = BL.RecetaMedica.GetByIdPaciente(idPaciente);
            if (result.Correct)
            {
                foreach (ML.RecetaMedica receta in result.Objects)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine("ID receta: " + receta.IdReceta);
                    Console.WriteLine("Nombre Paciente: " + receta.Paciente.Nombre);
                    Console.WriteLine("Fecha de Consulta: " + receta.FechaConsulta);
                    Console.WriteLine("Diagnostico: " + receta.Diagnostico);
                    Console.WriteLine("Nombre Médico: " + receta.NombreMedico);
                    Console.WriteLine("Notas Adicionales: " + receta.NotasAdicionales);
                }
            }
        }
        public static void Add()
        {
            ML.RecetaMedica receta = new ML.RecetaMedica();

            Console.Write("Fecha Consulta: ");
            receta.FechaConsulta = Console.ReadLine();
            Console.Write("Diagnostico: ");
            receta.Diagnostico = Console.ReadLine();
            Console.Write("Nombre del Medico: ");
            receta.NombreMedico = Console.ReadLine();
            Console.Write("Notas Adicionales: ");
            receta.NotasAdicionales = Console.ReadLine();

            receta.Paciente = new ML.Paciente();
            Console.Write("Id del paciente: ");
            receta.Paciente.IdPaciente = int.Parse(Console.ReadLine());

            ML.Result result = BL.RecetaMedica.Add(receta);
            if (result.Correct)
            {
                Console.WriteLine("Receta agregada correctamente");
            }
            else
            {
                Console.WriteLine("ERROR " + result.ErrorMessage);
            }
        }
        public static void Update()
        {
            ML.RecetaMedica receta = new ML.RecetaMedica();

            Console.Write("Nueva Fecha Consulta: ");
            receta.FechaConsulta = Console.ReadLine();
            Console.Write("Nuevo Diagnostico: ");
            receta.Diagnostico = Console.ReadLine();
            Console.Write("Nuevo Nombre del Medico: ");
            receta.NombreMedico = Console.ReadLine();
            Console.Write("Nuevas Notas Adicionales: ");
            receta.NotasAdicionales = Console.ReadLine();

            receta.Paciente = new ML.Paciente();
            Console.Write("Id del paciente a actualizar: ");
            receta.Paciente.IdPaciente = int.Parse(Console.ReadLine());
            Console.Write("Id de la receta a actualizar: ");
            receta.IdReceta = int.Parse(Console.ReadLine());

            ML.Result result = BL.RecetaMedica.Update(receta);
            if (result.Correct)
            {
                Console.WriteLine("Receta actualizada correctamente");
            }
            else
            {
                Console.WriteLine("ERROR " + result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            Console.Write("Dame el id del paciente");
            int idPaciente = int.Parse(Console.ReadLine());
            Console.Write("Dame el id de la receta");
            int idReceta = int.Parse(Console.ReadLine());

            ML.Result result = BL.RecetaMedica.Delete(idPaciente, idReceta);
            if(result.Correct)
            {
                Console.WriteLine("La receta se ha borrado");
            } else
            {
                Console.WriteLine("ERROR "+result.ErrorMessage);
            }
            Console.WriteLine();
        }
    }
}
