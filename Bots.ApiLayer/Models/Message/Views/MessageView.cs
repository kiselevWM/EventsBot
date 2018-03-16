using Bots.ApiLayer.Models.User.Views;

namespace Bots.ApiLayer.Models.Message.Views
{
	public class MessageView: MessageBaseView
	{
        public UserPublicDataView author { get; set; }
	}
}