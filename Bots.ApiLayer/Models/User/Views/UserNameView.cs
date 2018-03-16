namespace Bots.ApiLayer.Models.User.Views
{
	/// <summary>
	/// Пользователь
	/// </summary>
	public class UserNameView : UserIdentsView
	{
		/// <summary>
		/// Никнейм
		/// </summary>
		public string nickname{get; set; }
	}
}