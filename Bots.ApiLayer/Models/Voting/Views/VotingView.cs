using System;
using System.Collections.Generic;
using Bots.ApiLayer.Models.Base.Views;
using Bots.ApiLayer.Models.User.Views;

namespace Bots.ApiLayer.Models.Voting.Views
{
	public class VotingView
	{
		public int id { get; set; }
	    public string uid => Guid.NewGuid().ToString();
        public UserPublicDataView author { get; set; }
        public string desc { get; set; }
        public string datelastvote { get; set; }
        public string datelastvotestr { get; set; }
        public bool anonymous { get; set; }
        public bool multiple { get; set; }
        public bool revote { get; set; }
		/// <summary>
		/// Возможность добавить новый вариант
		/// </summary>
        public bool free { get; set; }
        public bool closed { get; set; }
        public int votescount { get; set; }
        public IList<VotingOptionView> options { get; set; }
        public VotingParticipantsView participants { get; set; }
        public string deadLineReVote { get; set; }
        public string deadLineReVoteStr { get; set; }
        public VotingRestrictView restrict { get; set; }
	}
}