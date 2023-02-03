namespace JobList.Entities.Models
{
    public class EmpresaInfo
    {
        public int idUsuario { get; set; }
        public string nombreEmpresa { get; set; } = default!;
        public string token { get; set; } = default!;
    }
}
