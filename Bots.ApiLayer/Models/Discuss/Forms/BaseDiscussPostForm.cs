namespace Bots.ApiLayer.Models.Discuss.Forms
{
	public class BaseDiscussPostForm : BaseShortDiscussBotForm
	{
		/// <summary>
		/// надо ли подписаться на событие
		/// </summary>
		public bool subscribe { get; set; }
	}
}