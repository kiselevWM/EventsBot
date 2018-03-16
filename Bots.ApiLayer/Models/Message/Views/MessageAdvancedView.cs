using Bots.ApiLayer.Models.User.Views;

namespace Bots.ApiLayer.Models.Message.Views
{
	public class MessageAdvancedView: MessageBaseView
	{
		public UserPublicDataView author { get; set; }
		public UserPublicDataView correspondent { get; set; }
	}
}