﻿namespace MagicVilla_Web.Services;

using Models;
using IServices;
using System.Text;
using Newtonsoft.Json;
using MagicVilla_Utility;

public class BaseService : IBaseService
{
    public APIResponse responseModel { get; set; }
    public IHttpClientFactory httpClient { get; set; }
    public BaseService(IHttpClientFactory httpClient)
    {
        this.responseModel = new APIResponse();
        this.httpClient = httpClient;
    }
    public async Task<T> SendAsync<T>(APIRequest apiRequest)
    {
        try
        {
            var client = httpClient.CreateClient("MagicAPI");
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);

            if (apiRequest.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                    Encoding.UTF8, "application/json");
            }

            //switch (apiRequest.ApiType)
            //{
            //    case SD.ApiType.POST:
            //        message.Method = HttpMethod.Post;
            //        break;
            //    case SD.ApiType.PUT:
            //        message.Method = HttpMethod.Put;
            //        break;
            //    case SD.ApiType.DELETE:
            //        message.Method = HttpMethod.Delete;
            //        break;
            //    default:
            //        message.Method =HttpMethod.Get;
            //        break;
            //}

            message.Method = apiRequest.ApiType switch
            {
                SD.ApiType.POST => HttpMethod.Post,
                SD.ApiType.PUT => HttpMethod.Put,
                SD.ApiType.DELETE => HttpMethod.Delete,
                _ => HttpMethod.Get
            };

            HttpResponseMessage apiResponse = null;

            apiResponse = await client.SendAsync(message);
            // DEBUG HERE IF THERE IS ERROR WITH THE API
            var apiContent = await apiResponse.Content.ReadAsStringAsync();

            var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
            return APIResponse;
        }
        catch (Exception e)
        {
            var dto = new APIResponse()
            {
                ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                IsSuccess = false
            };

            var res = JsonConvert.SerializeObject(dto);

            var APIResponse = JsonConvert.DeserializeObject<T>(res);
            return APIResponse;
        }
    }
}