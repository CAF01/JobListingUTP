namespace JobList.Entities.Responses
{
    public class UpdatePasswordEgresadoResponse
    {
        public bool success { get; set; }
        public string mensaje { get; set; } = default!;
        public bool EqualPassword { get; set; }
    }
}
