namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class UpdateEmpresaDatosRequest : IRequest<UpdateEmpresaDatosResponse>
    {
        public int idUsuario { get; set; }
        public string nombreEmpresa { get; set; } = default!;
        public string RFC { get; set; } = default!;
        public string tamano { get; set; } = default!;
        public string tipoEmpresa { get; set; } = default!;
        public string giroEmpresa { get; set; } = default!;
        public string actividadPrincipal { get; set; } = default!;
        public string domicilio { get; set; } = default!;
        public string CP { get; set; } = default!;
        public string telefonos { get; set; } = default!;
        public string correoElectronico { get; set; } = default!;
        public string acercaEmpresa { get; set; } = default!;

        public string nombreResponsable { get; set; } = default!;
        public string telefonoResponsable { get; set; } = default!;
        public string correoElectronicoResponsable { get; set; } = default!;
    }
}
