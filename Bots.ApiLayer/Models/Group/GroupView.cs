using System.Collections.Generic;
using Bots.ApiLayer.Models.Group.Views;
using Bots.ApiLayer.Models.Icon.Views;

namespace Bots.ApiLayer.Models.Group
{
	public class GroupView: GroupVisNameView
	{
        public string synonym { get; set; }
        public string descfull { get; set; }
        public string descshort{ get; set; }
        public string createdate { get; set; }
        public string createdatestr { get; set; }
        public string datelastactivity { get; set; }
        public string datelastactivitystr { get; set; }
        public string cover { get; set; }
        public IList<IconView> icons { get; set; }
        public string outsideurl { get; set; }
        public GroupType groupType { get; set; }
        public string groupTypeStr => groupType.ToString();
        public GroupRestrictionView restriction { get; set; }
        public GroupCategoryView category { get; set; }
        public bool enabled { get; set; }
        public GroupState state {get; set; }
    }
}