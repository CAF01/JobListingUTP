namespace JobList.Entities.Models
{
    public class ReadEmpresasAfiliadasResponse
    {
        public int idUsuario { get; set; }
        public string imgUrl { get; set; } = default!;
        public string nombreEmpresa { get;}= default!;
        public string domicilioFiscal { get; set; } = default!;
        public bool banderaEliminar { get; set; }
    }
}
