using System;

namespace Bots.ApiLayer.Api.Base
{
	public abstract class BaseApi
	{
		protected virtual TResult Execute<TResult>(Func<TResult> apiFunc)
		{
			//for processing exception etc.
			return apiFunc();
		}
	}
}