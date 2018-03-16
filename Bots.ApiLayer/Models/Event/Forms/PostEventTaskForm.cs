using System;
using System.Collections.Generic;
using Bots.ApiLayer.Models.Event.Forms.Task;

namespace Bots.ApiLayer.Models.Event.Forms
{
	public class PostEventTaskForm
	{
		/// <summary>
		/// WMID'ы исполнителей
		/// </summary>
		public List<string> executers { get; set; }
		/// <summary>
		/// WMID'ы контролёров
		/// </summary>
		public List<string> controllers { get; set; }
		/// <summary>
		/// Важность задачи
		/// </summary>
		public TaskImportance importance { get; set; }
		/// <summary>
		/// Дата завершения задачи (обязательно для платной задачи)
		/// </summary>
		public DateTime? dateEnd { get; set; }
		/// <summary>
		/// Данные для платной задачи
		/// </summary>
		public PostEventTaskMentorForm payment { get; set; }
		/// <summary>
		/// Данные для повторяемости задачи
		/// </summary>
		public PostEventTaskRepeatDataForm repeat { get; set; }
	}
}