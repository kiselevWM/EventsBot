using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Bots.ApiLayer.Models.Errors;
using Newtonsoft.Json;

namespace Bots.ApiLayer.Api.Base
{
	public abstract class BaseWebApi : BaseApi
	{
		private readonly string _apiUrl;
		private readonly string _token;
		private const string DefaultApiUrl = "https://events-api.webmoney.ru";
		protected BaseWebApi(string token, string apiUrl = null)
		{
			_apiUrl = apiUrl ?? DefaultApiUrl;
			_token = token;
		}
		protected abstract string Controller { get; }
		protected async Task<TResponse> SendPostRequest<TParam, TResponse>(string action, TParam param, TimeSpan? timeout = null)
			where TResponse: class
		{
			using (var httpClient = new HttpClient())
			{
				if (timeout.HasValue) httpClient.Timeout = timeout.Value;
				var httpRequestMessage = new HttpRequestMessage
				{
					Method = HttpMethod.Post,
					RequestUri = new Uri($"{_apiUrl}/{Controller}/{action}")
				};
				httpRequestMessage.Headers.Add("accessToken", _token);
				httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var jsonData = JsonConvert.SerializeObject(param);
				HttpContent httpContent = new  StringContent(jsonData, Encoding.UTF8, "application/json");
				httpRequestMessage.Content = httpContent;
				using (var httpResponse = await httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false))
				{
					using (var content = httpResponse.Content)
					{
						var jsonResponse = await content.ReadAsStringAsync().ConfigureAwait(false);
						if (httpResponse.StatusCode == HttpStatusCode.OK)
							return JsonConvert.DeserializeObject<TResponse>(jsonResponse);

						var httpError = JsonConvert.DeserializeObject<EventsHttpError>(jsonResponse);

						throw new EventsHttpException(httpError.SetMessage($"{httpError.CodeMessage}; url: {httpRequestMessage.RequestUri}; data: {jsonData}"));
					} 
				}
			}
		}
	}
}