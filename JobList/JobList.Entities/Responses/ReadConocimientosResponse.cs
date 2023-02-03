namespace JobList.Entities.Responses
{
    public class ReadConocimientosResponse
    {
        public int idConocimiento { get; set; }
        public string descripcion { get; set; } = default!;
        public int contadorSeleccion { get; set; }
        public bool banderaEliminar { get; set; }
    }
}
