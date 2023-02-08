namespace MagicVilla_Web.Controllers
{
    using Models;
    using AutoMapper;
    using Models.DTO;
    using Newtonsoft.Json;
    using Services.IServices;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class VillaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVillaService _villaService;

        public VillaController(IMapper mapper, IVillaService villaService)
        {
            _mapper = mapper;
            _villaService = villaService;
        }

        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new();

            var response = await _villaService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CreateVilla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO modelDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(modelDto);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }

            return View(modelDto);
        }
    }
}
