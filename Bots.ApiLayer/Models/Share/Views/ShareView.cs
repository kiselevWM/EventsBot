using System.Collections.Generic;
using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Share.Views
{
	public class ShareView
	{
		public string url { get; set; }
		public string title { get; set; }
		public string desc { get; set; }
		public ShareUrlMediaType type { get; set; }
		public string mediaId { get; set; }
		public Dictionary<string, string> versions { get; set; }
		public int id { get; set; }
	}
}