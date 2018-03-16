using System.Collections.Generic;
using Bots.ApiLayer.Models.Event.Forms.Task;
using Bots.ApiLayer.Models.Group;
using Bots.ApiLayer.Models.User.Views;
using Bots.ApiLayer.Models.Group.Views;

namespace Bots.ApiLayer.Models.Event.Views.Task
{
	public class TaskView
	{
		public RepeatOptionsView repeatOptions { get; set; }
		/// <summary>
		/// Описание группы
		/// </summary>
		public GroupView group { get; set; }
		/// <summary>
		/// Автор задачи
		/// </summary>
        public UserPublicDataView author { get; set; }
		/// <summary>
		/// Дата создания задачи
		/// </summary>
        public string datecreated { get; set; }
        //public string datebegin { get; set; }
        public string dateend { get; set; }
        public string dateendutc { get; set; }
        public string datefinish { get; set; }
        public IList<TaskParticipantView> executers { get; set; }
        public IList<TaskParticipantView> controllers { get; set; }
        public TaskStatusView status { get; set; }
		/// <summary>
		/// Тип задачи
		/// </summary>
        public TaskType type { get; set; }		
		/// <summary>
		/// Важность задачи
		/// </summary>
        public TaskImportance importance { get; set; }
		/// <summary>
		/// Описание важности задачи
		/// </summary>
        public TaskStatusAdditionallyView statusadditionally { get; set; }
        public List<TaskActionView> actions { get; set; }
		/// <summary>
		/// Роли в задачи
		/// </summary>
        public List<TaskRoleDescView> roles { get; set; }
		/// <summary>
		/// Вознаграждение исполнителя
		/// </summary>
        public decimal? executerprice { get; set; }
		/// <summary>
		/// Вознаграждение контролера
		/// </summary>
		public decimal? controllerprice { get; set; }
		/// <summary>
		/// Тип кошелька
		/// </summary>
        public PurseType? purseType { get; set; }

        public TaskMessageView taskMessage { get; set; }
	}
}