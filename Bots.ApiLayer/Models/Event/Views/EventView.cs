using System.Collections.Generic;
using Bots.ApiLayer.Models.Attachment.Views;
using Bots.ApiLayer.Models.AttachmentEntity.Views;
using Bots.ApiLayer.Models.Event.Views.Task;
using Bots.ApiLayer.Models.EventGenerator.Views;
using Bots.ApiLayer.Models.Geo.View;
using Bots.ApiLayer.Models.Group;
using Bots.ApiLayer.Models.Icon.Views;
using Bots.ApiLayer.Models.Post;
using Bots.ApiLayer.Models.Share.Views;
using Bots.ApiLayer.Models.User.Views;
using Bots.ApiLayer.Models.Voting.Views;

namespace Bots.ApiLayer.Models.Event.Views
{
	public class EventView
	{
		/// <summary>
        /// Идентификатор события
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// Текст события
        /// </summary>
        public string message{get; set; }
        
        /// <summary>
        /// Дополнительное описание, если применимо
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// Внешняя ссылка
        /// </summary>
        public string link { get; set; }
        /// <summary>
        /// Описание сервиса, из которого данное событие было создано
        /// </summary>
        public EventGeneratorView generator { get; set; }
        /// <summary>
        /// Дата создания события
        /// </summary>
        public string datecreated { get; set; }
        /// <summary>
        /// Дата создания события
        /// </summary>
        public string datecreatedstr { get; set; }
        /// <summary>
        /// Дата последней активности внутри события
        /// </summary>
        public long datelastupdatedticks { get; set; }
        /// <summary>
        /// Событие было отредактировано
        /// </summary>
        public bool edited { get; set; }
        /// <summary>
        /// Событие в группе закреплено
        /// </summary>
        public bool pinned { get; set; }
        /// <summary>
        /// Дискуссия в рамках события закрыта
        /// </summary>
        public bool discussionclosed { get; set; }
        /// <summary>
        /// Автор события
        /// </summary>
        public UserFriendPublicDataView author { get; set; }
        /// <summary>
        /// Описание группы, в которой это событие было создано
        /// </summary>
        public GroupView group { get; set; }
        /// <summary>
        /// Прикреплённая задача
        /// </summary>
        public TaskView task { get; set; }
        /// <summary>
        /// Прикреплённое голосование
        /// </summary>
        public VotingView voting { get; set; }
        /// <summary>
        /// Перечень вложений (файлы, картинки)
        /// </summary>
        public IList<AttachmentView> attachments { get; set; }
        /// <summary>
        /// Прикреплённое описание внешней ссылки (заголовок, описание, картинка или видео)
        /// </summary>
        public ShareView share { get; set; }
        /// <summary>
        /// Перечень действий, которые можно осуществить с событием
        /// </summary>
        public IList<string> actions { get; set; }
        /// <summary>
        /// Перечень действий, которые можно осуществить с событием
        /// </summary>
        public IList<EventAction> actionsVal { get; set; }
        /// <summary>
        /// Прикреплённая геопозиция
        /// </summary>
        public GeoView geo { get; set; }
        /// <summary>
        /// Перечень аватарок
        /// </summary>
        public IList<IconView> icons { get; set; }
        public EventGeneratorEventDetailsView settings { get; set; }
        /// <summary>
        /// От чьего имени было создано событие
        /// </summary>
        public PostAuthor behalf { get; set; }
        /// <summary>
        /// Возможность древовидных комментариев
        /// </summary>
        public EventTreeBranches treeBranches { get; set; }
        /// <summary>
        /// Перечень действий с их описанием
        /// </summary>
        public List<AttachmentEntityView> attachedActions { get; set; }
        /// <summary>
        /// Если событие направленное, то указывается кому оно направлено
        /// </summary>
        public List<UserPublicDataView> directedAccess { get; set; }
	}
}