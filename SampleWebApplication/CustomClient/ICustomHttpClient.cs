namespace SampleWebApplication.CustomClient
{
    public interface ICustomHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostJsonAsync<T>(string url, T requestBody);

        Task<HttpResponseMessage> PutAsync<T>(string url, T requestBody);
       
    }
}