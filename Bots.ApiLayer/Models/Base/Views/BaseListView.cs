using System.Collections.Generic;

namespace Bots.ApiLayer.Models.Base.Views
{
	public class BaseListView<TItem>
	{
		public BaseListView()
		{
			items = new List<TItem>();
		}
		/// <summary>
		/// Общее количество
		/// </summary>
		public int? countAll { get; set; }
		/// <summary>
		/// Список
		/// </summary>
		public IList<TItem> items { get; set; }
	}
}