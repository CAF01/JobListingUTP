namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;

    public class ReadTiposUsuarioHandler : IRequestHandler<ReadTiposUsuarioRequest, List<ReadTiposUsuarioResponse>>
    {
        private readonly ITiposUsuarioService tiposUsuarioService;

        public ReadTiposUsuarioHandler(ITiposUsuarioService tiposUsuarioService)
        {
            this.tiposUsuarioService = tiposUsuarioService;
        }

        public async Task<List<ReadTiposUsuarioResponse>> Handle(ReadTiposUsuarioRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadTiposUsuarioResponse> listTipoUsuario = await this.tiposUsuarioService.readTiposUsuario();
            return listTipoUsuario.ToList();
        }
    }
}
