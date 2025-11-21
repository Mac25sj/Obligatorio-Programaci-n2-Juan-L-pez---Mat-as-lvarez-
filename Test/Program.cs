using Dominio;

namespace ObligatorioProgramacion2
{
    internal class Program
    {
        static Sistema miSistema = new Sistema();

        static void Main(string[] args)
        {

            string opcion = "";
            while (opcion != "0")
            {
                MostrarMenu();
                Console.Write("Ingrese una opcion -> ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Listado de usuarios:");
                        foreach (Usuario u in miSistema.Usuarios)
                        {
                            Console.WriteLine($"{u.Nombre} {u.Apellido} - {u.Email}");
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("email: ");
                        string email = Console.ReadLine();
                        List<Pago> lista = miSistema.comprasPorEmail(email);
                        foreach (Pago unPago in lista)
                        {
                            Console.WriteLine(unPago.ToString());

                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Alta de usuario:");

                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Apellido: ");
                        string apellido = Console.ReadLine();

                        Console.Write("Contraseña: ");
                        string contrasena = Console.ReadLine();

                        Console.Write("Nombre del equipo: ");
                        string nombreEquipo = Console.ReadLine();

                        Console.Write("Fecha de incorporación (yyyy-mm-dd): ");
                        DateTime fecha;
                        if (!DateTime.TryParse(Console.ReadLine(), out fecha))
                        {
                            Console.WriteLine("Fecha inválida.");
                            break;
                        }

                        Equipo nuevoEquipo = new Equipo(nombreEquipo);
                        try
                        {
                            miSistema.altaUsuario(nombre, apellido, contrasena, nombreEquipo, fecha);
                            Console.WriteLine("Usuario creado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Nombre: ");
                        string nombreEquipoBuscado = Console.ReadLine();
                        if (miSistema.EncontrarUnEquipo(nombreEquipoBuscado) == null)
                        {
                            Console.WriteLine("El equipo no existe");
                            break;
                        }
                        List<Usuario> usuariosEnEquipo = miSistema.EsMiEquipo(nombreEquipoBuscado);
                        foreach (Usuario unUsuario in usuariosEnEquipo)
                        {
                            Console.WriteLine(unUsuario.ToString());
                        }

                        break;
                       

                    case "5":
                        Console.Clear(); 
                        List<Pago> resultado = miSistema.ListarGastosEnElMes();
                        foreach (Pago unPago in resultado)
                        {
                            Console.WriteLine(unPago.ToString());
                        }
  
                        break;
                         

                    case "0":
                        Console.WriteLine("Saliendo...");

                        break;

                    default:
                        Console.WriteLine("⚠️⚠️⚠️ Tecla incorrecta");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
              //  Console.Clear();

            }
        }
        //Inicio Funcionalidad 1
        private static void ListarUsuarios()
        {
            foreach (Usuario usuario in miSistema.Usuarios)
            {
                Console.WriteLine(usuario);
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("****** MENÚ DE GESTIÓN DE GASTOS ******");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1 - Listar todos los usuarios");
            Console.WriteLine("2 - Listar pagos de un usuario por email");
            Console.WriteLine("3 - Alta de usuario");
            Console.WriteLine("4 - Listar usuarios por nombre de equipo");
            Console.WriteLine("5 - Listar gastos del mes actual");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("0 - Salir");
        }
    }
}