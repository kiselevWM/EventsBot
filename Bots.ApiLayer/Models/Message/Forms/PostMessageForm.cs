using System.Collections.Generic;
using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Message.Forms
{
	public class PostMessageForm : BasePostForm
	{
		/// <summary>
		/// Wmid Адресата
		/// </summary>
		public List<string> corsWmid { get; set; }
	}
}