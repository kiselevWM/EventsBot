namespace Bots.Common.Models.Events
{
	public enum BotEvent
	{
		/// <summary>
		/// создание комментария к событию с задачей
		/// </summary>
		PostedGroupTaskComment = 1,
		/// <summary>
		/// создание комментария в группе
		/// </summary>
		PostedGroupComment=2,
		/// <summary>
		/// редактирование комментария группе
		/// </summary>
		UpdatedGroupComment=3,
		/// <summary>
		/// редактирование комментария к событию с задачей
		/// </summary>
		UpdatedGroupTaskComment=4,
		/// <summary>
		/// создание события в группе
		/// </summary>
		PostedGroupEvent=5,
		/// <summary>
		/// создание события с задачей
		/// </summary>
		PostedGroupTaskEvent=6,
		/// <summary>
		/// редактирование события в группе
		/// </summary>
		UpdatedGroupEvent=7,
		/// <summary>
		/// редактирование события с задачей
		/// </summary>
		UpdatedGroupTaskEvent=8,
		/// <summary>
		/// Личное сообщение
		/// </summary>
		Message=9
	}
}