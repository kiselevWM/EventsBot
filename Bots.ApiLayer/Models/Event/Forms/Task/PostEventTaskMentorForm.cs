namespace Bots.ApiLayer.Models.Event.Forms.Task
{
	public class PostEventTaskMentorForm
	{
		/// <summary>
		/// Стоимость исполнения задачи
		/// </summary>
		public decimal executerPrice { get; set; }
		/// <summary>
		/// Стоимость контроля задачи (если контролёр - автор задачи, то указывать не надо)
		/// </summary>
		public decimal? controllerPrice { get; set; }
		/// <summary>
		/// Кошелёк автора задачи, с которого будут списаны средства
		/// </summary>
		public string purse { get; set; }
	}
}