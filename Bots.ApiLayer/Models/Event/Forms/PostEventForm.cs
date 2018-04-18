using Bots.ApiLayer.Models.Event.Forms.Voting;
using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Event.Forms
{
	public class PostEventForm: PostEventBaseForm
	{
		/// <summary>
		/// От чьего имени делать пост? (если вы администратор Бизнес Страницы, то пост можно сделать от её имени)
		/// </summary>
		public PostAuthor? author { get; set; }
		/// <summary>
		/// Надо ли подписаться на событие
		/// </summary>
		public bool subscribe { get; set; }
		/// <summary>
		/// Задача
		/// </summary>
		public PostEventTaskForm task { get; set; }
		/// <summary>
		/// Голосование
		/// </summary>
		public PostEventVotingForm voting { get; set; }
		/// <summary>
		/// Гео-позиция
		/// </summary>
		public PostEventGeoForm geo { get; set; }
		/// <summary>
		/// Настройки направленного события
		/// </summary>
		public DirectedAccessForm directedAccess { get; set; }
		/// <summary>
		/// Пользователь может удалять свои комментарии
		/// </summary>
		public EventAbilityToDeleteDiscussion AbilityToDeleteDiscussion { get; set; }
		/// <summary>
		/// Древовидные комментарии
		/// </summary>
		public EventTreeBranches EventTreeBranches { get; set; }
	}
}