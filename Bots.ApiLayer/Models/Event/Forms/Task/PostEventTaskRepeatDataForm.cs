using System;

namespace Bots.ApiLayer.Models.Event.Forms.Task
{
	public class PostEventTaskRepeatDataForm
	{
		public RepeatType type { get; set; }
		public int? interval { get; set; }
		public DateTime dateStart { get; set; }
		public string weeklyMask { get; set; }
	}
}