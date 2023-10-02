using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PLMVC.Controllers
{
    public class RecetaMedicaController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Paciente paciente = new ML.Paciente();
            ML.Result resultPaciente = BL.Paciente.GetAll();
            if (resultPaciente.Correct)
            {
                paciente.Pacientes = resultPaciente.Objects;
                return View(paciente);
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetRecetaMedica(int idPaciente, string nombrePaciente, string apellidoPaterno, string apellidoMaterno)
        {
          
            ML.RecetaMedica receta = new ML.RecetaMedica();
            receta.Paciente = new ML.Paciente();
            ML.Result result = BL.RecetaMedica.GetAll(idPaciente);

            ViewData["idPaciente"] = idPaciente;
            ViewData["nombrePaciente"] = nombrePaciente;
            ViewData["apellidoPaterno"] = apellidoPaterno;
            ViewData["apellidoMaterno"] = apellidoMaterno;

            if(result.Correct)
            {
                receta.RecetasMedicas = result.Objects;
                return View(receta);
            } else
            {
                return View(receta);
            }
            
        }
        [HttpGet]
        public IActionResult Form (int idPaciente, int? idReceta, string nombrePaciente, string apellidoPaterno, string apellidoMaterno)
        {
            ML.RecetaMedica receta = new ML.RecetaMedica ();
            receta.Paciente = new ML.Paciente ();
            receta.Paciente.IdPaciente = idPaciente;
            receta.Paciente.Nombre = nombrePaciente;
            receta.Paciente.ApellidoPaterno = apellidoPaterno;
            receta.Paciente.ApellidoMaterno = apellidoMaterno;

            if (idReceta == null) //add
            {
                return View(receta);
            } else
            {
                ML.Result result = BL.RecetaMedica.GetByIdReceta(idPaciente, idReceta.Value);
                if (result.Correct)
                {
                    receta = (ML.RecetaMedica)result.Object;
                    receta.Paciente = new ML.Paciente();
                    receta.Paciente.IdPaciente = idPaciente;
                    receta.Paciente.Nombre = nombrePaciente;
                    receta.Paciente.ApellidoPaterno = apellidoPaterno;
                    receta.Paciente.ApellidoMaterno = apellidoMaterno;
                    return View(receta);
                } else
                {
                    return View();
                }
                
            }
        }

        [HttpPost]
        public IActionResult Form(ML.RecetaMedica receta)
        {
            ViewData["idPaciente"] = receta.Paciente.IdPaciente;
            ViewData["nombrePaciente"] = receta.Paciente.Nombre;
            ViewData["apellidoPaterno"] = receta.Paciente.ApellidoPaterno;
            ViewData["apellidoMaterno"] = receta.Paciente.ApellidoMaterno;

            if (receta.IdReceta == 0)//add
            {
                ML.Result result = BL.RecetaMedica.Add(receta);
                if (result.Correct)
                {

                    ViewBag.Message = "La Receta se ha agreado correctamente";
                    return View("Modal");
                }
            } else
            {
                ML.Result result = BL.RecetaMedica.Update(receta);
                if (result.Correct)
                {
                    ViewBag.Message = "La Receta se ha actualizado correctamente";
                    return View("Modal");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int idPaciente, int idReceta, string nombrePaciente, string apellidoPaterno, string apellidoMaterno)
        {
            ViewData["idPaciente"] = idPaciente;
            ViewData["nombrePaciente"] = nombrePaciente;
            ViewData["apellidoPaterno"] = apellidoPaterno;
            ViewData["apellidoMaterno"] = apellidoMaterno;

            ML.Result result = BL.RecetaMedica.Delete(idPaciente, idReceta);
            if(result.Correct)
            {
                ViewBag.Message = "La Receta se ha eliminado correctamente";
                return View("Modal");
            } else
            {
                return View();
            }
        }
    }
}
