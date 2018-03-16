namespace Bots.ApiLayer.Models.Icon.Views
{
	public class IconView
	{
		/// <summary>
		/// Идентификатор аватарки
		/// </summary>
		public string id { get; set; }
		/// <summary>
		/// Является ли аватарка активной
		/// </summary>
		public bool isactive { get; set; }
		/// <summary>
		/// Является ли аватарка дефолтной
		/// </summary>
		public bool isDefault { get; set; }
		/// <summary>
		/// 20x20
		/// </summary>
		public string smallest { get; set; }
		/// <summary>
		/// 26x26
		/// </summary>
		public string tiny { get; set; }
		/// <summary>
		/// 36x36
		/// </summary>
		public string mini { get; set; }
		/// <summary>
		/// 50x50
		/// </summary>
		public string small { get; set; }
		/// <summary>
		/// 96x96
		/// </summary>
		public string normal { get; set; }
		/// <summary>
		/// 240x240
		/// </summary>
		public string large { get; set; }
		/// <summary>
		/// 670x670
		/// </summary>
		public string big { get; set; }
		/// <summary>
		/// Оригинал
		/// </summary>
		public string original { get; set; }
	}
}