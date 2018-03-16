using System.Collections.Generic;
using Bots.ApiLayer.Models.Attachment.Views;
using Bots.ApiLayer.Models.AttachmentEntity.Views;
using Bots.ApiLayer.Models.Post;
using Bots.ApiLayer.Models.Share.Views;
using Bots.ApiLayer.Models.User.Views;

namespace Bots.ApiLayer.Models.Discuss.Views
{
	/// <summary>
    /// Базовая модель комментария
    /// </summary>
    public class DiscussBaseView
    {
        /// <summary>
        /// Идентификатор комментария
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// Идентификатор родительского комментария, если есть.
        /// </summary>
        public long? parentId { get; set; }
        /// <summary>
        /// Идентификатор события, в котором создан данный комментарий
        /// </summary>
        public long eventId { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public string datecreated { get; set; }
        /// <summary>
        /// Дата создания (строка, например "Вчера, 15:30")
        /// </summary>
        public string datecreatedstr { get; set; }
        /// <summary>
        /// Последнее редактирование комментария (datetime ticks)
        /// </summary>
        public long datelastupdatedticks { get; set; }
        /// <summary>
        /// Если удалено, то указывается кем именно
        /// </summary>
        public DiscussDeletedBy? deleted { get; set; }
        /// <summary>
        /// Признак, что комментарий был отредактирован
        /// </summary>
        public bool edited { get; set; }

	    /// <summary>
        /// Текст комментария
        /// </summary>
        public string message { get; set; }

	    /// <summary>
        /// Признак, что комментарий является новым
        /// </summary>
        public bool isnew { get; set; }
        /// <summary>
        /// Автор комментария
        /// </summary>
        public UserPublicDataView author { get; set; }
        /// <summary>
        /// Вложения
        /// </summary>
        public IList<AttachmentView> attachments { get; set; }
        /// <summary>
        /// Прикреплённое описание внешней ссылки (заголовок, описание, картинка или видео)
        /// </summary>
        public ShareView share { get; set; }
        /// <summary>
        /// Перечень возможных действий с комментарием (контекстное меню)
        /// </summary>
        public IList<string> actions { get; set; }
        /// <summary>
        /// От чьего имено был создан комментарий
        /// </summary>
        public PostAuthor behalf { get; set; }
        /// <summary>
        /// Если комментарий направленный, то указывается кому он направлен
        /// </summary>
        public List<UserPublicDataView> directedAccess { get; set; }
        /// <summary>
        /// Перечень действий с их описанием
        /// </summary>
        public List<AttachmentEntityView> attachedActions { get; set; }
        /// <summary>
        /// Тип комментария
        /// </summary>
        public DiscussionType type { get; set; }
        /// <summary>
		/// Тип комментария
		/// </summary>
		public CommentType commentType { get; set; }        
        /// Автор комментария забанен в рамках события
        /// </summary>
        public bool authorBanned { get; set; }
    }
}