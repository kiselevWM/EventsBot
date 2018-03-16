using System.Collections.Generic;

namespace Bots.ApiLayer.Models.Discuss.Views
{
	public class DiscussView : DiscussBaseView
	{
		public IList<DiscussView> childs { get; set; }
	}
}