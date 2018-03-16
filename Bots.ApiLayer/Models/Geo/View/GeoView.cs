namespace Bots.ApiLayer.Models.Geo.View
{
	public class GeoView
	{
		public decimal lat { get; set; }
		public decimal lon { get; set; }
		public int acc { get; set; }
		public bool pub { get; set; }
	}
}