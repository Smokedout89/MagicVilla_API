namespace MagicVilla_VillaAPI.Controllers.APIv2
{
    using Models;
    using AutoMapper;
    using Repository.IRepository;
    using Microsoft.AspNetCore.Mvc;

    //[Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IVillaRepository _dbVilla;
        private readonly IVillaNumberRepository _dbVillaNumber;

        public VillaNumberAPIController
            (IVillaNumberRepository dbVillaNumber, IMapper mapper, IVillaRepository dbVilla)
        {
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            _dbVilla = dbVilla;
            _response = new();
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public IEnumerable<string> Get()
        {
            return new List<string> { "Nice", "Try" };
        }
    }
}