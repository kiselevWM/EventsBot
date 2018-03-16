using Bots.ApiLayer.Models.Icon.Views;

namespace Bots.ApiLayer.Models.User.Views
{
	/// <summary>
	/// Пользователь
	/// </summary>
	public class UserIconsView: UserNameView
	{
		/// <summary>
		/// Аватарка пользователя
		/// </summary>
		public IconView icon { get; set; }
	}
}