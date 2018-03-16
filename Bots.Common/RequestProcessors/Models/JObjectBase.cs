using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bots.Common.RequestProcessors.Models
{
	public class JObjectBase
	{
		public JToken Obj { get; set; }

		protected TObject Parse<TObject>(JsonSerializer serializer) where TObject : class, new()
		{
			return Obj?.ToObject<TObject>(serializer);
		}

		public List<string> GetSignatureMembers()
		{
			return new List<string> { Obj.ToString() };
		}
	}
}