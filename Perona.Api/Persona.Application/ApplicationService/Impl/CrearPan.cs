using Persona.Application.Dto;
using Persona.Domain;
using Persona.Domain.InfrastructureService;
using Persona.Domain.Repositories;

namespace Persona.Application.ApplicationService.Impl
{
    public class CrearPan: CrudService<PanRoscon,string>, ICrearPan
    {
        private readonly IRepository<PanRoscon, string> _panRepository;
        private readonly IMapService _mapService;

        public CrearPan(IRepository<PanRoscon, string> repository, IMapService mapService) : base(repository)
        {
            this._panRepository = repository;
            this._mapService = mapService;
        }

        public CreatePanDto CrarPan(CreatePanDto crearPanDto)
        {
            var pan = PanRoscon.Crear(crearPanDto.Id, crearPanDto.Name, crearPanDto.Description, crearPanDto.Precio);
            var entity = _panRepository.Insert(pan);
            return _mapService.Map<PanRoscon, CreatePanDto>(entity);
        }
    }
}
