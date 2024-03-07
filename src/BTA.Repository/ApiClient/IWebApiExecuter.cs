using BTA.Core.Models;

namespace BTA.Repository.ApiClient;

public interface IWebApiExecuter
{
    Task<T> InvokeGet<T>(string uri);
    Task<T> InvokePost<T>(string uri, T value);
    Task InvokePut<T>(string uri, T value);
    Task InvokeDelete(string uri);
}