using System.Net;

namespace Bots.ApiLayer.Models.Errors
{
	public class EventsHttpError
	{
		public string Code { get; set; }
		public string CodeMessage { get; set; }
		public HttpStatusCode HttpCode { get; set; }

		public EventsHttpError SetMessage(string message)
		{
			CodeMessage = message;
			return this;
		}
	}
}