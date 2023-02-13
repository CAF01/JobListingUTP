using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Docente
{
    //public class ReadDetallesOfertaHandler : IRequestHandler<ReadDetallesOfertaRequest, ReadDetallesOfertaResponse>
    //{
    //    private readonly ICuentaDocenteService cuentaDocenteService;

    //    public ReadDetallesOfertaHandler(ICuentaDocenteService cuentaDocenteService)
    //    {
    //        this.cuentaDocenteService = cuentaDocenteService;
    //    }

    //    public async Task<ReadDetallesOfertaResponse> Handle(ReadDetallesOfertaRequest request, CancellationToken cancellationToken)
    //    {
    //        ReadDetallesOfertaResponse detallesResponse = await this.cuentaDocenteService.readDetallesOferta(request);
    //        return detallesResponse;
    //    }
    //}
}
