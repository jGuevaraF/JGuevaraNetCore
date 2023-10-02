// See https://aka.ms/new-console-template for more information

int opcionMenu = 0, opcioReceta = 0;
do
{
    Console.WriteLine("Que quieres hacer?");
    Console.WriteLine("1. Asignar o ver Recetas");
    Console.WriteLine("2. Ver Pacientes");
    Console.WriteLine("3. Salir");
    opcionMenu = int.Parse(Console.ReadLine());

    switch (opcionMenu)
    {
        case 1:
            do
            {
                Console.WriteLine("Que quieres hacer?");
                Console.WriteLine("1. Agregar Receta");
                Console.WriteLine("2. Ver recetas de todos los pacientes");
                Console.WriteLine("3. Ver receta con el ID del paciente");
                Console.WriteLine("4. Actualizar una receta");
                Console.WriteLine("5. Eliminar Receta");
                Console.WriteLine("6. Salir");
                opcionMenu = int.Parse(Console.ReadLine());

                switch (opcionMenu)
                {
                    case 1:
                        PL.RecetaMedica.Add();
                        break;
                    case 2:
                        PL.RecetaMedica.GetAll();
                        break;
                    case 3:
                        Console.Write("Dame el ID del paciente que quieres ver sus recetas:");
                        int idPaciente = int.Parse(Console.ReadLine());
                        PL.RecetaMedica.GetByIdPaciente(idPaciente);
                        break;
                    case 4:
                        PL.RecetaMedica.Update();
                        break;
                    case 5:
                        PL.RecetaMedica.Delete();
                        break;
                    case 6:
                        return;
                }

            } while (opcioReceta != 6);
            break;
        case 2:
            PL.Paciente.GetAll();
            break;
    }
} while (opcionMenu != 3);
