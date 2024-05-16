public class Cliente{
public int DNI {get; private set;}
public string Apellido {get; private set;}

public string Nombre {get; private set;}

public DateTime FechaInscripcion {get; set;}

public int TipoEntrada {get; set;}

public int Cantidad {get; set;}

 public Cliente(int dni, string apellido, string nombre, DateTime fechainscripcion, int tipoentrada, int cantidad)
    {

        Nombre = nombre;
        DNI = dni;
        Apellido=apellido;
        FechaInscripcion = fechainscripcion;
        TipoEntrada = tipoentrada;
        Cantidad = cantidad;

    }
}