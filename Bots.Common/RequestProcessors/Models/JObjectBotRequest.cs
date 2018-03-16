using Newtonsoft.Json;

namespace Bots.Common.RequestProcessors.Models
{
	public class JObjectBotRequest : JObjectBase
	{
		public TRequest Parse<TRequest>(JsonSerializer serializer)
			where TRequest : class, new()
		{
			return base.Parse<TRequest>(serializer);
		}
	}
}