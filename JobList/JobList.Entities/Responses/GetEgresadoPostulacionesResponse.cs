namespace JobList.Entities.Responses
{
    public class GetEgresadoPostulacionesResponse
    {
        public int idPostulacion { get; set; }
        public string fechaPostulacion { get; set; } = default!;
        public string empresa { get; set; } = default!;
        public string descripcionPuesto { get; set; } = default!;
        public string area { get; set; } = default!;
        public string division { get; set; } = default!;
        public string estadoPostulacion { get; set; } = default!;
        public DatosContactoAceptado datoContacto { get; set; } = default!;
    }

    public class DatosContactoAceptado
    {
        public bool success { get; set; }
        public string nombreResponsable { get; set; } = default!;
        public string telefonoResponsable { get; set; } = default!;
        public string correoResponsable { get; set; } = default!;
    }
}
