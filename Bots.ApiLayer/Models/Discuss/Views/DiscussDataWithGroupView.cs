using Bots.ApiLayer.Models.Group;

namespace Bots.ApiLayer.Models.Discuss.Views
{
	public class DiscussDataWithGroupView: DiscussDataView
	{
		public GroupView group { get; set; }
        public string cleanMessage { get; set; }
	}
}