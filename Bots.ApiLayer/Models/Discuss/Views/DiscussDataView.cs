namespace Bots.ApiLayer.Models.Discuss.Views
{
	public class DiscussDataView: DiscussBaseView
	{
		 /// <summary>
        /// Уровень вложенности. Если 0, то это корневой комментарий.
        /// </summary>
        public int depth { get; set; }
	}
}