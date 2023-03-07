namespace JobList.Entities.Models
{
    public class ReadDetallesEmpresaResponse
    {
        public int idUsuario { get; set; }
        public string nombreEmpresa { get; set; } = default!;
        public string tamano { get; set; } = default!;
        public string giro { get; set; } = default!;
        public string domicilioFiscal { get; set; } = default!;
        public string telefonos { get; set; } = default!;
        public string RFC { get; set; } = default!;
        public string tipo { get; set; } = default!;
        public string actividadPrincipal { get; set; } = default!;
        public string CP { get; set; } = default!;
        public string correoEmpresa { get; set; } = default!;
        public string descripcionEmpresa { get; set; } = default!;
        public string nombreResponsable { get; set; } = default!;
        public string telefonoResponsable { get; set; } = default!;
        public string correoResponsable { get; set; } = default!;
        public Boolean banderaEliminar { get; set; }
        public string imgUrl { get; set; } = default!;
    }
}
