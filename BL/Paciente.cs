
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Paciente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.JguevaraNetCoreContext context = new DL.JguevaraNetCoreContext())
                {
                    var query = context.Pacientes.FromSqlRaw("PacienteGetAll").ToList(); //ejecutamos el SP de la BD, pero directamente en la tabla donde va a hacer la accion

                    if(query.Any())
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.IdPaciente = obj.IdPaciente;
                            paciente.Nombre = obj.Nombre;
                            paciente.ApellidoPaterno = obj.ApellidoPaterno;
                            paciente.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(paciente);
                        }

                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay Pacientes";
                    }

                }

            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException?.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
