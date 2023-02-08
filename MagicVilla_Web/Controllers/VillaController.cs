﻿namespace MagicVilla_Web.Controllers
{
    using Models;
    using AutoMapper;
    using Models.DTO;
    using Newtonsoft.Json;
    using Services.IServices;
    using Microsoft.AspNetCore.Mvc;

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
    }
}
