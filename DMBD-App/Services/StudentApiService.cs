using DMBD.Kernel.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DMBD_App.Services
{
	public class StudentApiService
	{
		
			private readonly HttpClient _httpClient;

			public StudentApiService(HttpClient httpClient)
			{
				_httpClient = httpClient;
			}

			public async Task<StudentDto> GetByIdAsync(int id)
			{

				var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<StudentDto>>($"products/{id}");
				return response.Data;


			}

			public async Task<StudentDto> SaveAsync(StudentDto newStudent)
			{
				var response = await _httpClient.PostAsJsonAsync("products", newStudent);

				if (!response.IsSuccessStatusCode) return null;

				var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<StudentDto>>();

				return responseBody.Data;

			}
			public async Task<bool> UpdateAsync(StudentDto newStudent)
			{
				var response = await _httpClient.PutAsJsonAsync("products", newStudent);

				return response.IsSuccessStatusCode;
			}
			public async Task<bool> RemoveAsync(int id)
			{
				var response = await _httpClient.DeleteAsync($"products/{id}");

				return response.IsSuccessStatusCode;
			}

	}
}
