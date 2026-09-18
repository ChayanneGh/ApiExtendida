namespace ApiExtendida.Controllers.Modelos
{
    public class Estudiante
    {
            public int ID_Estudiante { get; set; }
            public string? Nombre { get; set; }    // 2. Con '?' evitas warnings de valores nulos
            public string? Apellido { get; set; }  //    si la base de datos devuelve un NULL
            public string? Telefono { get; set; }
            public int ID_Direccion { get; set; }
    }
}
