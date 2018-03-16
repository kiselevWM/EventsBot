using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests;
using Bots.Common.ExternelModels.Requests.BotUrlValidation;
using Bots.Common.ExternelModels.Responses;
using Bots.Common.ExternelModels.Responses.BotUrlValidation;
using Bots.Common.RequestProcessors.Base.Localization;
using Bots.Common.RequestProcessors.Validation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bots.Common.RequestProcessors.Base
{
	public abstract class BaseRequestProcessor
	{
		private readonly ILocalizationService _localizationService;
		private readonly IBotAuthService _authService;
		private readonly ConcurrentDictionary<BotRequestType, Func<string, Task<object>>> _requestProcessors;

		private static async Task<object> ProcessFunc<TBaseRequest, TBaseResponse, TResponse>(string str, 
			ICustomRequestProcessor<TBaseRequest, TBaseResponse, TResponse> processor)
			where TBaseRequest : BaseBotRequest<JToken>
			where TBaseResponse : BaseBotResponse<TResponse>
		{
			return await processor.ProcessAsync(JsonConvert.DeserializeObject<TBaseRequest>(str)).ConfigureAwait(false);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="authService">Provide events requests auth</param>
		/// <param name="validationRequestProcessor">For events validation request (events, commands, actions)</param>
		/// <param name="localizationService">Service for setting locale app</param>
		protected BaseRequestProcessor(IBotAuthService authService, ICustomRequestProcessor<BaseUrlValidationBotRequest<JToken>,
				BaseUrlValidationBotResponse<UrlValidationBotResponse>, UrlValidationBotResponse> validationRequestProcessor,
			ILocalizationService localizationService)
		{
			_authService = authService;
			_localizationService = localizationService;
			_requestProcessors = new ConcurrentDictionary<BotRequestType, Func<string, Task<object>>>(
				new List<KeyValuePair<BotRequestType, Func<string, Task<object>>>>
				{
					new KeyValuePair<BotRequestType, Func<string, Task<object>>>(validationRequestProcessor.RequestType,
						str => ProcessFunc(str, validationRequestProcessor))
				});
		}

		protected BaseRequestProcessor(IBotAuthService authService, ILocalizationService localizationService)
			:this(authService, new ValidationRequestProcessor(), localizationService){}

		protected BaseRequestProcessor(IBotAuthService authService)
			:this(authService, new ValidationRequestProcessor(), new LocalizationService()){}

		public BaseRequestProcessor SetRequestProcessor<TBaseRequest, TBaseResponse, TResponse>(
				ICustomRequestProcessor<TBaseRequest, TBaseResponse, TResponse> processor)
			where TBaseRequest : BaseBotRequest<JToken>
			where TBaseResponse : BaseBotResponse<TResponse>
		{
			if (processor == null) return this;
			_requestProcessors.AddOrUpdate(processor.RequestType, str => ProcessFunc(str, processor), (type, func) => (str => ProcessFunc(str, processor)));
			return this;
		}

		public virtual async Task<string> ProcessAsync(string botRequestBody)
		{
			try
			{
				BaseBotRequest<JToken> baseRequest;
				try
				{
					baseRequest  = JsonConvert.DeserializeObject<BaseBotRequest<JToken>>(botRequestBody);
					if (baseRequest?.request == null)
					{
						throw new ArgumentException($"Bad request body.", nameof(botRequestBody));
					}
				}
				catch (Exception e)
				{
					throw new ArgumentException($"Bad request body.", e);
				}

				if (_authService != null && !_authService.IsAuthBotRequest(baseRequest.token))
				{
					throw new ArgumentException($"request is not authorized.");
				}

				_localizationService?.SetLocale(baseRequest.lng);
				if (!_requestProcessors.TryGetValue(baseRequest.requestType, out var requestProcFunc))
				{
					throw new NotSupportedException($"Request type ({baseRequest.requestType}) is not supported");
				}

			
				var responseObj = await requestProcFunc(botRequestBody);
				return responseObj == null ? null : JsonConvert.SerializeObject(responseObj);
			}
			catch (Exception ex)
			{
				ex.Data.Add("RequestBody", botRequestBody);
				throw;
			}
		}
	}
}