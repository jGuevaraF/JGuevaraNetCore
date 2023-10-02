using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class RecetaMedica
    {
        public static ML.Result GetAll(int idPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.JguevaraNetCoreContext context = new DL.JguevaraNetCoreContext())
                {
                    var query = context.RecetaMedicas.FromSqlRaw($"RecetaMedicaGetAll {idPaciente}").ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
                            recetaMedica.IdReceta = obj.IdReceta;
                            recetaMedica.FechaConsulta = obj.FechaConsulta?.ToString("dd/MM/yyyy");
                            recetaMedica.Diagnostico = obj.Diagnostico;
                            recetaMedica.NombreMedico = obj.NombreMedico;
                            recetaMedica.NotasAdicionales = obj.NotasAdicionales;

                            //recetaMedica.Paciente = new ML.Paciente();
                            //recetaMedica.Paciente.IdPaciente = (int) obj.IdPaciente;
                            //recetaMedica.Paciente.Nombre = obj.NombrePaciente;
                            //recetaMedica.Paciente.ApellidoPaterno = obj.ApellidoPaterno;
                            //recetaMedica.Paciente.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(recetaMedica);
                        }

                        result.Correct = true;
                    }
                }

            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Add(ML.RecetaMedica receta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JguevaraNetCoreContext context = new DL.JguevaraNetCoreContext()) //solo me trae la conexion(tablas) y no mas
                {
                    int filasAfectadas = context.Database.ExecuteSqlRaw($"RecetaMedicaAdd '{receta.FechaConsulta}', '{receta.Diagnostico}', '{receta.NombreMedico}', '{receta.NotasAdicionales}', {receta.Paciente?.IdPaciente}");//comando para ejecutar el SP de la BD, y devuelve las filas afectadas

                    if(filasAfectadas > 0)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar";
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
        public static ML.Result GetByIdPaciente (int idPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JguevaraNetCoreContext context = new DL.JguevaraNetCoreContext())
                {
                    var query = context.RecetaMedicas.FromSqlRaw($"RecetaMedicaGetByIdPaciente {idPaciente}").ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
                            recetaMedica.IdReceta = obj.IdReceta;
                            recetaMedica.FechaConsulta = obj.FechaConsulta.ToString();
                            recetaMedica.Diagnostico = obj.Diagnostico;
                            recetaMedica.NombreMedico = obj.NombreMedico;
                            recetaMedica.NotasAdicionales = obj.NotasAdicionales;

                            recetaMedica.Paciente = new ML.Paciente();
                            recetaMedica.Paciente.IdPaciente = (int)obj.IdPaciente;
                            recetaMedica.Paciente.Nombre = obj.NombrePaciente;
                            recetaMedica.Paciente.ApellidoPaterno = obj.ApellidoPaterno;
                            recetaMedica.Paciente.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(recetaMedica);
                        }

                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result GetByIdReceta (int idPaciente, int idReceta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JguevaraNetCoreContext context = new DL.JguevaraNetCoreContext())
                {
                    var query = context.RecetaMedicas.FromSqlRaw($"RecetaMedicaGetById {idPaciente}, {idReceta}").AsEnumerable().SingleOrDefault();
                    if(query != null)
                    {
                        ML.RecetaMedica receta = new ML.RecetaMedica();
                        receta.IdReceta = query.IdReceta;
                        receta.FechaConsulta = query.FechaConsulta?.ToString("dd/MM/yyyy");
                        receta.NombreMedico = query.NombreMedico;
                        receta.Diagnostico = query.Diagnostico;
                        receta.NotasAdicionales = query.NotasAdicionales;

                        result.Object = receta;
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "ERROR al obtener la receta";
                    }
                }

            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Update(ML.RecetaMedica receta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.JguevaraNetCoreContext context = new DL.JguevaraNetCoreContext())
                {
                    int filasAfectadas = context.Database.ExecuteSqlRaw($"RecetaMedicaUpdate {receta.Paciente.IdPaciente}, {receta.IdReceta}, '{receta.FechaConsulta}', '{receta.Diagnostico}', '{receta.NombreMedico}', '{receta.NotasAdicionales}'");

                    if(filasAfectadas > 0)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar";
                    }
                }

            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Delete (int idPaciente, int idReceta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.JguevaraNetCoreContext context = new DL.JguevaraNetCoreContext())
                {
                    int recetaBorrada = context.Database.ExecuteSqlRaw($"RecetaMedicaDelete {idReceta}, {idPaciente}");
                    if(recetaBorrada > 0)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo borrar";
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}