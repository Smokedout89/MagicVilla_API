﻿namespace MagicVilla_Web.Models;

using static MagicVilla_Utility.SD;

public class APIRequest
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string Url { get; set; }
    public object Data { get; set; }
}