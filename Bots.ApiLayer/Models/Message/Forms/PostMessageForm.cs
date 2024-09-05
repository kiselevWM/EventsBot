﻿using System.Collections.Generic;
using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Message.Forms
{
	public class PostMessageForm : PostMessageBaseForm
	{
		/// <summary>
		/// Wmid Адресата
		/// </summary>
		public List<string> corsWmid { get; set; }
        public string chatUid { get; set; }
    }
}