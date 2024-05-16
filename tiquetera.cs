using System.Collections.Generic;
static class Tiquetera{

private static Dictionary <int, Cliente> DicClientes = new Dictionary<int, Cliente>();
private static int UltimoIDEntrada = 0;



static public int AgregarCliente(Cliente cliente)
{
    DicClientes.Add(UltimoIDEntrada, cliente);
    UltimoIDEntrada++;    
    return UltimoIDEntrada;
}

public static Cliente BuscarClientes(int ID)
{
    Cliente nuevoCliente = null; 
    if (DicClientes.ContainsKey(ID))
    {
        nuevoCliente = DicClientes[ID];
    } 
    return nuevoCliente;
}

static public List<string> estadisticas()
{
    int cantClientes, totalEntradas = 0, recaudadcionTotal = 0;
    string cantClientes2, porcentajeEntradas2, recaudadcionTotal2, AbonoEntradas2, totalEntradas2, cantidadEntradas2;
    int[]CantidadEntradas = new int[4];
    int[]PorcentajeEntradas = new int[4];
    int[]AbonoEntradas = new int[4];    

    cantClientes = DicClientes.Count;
    foreach ( Cliente CL in DicClientes.Values)
    {
        if(CL.TipoEntrada == 1)
        CantidadEntradas[0]+= CL.Cantidad;

        if(CL.TipoEntrada == 2)
        CantidadEntradas[1]+= CL.Cantidad;

        if(CL.TipoEntrada == 3)
        CantidadEntradas[2]+=CL.Cantidad;

        if(CL.TipoEntrada == 4)
        CantidadEntradas[3]+=CL.Cantidad;

        totalEntradas += CL.Cantidad;
    }
    PorcentajeEntradas[0] = CantidadEntradas[0] / totalEntradas * 100;
    PorcentajeEntradas[1] = CantidadEntradas[1] / totalEntradas * 100;
    PorcentajeEntradas[2] = CantidadEntradas[2] / totalEntradas * 100;
    PorcentajeEntradas[3] = CantidadEntradas[3] / totalEntradas * 100;

    AbonoEntradas[0] = CantidadEntradas[0]*45000;
    AbonoEntradas[1] = CantidadEntradas[1]*60000;
    AbonoEntradas[2] = CantidadEntradas[2]*30000;
    AbonoEntradas[3] = CantidadEntradas[3]*100000;

    foreach(int recaudacion in AbonoEntradas)
    {
            recaudadcionTotal += recaudacion;
    }
    cantClientes2 = cantClientes.ToString();
    cantidadEntradas2 = String.Join(", ", CantidadEntradas);
    porcentajeEntradas2 = String.Join(", ", PorcentajeEntradas);
    AbonoEntradas2 = String.Join(", ", AbonoEntradas);
    recaudadcionTotal2 = recaudadcionTotal.ToString();

    List <string> EstadisticasTicketera = new List<string>(){cantClientes2, cantidadEntradas2, porcentajeEntradas2, AbonoEntradas2, recaudadcionTotal2};

    return EstadisticasTicketera;
}
static public bool CambiarEntrada(int ID, int Tipo, int cantidad)
{
    if (DicClientes.ContainsKey(ID))
    {
        DicClientes[ID].TipoEntrada = Tipo;
        DicClientes[ID].Cantidad = cantidad;
            return true;
    }
    else return false;

}
}
