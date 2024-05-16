using System;
using System.Collections.Generic;

class ProgramaPrincipal
{
    static void Main(string[] args)
    {

        bool cambios;
        int eleccion, clave, idBuscar, nuevoTipo, nuevaCantidad;
        List<string> EstadisticasTicketera = new List<string>();
        do
        {

            MostrarMenu();
            eleccion = PedirNumero("Ingrese una opción:", 0, 6);
            switch (eleccion)
            {
                case 1:
                    Cliente clienteNuevo = Inscripción();
                    clave = Tiquetera.AgregarCliente(clienteNuevo);
                    break;

                case 2:
                    EstadisticasTicketera = Tiquetera.estadisticas();
                    MostrarEstadisticas(EstadisticasTicketera);
                    break;

                case 3:
                    Cliente clienteEncontrado = null;
                    idBuscar = PedirNumero("Ingrese el id de la persona que quiere buscar", 0, 999999999);
                    clienteEncontrado = Tiquetera.BuscarClientes(idBuscar);
                    if (clienteEncontrado != null)
                    {
                        MostrarDatosCliente(clienteEncontrado);
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ningún cliente con el ID proporcionado.");
                    }
                    break;



                case 4:
                    Cliente nuevoCL = null;
                    idBuscar = PedirNumero("Ingrese el id de la persona que quiere cambiar los datos", 0, 999999999);
                    nuevoCL = Tiquetera.BuscarClientes(idBuscar);
                    nuevaCantidad = PedirNumero("Ingrese nueva cantidad", int.MinValue, int.MaxValue);
                    nuevoTipo = PedirNumero("Ingrese nuevo tipo de entrada", 0, 5);
                    cambios = Tiquetera.CambiarEntrada(idBuscar, nuevoTipo, nuevaCantidad);
                    if (cambios)
                        Console.WriteLine("Los cambios se han hecho correctamente");
                    else
                        Console.WriteLine("No se ha encontrado el id proporcionado");
                    break;


                case 5:
                Console.WriteLine("Usted decidio terminar el programa");    
                    break;

            }

        } while (eleccion != 5);
    }
    static void MostrarDatosCliente(Cliente CL)
    {
        Console.WriteLine($"Nombre: {CL.Nombre}");
        Console.WriteLine($"Apellido: {CL.Apellido}");
        Console.WriteLine($"DNI: {CL.DNI}");
        Console.WriteLine($"Cantidad de entradas compradas: {CL.Cantidad}");
        Console.WriteLine($"Fecha inscripción {CL.FechaInscripcion}");
        Console.WriteLine($"Tipo de entrada elegido: {CL.TipoEntrada}");

    }
    static void MostrarMenu()
    {
        Console.WriteLine(@"1.Nueva Inscripción
2.Obtener Estadísticas del Evento
3.Buscar Cliente
4.Cambiar entrada de un Cliente
5.Salir");
    }

    static Cliente Inscripción()
    {
        int dni;
        dni = PedirNumero("Ingrese su DNI", 0, 999999999);
        string apellido = PedirString("Ingrese su apellido");
        string nombre = PedirString("Ingrese su nombre");
        DateTime fecha = PedirFecha("Ingrese su fecha");
        int tipoEntrada = PedirNumero(@"Opción 1 - Día 1, valor a abonar $45000
Opción 2 - Día 2, valor a abonar $60000
Opción 3 - Día 3, valor a abonar $30000
Opción 4 - Full Pass, valor a abonar $100000", 1, 4);
        int cantidad = PedirNumero("Ingrese la cantidad de entradas", 0, 9999999);

        Cliente clienteNuevo = new Cliente(dni, apellido, nombre, fecha, tipoEntrada, cantidad);

        return clienteNuevo;
    }

    static DateTime PedirFecha(string mensaje)
    {
        bool esValido = false;
        DateTime fecha;
        string fechaPedida = "";
        do
        {
            Console.WriteLine(mensaje);
            fechaPedida = Console.ReadLine();
            esValido = DateTime.TryParse(fechaPedida, out fecha);
        } while (!esValido);

        return fecha;
    }

    static string PedirString(string mensaje)
    {
        string palabra;
        do
        {
            Console.WriteLine(mensaje);
            palabra = Console.ReadLine();

        } while (palabra == string.Empty);
        return palabra;
    }

    static int PedirNumero(string mensaje, int min, int max)
    {
        int numero;
        do
        {
            Console.WriteLine(mensaje);
            numero = int.Parse(Console.ReadLine());
        } while (numero < min || numero > max);
        return numero;
    }

    static int PrecioAbono(Cliente clienteAbono)
    {
        int cantAbono = 0;
        switch (clienteAbono.TipoEntrada)
        {
            case 1:
                cantAbono = 45000;
                break;
            case 2:
                cantAbono = 60000;
                break;
            case 3:
                cantAbono = 30000;
                break;
            case 4:
                cantAbono = 100000;
                break;
            default:
                cantAbono = 0;
                break;
        }
        return cantAbono;
    }

    static void MostrarEstadisticas(List<string> listaEstadistica)
    {
        Console.WriteLine($"Cantidad de clientes: {listaEstadistica[0]}");
        Console.WriteLine($"Cantidad de entradas: {listaEstadistica[1]}");
        Console.WriteLine($"Porcentaje de entradas: {listaEstadistica[2]}");
        Console.WriteLine($"Abono entradas: {listaEstadistica[3]}");
        Console.WriteLine($"Recaudación total {listaEstadistica[4]}");
    }

}
