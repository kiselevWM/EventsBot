using System;

namespace Bots.ApiLayer.Models.Errors
{
	public class EventsHttpException: Exception
	{
		public EventsHttpException(EventsHttpError error)
			:base(error.CodeMessage)
		{
			Error = error;
		}
		public EventsHttpError Error { get; }
	}
}