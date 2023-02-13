namespace JobList.Entities.Responses
{
    public class InsertEmpresaResponse
    {
        public int idEmpresa { get; set; }
        public bool success { get; set; }
        public string mensaje { get; set; } = default!;
    }
}
