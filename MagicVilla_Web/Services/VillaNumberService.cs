﻿namespace MagicVilla_Web.Services;

using Models;
using IServices;
using Models.DTO;
using MagicVilla_Utility;

public class VillaNumberService : BaseService, IVillaNumberService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly string villaUrl;

    public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) 
        : base(clientFactory)
    {
        _clientFactory = clientFactory;
        villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
    }

    public Task<T> GetAllAsync<T>()
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = villaUrl + "/api/VillaNumberAPI"
        });
    }

    public Task<T> GetAsync<T>(int id)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = villaUrl + "/api/VillaNumberAPI/" + id
        });
    }

    public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = dto,
            Url = villaUrl + "/api/VillaNumberAPI"
        });
    }

    public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data = dto,
            Url = villaUrl + "/api/VillaNumberAPI/" + dto.VillaNo
        });
    }

    public Task<T> DeleteAsync<T>(int id)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = villaUrl + "/api/VillaNumberAPI/" + id
        });
    }
}