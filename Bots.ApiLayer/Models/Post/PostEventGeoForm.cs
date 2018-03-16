namespace Bots.ApiLayer.Models.Post
{
	public class PostEventGeoForm
	{
		/// <summary>
		/// Широта.
		/// </summary>
		public decimal lat { get; set; }
		/// <summary>
		/// Долгота.
		/// </summary>
		public decimal lon { get; set; }
		/// <summary>
		/// Точность.
		/// </summary>
		public decimal acc { get; set; }
	}
}