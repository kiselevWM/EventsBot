using System.Collections.Generic;

namespace Bots.ApiLayer.Models.Post
{
	public class BasePostForm
	{
		/// <summary>
		/// текст события
		/// </summary>
		public string postText { get; set; }
		/// <summary>
		/// Идентификаторы файлов, которые надо прикрепить
		/// </summary>
		public virtual List<string> files { get; set; }
	}
}