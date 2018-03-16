using Bots.ApiLayer.Models.Base.Views;
using Bots.ApiLayer.Models.User.Views;

namespace Bots.ApiLayer.Models.Voting.Views
{
	public class VotingOptionView
	{
		public int id { get; set; }
        public string desc { get; set; }
        public int votescount { get; set; }
        public UserPublicDataView author { get; set; }
        public BaseListView<UserPublicDataView> votes { get; set; }
        public bool voted { get; set; }
	}
}