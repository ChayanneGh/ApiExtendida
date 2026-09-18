namespace ApiExtendida.Controllers.Modelos
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Reputacion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public int ID_Direccion { get; set; }
    }
}
