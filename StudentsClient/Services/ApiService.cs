using StudentAPI.Models;

namespace StudentsClient.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Student>>("https://studentapi-app-20250118105237.orangedesert-fea0bf8d.northeurope.azurecontainerapps.io/students");
        }
    }
}
