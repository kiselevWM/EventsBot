namespace Bots.ApiLayer.Models.User.Views
{
	public class UserPublicDataView : UserIconsView
	{
		public string attestat { get; set; }
		public int? bl { get; set; }
		public int tl { get; set; }
		public int? cl { get; set; }
		public UserGenger Gender { get; set; }
		public string lastLoginDate { get; set; }
		public string lastLoginDateUtc { get; set; }
		public string lastOnlineDate { get; set; }
		public string lastOnlineDateUtc { get; set; }
		public UserStatus status { get; set; }
		public bool interactOpportunity { get; set; }
		public UserType userType { get; set; }
	}
}