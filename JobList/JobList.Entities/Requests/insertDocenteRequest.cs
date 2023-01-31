namespace JobList.Entities.Requests
{
    public class insertDocenteRequest
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public readonly int idTipo = 3;
        public int idNuevoUsuario { get; set; }
        public int idNuevoDocente { get; set; }
    }
}
