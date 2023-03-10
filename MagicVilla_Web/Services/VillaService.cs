namespace MagicVilla_Web.Services;

using Models;
using IServices;
using Models.DTO;
using MagicVilla_Utility;

public class VillaService : BaseService,  IVillaService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly string villaUrl;

    public VillaService(IHttpClientFactory clientFactory, IConfiguration configuration) 
        : base(clientFactory)
    {
        _clientFactory = clientFactory;
        villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
    }

    public Task<T> GetAllAsync<T>(string token)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = villaUrl + "/api/v1/VillaAPI",
            Token = token
        });
    }

    public Task<T> GetAsync<T>(int id, string token)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = villaUrl + "/api/v1/VillaAPI/" + id,
            Token = token
        });
    }

    public Task<T> CreateAsync<T>(VillaCreateDTO dto, string token)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = dto,
            Url = villaUrl + "/api/v1/VillaAPI",
            Token = token
        });
    }

    public Task<T> UpdateAsync<T>(VillaUpdateDTO dto, string token)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data = dto,
            Url = villaUrl + "/api/v1/VillaAPI/" + dto.Id,
            Token = token
        });
    }

    public Task<T> DeleteAsync<T>(int id, string token)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = villaUrl + "/api/v1/VillaAPI/" + id,
            Token = token
        });
    }
}