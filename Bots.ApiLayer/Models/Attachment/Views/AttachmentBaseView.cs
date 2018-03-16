using System.Collections.Generic;

namespace Bots.ApiLayer.Models.Attachment.Views
{
	public class AttachmentBaseView
	{
		public string id { get; set; }
		public string name { get; set; }
		public string sha1 { get; set; }
		public int size { get; set; }        
		public string contentType { get; set; }
		// original есть всегда, а если картинка, то для превьюшки брать small 
		public Dictionary<string, string> versions { get; set; }
	}
}