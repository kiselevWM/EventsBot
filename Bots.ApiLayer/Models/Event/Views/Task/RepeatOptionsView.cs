using Bots.ApiLayer.Models.Event.Forms.Task;

namespace Bots.ApiLayer.Models.Event.Views.Task
{
	public class RepeatOptionsView
	{
		public RepeatType type { get; set; }		
		public int Interval{ get; set; }
		public string dateStart { get; set; }
		public string options{ get; set; }
	}
}