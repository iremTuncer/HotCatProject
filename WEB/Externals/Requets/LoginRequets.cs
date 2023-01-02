using BLL.Service;
using RestSharp;
using Method = RestSharp.Method;

namespace WEB.Externals.Requets;

public static class LoginRequets
{
 
    public static string IsLogin(string name, string password)
    {
        string url = $"https://localhost:44313/api/Employees/LoginValid?userName={name}&password={password}";
        var client = new RestClient(url);
        var request = new RestRequest("", Method.Post);
        var response = client.Execute(request);

        return response.Content;
    }

  
}