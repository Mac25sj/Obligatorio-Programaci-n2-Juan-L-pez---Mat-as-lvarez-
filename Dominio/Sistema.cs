using Dominio;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Sistema
{
    private static Sistema _instancia;
    private List<Equipo> _equipos = new List<Equipo>();
    private List<Usuario> _usuarios = new List<Usuario>();
    private List<Pago> _pagos = new List<Pago>();
    private List<TipoDeGasto> _gastos = new List<TipoDeGasto>();

    public List<Usuario> Usuarios
    {

        get
        {
            _usuarios.Sort();
            return _usuarios;
        }
    }

    public static Sistema Instancia
    {
        get
        {
            if (_instancia == null) _instancia = new Sistema();
            return _instancia;
        }
    }
    public Sistema()
    {
        precargaDeEquipos();
        precargaDeUsuarios();
        precargaDeTiposDeGastos();
        precargaDePagos();


    }

    private void precargaDeEquipos()
    {
        string[] nombresEquipos = { "Ventas", "Marketing", "RRHH", "Desarrollo" };
        foreach (var nombre in nombresEquipos)
        {
            altaEquipo(nombre);
        }
    }



    private void precargaDeUsuarios()
    {
        // Gerentes por equipo
        altaUsuario("Juan", "Pérez", "pass01", "Ventas", new DateTime(2025, 01, 10), rol.Gerente);
        altaUsuario("María", "Gómez", "pass02", "Marketing", new DateTime(2025, 02, 15), rol.Gerente);
        altaUsuario("Luis", "Rodríguez", "pass03", "RRHH", new DateTime(2025, 03, 20), rol.Gerente);
        altaUsuario("Ana", "Fernández", "pass04", "Desarrollo", new DateTime(2025, 04, 25), rol.Gerente);
        // Empleados
        altaUsuario("Carlos", "López", "pass05", "Ventas", new DateTime(2025, 05, 30), rol.Empleado);
        altaUsuario("Laura", "Martínez", "pass06", "Marketing", new DateTime(2025, 06, 05), rol.Empleado);
        altaUsuario("Diego", "Sánchez", "pass07", "RRHH", new DateTime(2025, 07, 10), rol.Empleado);
        altaUsuario("Sofía", "Ramírez", "pass08", "Desarrollo", new DateTime(2025, 08, 15), rol.Empleado);
        altaUsuario("Pedro", "Torres", "pass09", "Ventas", new DateTime(2025, 09, 20), rol.Empleado);
        altaUsuario("Valentina", "Flores", "pass10", "Marketing", new DateTime(2025, 09, 30), rol.Empleado);
        altaUsuario("Martín", "Silva", "pass11", "RRHH", new DateTime(2025, 09, 30), rol.Empleado);
        altaUsuario("Camila", "Castro", "pass12", "Desarrollo", new DateTime(2025, 09, 30), rol.Empleado);
        altaUsuario("Joaquín", "Ramos", "pass13", "Ventas", new DateTime(2025, 01, 10), rol.Empleado);
        altaUsuario("Lucía", "Vega", "pass14", "Marketing", new DateTime(2025, 02, 15), rol.Empleado);
        altaUsuario("Federico", "Molina", "pass15", "RRHH", new DateTime(2025, 03, 20), rol.Empleado);
        altaUsuario("Julieta", "Acosta", "pass16", "Desarrollo", new DateTime(2025, 04, 25), rol.Empleado);
        altaUsuario("Tomás", "Reyes", "pass17", "Ventas", new DateTime(2025, 05, 30), rol.Empleado);
        altaUsuario("Agustina", "Cabrera", "pass18", "Marketing", new DateTime(2025, 06, 05), rol.Empleado);
        altaUsuario("Emiliano", "Suárez", "pass19", "RRHH", new DateTime(2025, 07, 10), rol.Empleado);
        altaUsuario("Bianca", "Morales", "pass20", "Desarrollo", new DateTime(2025, 08, 15), rol.Empleado);
        altaUsuario("Mateo", "Navarro", "pass21", "Ventas", new DateTime(2025, 09, 20), rol.Empleado);
        altaUsuario("Isabella", "Ortega", "pass22", "Marketing", new DateTime(2025, 09, 30), rol.Empleado);
    }



    private void precargaDePagos()
    {
    
        DateTime hoy = DateTime.Now;
        altaPagoUnico(new Unico(hoy.AddDays(-300), 1001, TipoDePago.CREDITO, _gastos[1], 1150, _usuarios[1]));
        altaPagoUnico(new Unico(hoy.AddDays(-270), 1002, TipoDePago.DEBITO, _gastos[6], 1300, _usuarios[2]));
        altaPagoUnico(new Unico(hoy.AddDays(-5), 1003, TipoDePago.EFECTIVO, _gastos[11], 1450, _usuarios[3]));
        altaPagoUnico(new Unico(hoy.AddDays(-5), 1004, TipoDePago.CREDITO, _gastos[16], 1600, _usuarios[4]));
        altaPagoUnico(new Unico(hoy.AddDays(-180), 1005, TipoDePago.DEBITO, _gastos[2], 1750, _usuarios[5]));
        altaPagoUnico(new Unico(hoy.AddDays(-150), 1006, TipoDePago.EFECTIVO, _gastos[7], 1900, _usuarios[6]));
        altaPagoUnico(new Unico(hoy.AddDays(-120), 1007, TipoDePago.CREDITO, _gastos[12], 2050, _usuarios[7]));
        altaPagoUnico(new Unico(hoy.AddDays(-90), 1008, TipoDePago.DEBITO, _gastos[17], 2200, _usuarios[8]));
        altaPagoUnico(new Unico(hoy.AddDays(-60), 1009, TipoDePago.EFECTIVO, _gastos[3], 2350, _usuarios[9]));
        altaPagoUnico(new Unico(hoy.AddDays(-30), 1010, TipoDePago.CREDITO, _gastos[8], 2500, _usuarios[10]));
        altaPagoUnico(new Unico(hoy.AddDays(-30), 1011, TipoDePago.DEBITO, _gastos[13], 2650, _usuarios[11]));
        altaPagoUnico(new Unico(hoy.AddDays(-65), 1012, TipoDePago.EFECTIVO, _gastos[14], 10300, _usuarios[1]));
        altaPagoUnico(new Unico(hoy.AddDays(-64), 1013, TipoDePago.CREDITO, _gastos[15], 10450, _usuarios[2]));
        altaPagoUnico(new Unico(hoy.AddDays(-63), 1014, TipoDePago.DEBITO, _gastos[16], 10600, _usuarios[3]));
        altaPagoUnico(new Unico(hoy.AddDays(-62), 1015, TipoDePago.EFECTIVO, _gastos[17], 10750, _usuarios[4]));
        altaPagoUnico(new Unico(hoy.AddDays(-61), 1016, TipoDePago.CREDITO, _gastos[18], 10900, _usuarios[5]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-160), hoy.AddDays(-60), TipoDePago.EFECTIVO, _gastos[18], 2800, _usuarios[12]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-145), hoy.AddDays(-56), TipoDePago.CREDITO, _gastos[4], 2950, _usuarios[13]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-130), hoy.AddDays(-55), TipoDePago.DEBITO, _gastos[9], 3100, _usuarios[14]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-115), hoy.AddDays(-54), TipoDePago.EFECTIVO, _gastos[14], 3250, _usuarios[15]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-100), hoy.AddDays(-53), TipoDePago.CREDITO, _gastos[19], 3400, _usuarios[16]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-60), hoy.AddDays(30), TipoDePago.DEBITO, _gastos[5], 3550, _usuarios[17]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-59), hoy.AddDays(31), TipoDePago.EFECTIVO, _gastos[10], 3700, _usuarios[18]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-58), hoy.AddDays(32), TipoDePago.CREDITO, _gastos[15], 3850, _usuarios[19]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-57), hoy.AddDays(33), TipoDePago.DEBITO, _gastos[20], 4000, _usuarios[20]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-160), hoy.AddDays(-60), TipoDePago.CREDITO, _gastos[21], 7400, _usuarios[1]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-145), hoy.AddDays(-56), TipoDePago.DEBITO, _gastos[22], 7550, _usuarios[2]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-130), hoy.AddDays(200), TipoDePago.EFECTIVO, _gastos[23], 7700, _usuarios[3]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-115), hoy.AddDays(70), TipoDePago.CREDITO, _gastos[24], 7850, _usuarios[4]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-100), hoy.AddDays(-53), TipoDePago.DEBITO, _gastos[25], 8000, _usuarios[5]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-85), hoy.AddDays(-52), TipoDePago.EFECTIVO, _gastos[26], 8150, _usuarios[6]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-80), hoy.AddDays(-51), TipoDePago.CREDITO, _gastos[27], 8300, _usuarios[7]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-49), hoy.AddDays(41), TipoDePago.DEBITO, _gastos[28], 8450, _usuarios[8]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-48), hoy.AddDays(42), TipoDePago.EFECTIVO, _gastos[29], 8600, _usuarios[9]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-47), hoy.AddDays(43), TipoDePago.CREDITO, _gastos[1], 8750, _usuarios[10]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-46), hoy.AddDays(44), TipoDePago.DEBITO, _gastos[2], 8900, _usuarios[11]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-45), hoy.AddDays(45), TipoDePago.EFECTIVO, _gastos[3], 9050, _usuarios[12]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-44), hoy.AddDays(46), TipoDePago.CREDITO, _gastos[4], 9200, _usuarios[13]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-43), hoy.AddDays(47), TipoDePago.DEBITO, _gastos[5], 9350, _usuarios[14]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-42), hoy.AddDays(48), TipoDePago.EFECTIVO, _gastos[6], 9500, _usuarios[15]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-41), hoy.AddDays(49), TipoDePago.CREDITO, _gastos[7], 9650, _usuarios[16]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-40), hoy.AddDays(50), TipoDePago.DEBITO, _gastos[8], 9800, _usuarios[17]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-39), hoy.AddDays(51), TipoDePago.EFECTIVO, _gastos[9], 9950, _usuarios[18]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-38), hoy.AddDays(52), TipoDePago.CREDITO, _gastos[10], 10100, _usuarios[19]));
        altaPagoRecurrente(new Recurrente(hoy.AddDays(-37), hoy.AddDays(53), TipoDePago.DEBITO, _gastos[11], 10250, _usuarios[20]));

    }


    private void precargaDeTiposDeGastos()
    {
        AltaGastosTipo("Alimentación", "Gastos relacionados con comidas y bebidas");
        AltaGastosTipo("Transporte", "Gastos relacionados con desplazamientos y transporte");
        AltaGastosTipo("Alojamiento", "Gastos relacionados con hospedaje y estadías");
        AltaGastosTipo("Entretenimiento", "Gastos relacionados con actividades recreativas y de ocio");
        AltaGastosTipo("Oficina", "Gastos relacionados con suministros y servicios de oficina");
        AltaGastosTipo("Tecnología", "Gastos relacionados con dispositivos y software tecnológico");
        AltaGastosTipo("Salud", "Gastos relacionados con servicios médicos y bienestar");
        AltaGastosTipo("Educación", "Gastos relacionados con formación y desarrollo profesional");
        AltaGastosTipo("Viajes", "Gastos relacionados con desplazamientos laborales o personales");
        AltaGastosTipo("Otros", "Gastos diversos no categorizados en otras áreas");
        AltaGastosTipo("Vestimenta", "Gastos relacionados con ropa, calzado y accesorios");
        AltaGastosTipo("Mascotas", "Gastos relacionados con el cuidado y alimentación de animales domésticos");
        AltaGastosTipo("Regalos", "Gastos relacionados con obsequios y celebraciones");
        AltaGastosTipo("Impuestos", "Gastos relacionados con tributos, tasas y contribuciones");
        AltaGastosTipo("Servicios públicos", "Gastos relacionados con agua, luz, gas y otros servicios esenciales");
        AltaGastosTipo("Mantenimiento", "Gastos relacionados con reparaciones y conservación de bienes");
        AltaGastosTipo("Hogar", "Gastos relacionados con artículos y servicios para el hogar");
        AltaGastosTipo("Seguros", "Gastos relacionados con pólizas de seguros personales o laborales");
        AltaGastosTipo("Legal", "Gastos relacionados con asesoramiento y trámites jurídicos");
        AltaGastosTipo("Financieros", "Gastos relacionados con comisiones bancarias y servicios financieros");
        AltaGastosTipo("Publicidad", "Gastos relacionados con promoción y marketing");
        AltaGastosTipo("Consultoría", "Gastos relacionados con asesoramiento profesional externo");
        AltaGastosTipo("Eventos", "Gastos relacionados con organización y participación en eventos");
        AltaGastosTipo("Donaciones", "Gastos relacionados con aportes voluntarios a organizaciones o causas");
        AltaGastosTipo("Electrodomésticos", "Gastos relacionados con compra y reparación de electrodomésticos");
        AltaGastosTipo("Recreación infantil", "Gastos relacionados con actividades y productos para niños");
        AltaGastosTipo("Suscripciones", "Gastos relacionados con servicios periódicos como revistas, plataformas digitales, etc.");
        AltaGastosTipo("Papelería", "Gastos relacionados con materiales de escritura y oficina");
        AltaGastosTipo("Comunicaciones", "Gastos relacionados con telefonía, internet y servicios de comunicación");
        AltaGastosTipo("Emergencias", "Gastos imprevistos por situaciones urgentes o excepcionales");
    }


    //Inicio Alta Usuario
    public void altaUsuario(string nombre, string apellido, string contrasena, string pertenece, DateTime incorporacionEmpresa, rol unRol)
    {
        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(apellido) ||
            string.IsNullOrWhiteSpace(contrasena) ||
            string.IsNullOrWhiteSpace(pertenece) ||
            incorporacionEmpresa == DateTime.MinValue ||
            EncontrarUnEquipo(pertenece) == null)
        {
            throw new Exception("Campo vacío detectado o equipo inválido.");
        }

        string email = crearEmail(nombre, apellido, pertenece);
        int nuevoId = GenerarNuevoId();

        Usuario nuevoUsuario = new Usuario(nuevoId, nombre, apellido, contrasena, email, EncontrarUnEquipo(pertenece), incorporacionEmpresa,unRol);
        _usuarios.Add(nuevoUsuario);
    }







    public void AltaGastosTipo(string nombre, string descripcion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new Exception("El nombre no puede ser nulo ni vacío");
        }

        if (string.IsNullOrWhiteSpace(descripcion))
        {
            throw new Exception("La descripción no puede ser nula ni vacía");
        }

        TipoDeGasto nuevoTipoDeGasto = new TipoDeGasto(nombre, descripcion);
        _gastos.Add(nuevoTipoDeGasto);
    }


    public Equipo EncontrarUnEquipo(string Nombre)
    {
        foreach (Equipo unEquipo in _equipos)
        {
            if (unEquipo.Nombre == Nombre)
            {
                return unEquipo;
            }
        }

        return null;
        //throw new Exception("No se encontró el equipo ⚠️⚠️⚠️⚠️");


    }


    //Alta de Pago Inicio Fin 



    //Listar Pagos Inicio

    public List<Pago> ListarGastosEnElMes()
    {
        List<Pago> resultado = new List<Pago>();

        foreach (Pago unPago in _pagos)
        {
            if (unPago is Unico)
            {
                Unico pagoUnico = (Unico)unPago;
                if (pagoEsteMes(pagoUnico.FechaDePago))
                {
                    resultado.Add(pagoUnico);
                }

            }
            else
            {
                resultado.Add(unPago);
            }
        }
        return resultado;
    }

    //Listar Pagos 
    public void AltaDePago(Pago unPago)
    {
        unPago.Validar();
        _pagos.Add(unPago);
    }


    //Alta de Usuario


    public void altaEquipo(string nombre)
    {
        if (nombre == null)
        {
            throw new Exception("El nombre no puede ser nulo");
        }
        Equipo nuevoEquipo = new Equipo(nombre);

        _equipos.Add(nuevoEquipo);
    }

    //Alta de Usuario Fin


    //Altas de Pagos
    public void altaPagoUnico(Unico pagoUnico)
    {
        if (pagoUnico == null)
        {
            throw new Exception("El pago no puede ser nulo");

        }
        pagoUnico.Validar();
        _pagos.Add(pagoUnico);


    }
    public void altaPagoRecurrente(Recurrente pagoRecurrente)
    {
        if (pagoRecurrente == null)
        {
            throw new Exception("El pago no puede ser nulo");

        }
        pagoRecurrente.Validar();
        _pagos.Add(pagoRecurrente);

    }



    //Crear Email
    private string crearEmail(string nombre, string apellido, string nombreEquipo)
    {
        string resultado = "";

        for (int i = 0; i < 3 && i < nombre.Length; i++)
        {
            resultado += nombre[i];
        }

        for (int i = 0; i < 3 && i < apellido.Length; i++)
        {
            resultado += apellido[i];
        }

        resultado += $"@{nombreEquipo}";

        return resultado.ToLower();
    }
    //Crear Email Fin





    //Auxiliar


    //Chequear si el pago es de este mes
    public bool pagoEsteMes(DateTime unaFecha)
    {
        if (unaFecha > DateTime.Now.AddMonths(-1))
        {
            return true;
        }
        return false;
    }
    public List<Pago> comprasPorEmail(string email)
    {
        List<Pago> resultado = new List<Pago>();
        foreach (Pago unPago in _pagos)
        {
            if (unPago.esMiMail(email))
            {
                resultado.Add(unPago);
            }

        }
        return resultado;
    }


    public List<Usuario> EsMiEquipo(string nombreDeEquipo)

    {

        List<Usuario> resultado = new List<Usuario>();
        foreach (Usuario unUsuario in _usuarios)
        {
            if (unUsuario.Pertenece.Nombre == nombreDeEquipo)
            {
                resultado.Add(unUsuario);
            }
        }
        return resultado;

    }

    public Usuario iniciarSesion(string email, string contrasena)
    {
        foreach (Usuario u in _usuarios)
        {
            if (u.Email.ToUpper() == email.ToUpper() && u.Contrasena == contrasena)
                return u;
        }
        return null;
    }


    //Para empleado

    public void CargarPagos(Pago unPago)
    {
        unPago.Validar();
        AltaDePago(unPago);
    }



    public List<Pago> ListarPagos(Usuario unUsuario)
    {
        List<Pago> resultado = new List<Pago>();

        foreach (Pago unPago in _pagos)
        {
            if (unPago.NombreUsuario.Equals(unUsuario))
            {

                resultado.Add(unPago);
            }

        }
        return resultado;
    }


    //Para gerente (todos los listados para equipo.con mes y año

    public List<Pago> ListarPagosPorFechayEquipo(Equipo unEquipo, DateTime fecha)
    {
        List<Pago> resultado = new List<Pago>();

        foreach (Pago unPago in _pagos)
        {
            if (unPago.NombreUsuario.Pertenece.Equals(unEquipo)
               &&  unPago.EntreFecha(fecha))
            {
                
                resultado.Add(unPago);
            }

        }
        return resultado;

    }

    public Usuario ObtenerUsuariobyID(int id)
    {
foreach ( Usuario u in Usuarios)
        {
            if (u.Id == id) return u;
        }
        return null;
    }
    public List<TipoDeGasto> obtenerListaTipoGasto()
    {
        List<TipoDeGasto> resultado = new List<TipoDeGasto>();
        foreach (TipoDeGasto t in _gastos)
        {
            resultado.Add(t);
        }
        return resultado;
    }
    public  double GastosTotalesPorEquipoEnElMes (Equipo unEquipo, DateTime unaFecha )
    {
        double montoFinal = 0;
        List<Pago> gastosEquipo = ListarPagosPorFechayEquipo(unEquipo, unaFecha);
        foreach (Pago p in gastosEquipo)
        {
            montoFinal += p.Monto;
        }
        return montoFinal;

    }




    private int GenerarNuevoId()
    {
        return _usuarios.Count + 1;
    }

    public List<Usuario> ListaUsuariosPorEquipo(Equipo unEquipo)
    {
        List<Usuario> miEquipo = new List<Usuario>();
        foreach (Usuario u in _usuarios)
        {
            if (u.Pertenece == unEquipo)
            {
                miEquipo.Add(u);
            }
        }
        return miEquipo;
    }


    public bool ExisteTipoDeGasto(string nombre)
    {
        foreach (TipoDeGasto t in _gastos)
        {
            if (t.Nombre == nombre)
            {
                return true;
            }
        }
        return false;
    }



    public void BajaDePago(string Nombre)
    {
        for (int i = _gastos.Count - 1; i >= 0; i--)
        {
            if (_gastos[i].Nombre == Nombre)
            {
                _gastos.RemoveAt(i);
            }

        }
    }

}
