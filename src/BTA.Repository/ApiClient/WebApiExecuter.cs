using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BTA.Repository.ApiClient;

public class WebApiExecuter : IWebApiExecuter
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public WebApiExecuter(string baseUrl, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;

        _httpClient.DefaultRequestHeaders.Accept.Clear(); 
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
    }

    public async Task<T> InvokeGet<T>(string uri)
    {
        HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/{uri}");

        var response = await _httpClient.SendAsync(msg);
        Console.WriteLine(response);
        await CheckSuccess(response);
        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine(json);
        return await _httpClient.GetFromJsonAsync<T>($"{_baseUrl}/{uri}");
        // response.EnsureSuccessStatusCode();
    }

    public async Task<T> InvokePost<T>(string uri, T obj)
    { 
        var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/{uri}", obj);

        await CheckSuccess(response);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task InvokePut<T>(string uri, T obj)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{uri}", obj);

        await CheckSuccess(response);
        
        response.EnsureSuccessStatusCode();
    }

    public async Task InvokeDelete(string uri)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{uri}");
        
        await CheckSuccess(response);
        
        response.EnsureSuccessStatusCode();
    }

    private async Task CheckSuccess(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode) 
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException(content);
        }
    }
}

// _httpClient.DefaultRequestHeaders.Accept.Clear(); is to initialize the httpclient by first clearing accept header
// InvokePut<T> has a T because method 'body' does, if you include parameters as body
// GetFromJsonAsync<T> is a deserialization into type T
// Which is why we require a Task<T> on return for Get and Post i.e. we are returning a deserialized object of T type
// Why InvokeGet<T>? How will body (return value) know what T is to deserialize to?