﻿namespace MagicVilla_Web.Controllers
{
    using Models;
    using Models.VM;
    using AutoMapper;
    using Models.DTO;
    using Newtonsoft.Json;
    using Services.IServices;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class VillaNumberController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVillaService _villaService;
        private readonly IVillaNumberService _villaNumberService;

        public VillaNumberController
            (IVillaNumberService villaNumberService, IVillaService villaService , IMapper mapper)
        {
            _mapper = mapper;
            _villaService = villaService;
            _villaNumberService = villaNumberService;
        }

        public async Task<IActionResult> IndexVillaNumber()
        {
            List<VillaNumberDTO> list = new();

            var response = await _villaNumberService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberVM = new();

            var response = await _villaService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                villaNumberVM.VillaList = 
                    JsonConvert.DeserializeObject<List<VillaDTO>>
                            (Convert.ToString(response.Result))
                        .Select(i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        });
            }

            return View(villaNumberVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM modelDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(modelDto.VillaNumber);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError
                            ("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _villaService.GetAllAsync<APIResponse>();

            if (resp != null && resp.IsSuccess)
            {
                modelDto.VillaList =
                    JsonConvert.DeserializeObject<List<VillaDTO>>
                            (Convert.ToString(resp.Result))
                        .Select(i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        });
            }

            return View(modelDto);
        }

        public async Task<IActionResult> UpdateVillaNumber(int villaNo)
        {
            VillaNumberUpdateVM villaNumberVM = new();

            var response = await _villaNumberService.GetAsync<APIResponse>(villaNo);

            if (response != null && response.IsSuccess)
            {
                VillaNumberDTO dto = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                villaNumberVM.VillaNumber = _mapper.Map<VillaNumberUpdateDTO>(dto);
            }

            response = await _villaService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                villaNumberVM.VillaList =
                    JsonConvert.DeserializeObject<List<VillaDTO>>
                            (Convert.ToString(response.Result))
                        .Select(i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        });

                return View(villaNumberVM);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateVM updateDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.UpdateAsync<APIResponse>(updateDto.VillaNumber);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError
                            ("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _villaService.GetAllAsync<APIResponse>();

            if (resp != null && resp.IsSuccess)
            {
                updateDto.VillaList =
                    JsonConvert.DeserializeObject<List<VillaDTO>>
                            (Convert.ToString(resp.Result))
                        .Select(i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        });
            }

            return View(updateDto);
        }

        public async Task<IActionResult> DeleteVillaNumber(int villaNo)
        {
            VillaNumberDeleteVM villaNumberVM = new();

            var response = await _villaNumberService.GetAsync<APIResponse>(villaNo);

            if (response != null && response.IsSuccess)
            {
                VillaNumberDTO dto = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                villaNumberVM.VillaNumber = dto;
            }

            response = await _villaService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                villaNumberVM.VillaList =
                    JsonConvert.DeserializeObject<List<VillaDTO>>
                            (Convert.ToString(response.Result))
                        .Select(i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        });

                return View(villaNumberVM);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteVM deleteDto)
        {
            var response = await _villaNumberService.DeleteAsync<APIResponse>(deleteDto.VillaNumber.VillaNo);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexVillaNumber));
            }

            return View(deleteDto);
        }
    }
}
