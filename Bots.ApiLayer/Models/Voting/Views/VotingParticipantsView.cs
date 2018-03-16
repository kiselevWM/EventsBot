using Bots.ApiLayer.Models.Base.Views;
using Bots.ApiLayer.Models.User.Views;

namespace Bots.ApiLayer.Models.Voting.Views
{
	public class VotingParticipantsView
	{
		public BaseListView<UserPublicDataView> lastWhoWereActive { get; set; }
        public BaseListView<UserPublicDataView> lastWhoWereActiveOther { get; set; }
	}
}