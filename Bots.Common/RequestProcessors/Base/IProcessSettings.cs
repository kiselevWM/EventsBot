using System;

namespace Bots.Common.RequestProcessors.Base
{
	public interface IProcessSettings
	{
		/// <summary>
		/// If an income request executes more than this time, processor will return empty results
		/// and when processing is finished we'll send request to Events api
		/// </summary>
		TimeSpan ExecTimeout { get; }
		/// <summary>
		/// If an income request executes more than ExecTimeout, processor will return empty result 
		/// and when processing is finished we'll send request to Events api with this timeout.
		/// </summary>
		TimeSpan DelayedRequestTimeout { get; }
	}
}