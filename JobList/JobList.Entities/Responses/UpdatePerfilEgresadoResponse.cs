namespace JobList.Entities.Responses
{
    public class UpdatePerfilEgresadoResponse
    {
        public bool successPerfil { get; set; }
        public bool successConocimientos { get; set; }
        public bool successHabilidades { get; set; }
        public bool successExperiencias { get; set; }
        public bool successDeleteHabilidades { get; set; }
        public bool successDeleteConocimientos { get; set; }
        public bool successDeleteExperienciaLaboral { get; set; }

        public string mensaje { get; set; } = default!;

    }
}
