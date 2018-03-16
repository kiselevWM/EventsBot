using System.Collections.Generic;

namespace Bots.ApiLayer.Models.Event.Forms.Voting
{
	public class PostEventVotingForm
	{
		/// <summary>
		/// Тема голосования
		/// </summary>
		public string desc { get; set; }
		/// <summary>
		/// Варианты ответа
		/// </summary>
		public List<string> options { get; set; }
		/// <summary>
		/// Анонимное голосование
		/// </summary>
		public bool anonymous { get; set; }
		/// <summary>
		/// Позволить голосовать за несколько вариантов
		/// </summary>
		public bool multipleChoice { get; set; }
		/// <summary>
		/// Разрешить переголосовывать
		/// </summary>
		public bool canRevote { get; set; }
		/// <summary>
		/// Позволить всем добавлять варианты ответов
		/// </summary>
		public bool freeVotes { get; set; }
	}
}