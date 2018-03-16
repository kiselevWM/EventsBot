using System.Collections.Generic;
using Bots.ApiLayer.Models.Icon.Views;

namespace Bots.ApiLayer.Models.EventGenerator.Views
{
	public class EventGeneratorView
	{
		/// <summary>
        /// Идентификатор сервиса
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Название сервиса
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Описание сервиса
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// Url сервиса
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// Иконки сервиса
        /// </summary>
        public IList<IconView> icons { get; set; }
        /// <summary>
        /// Название группы сервисов, к которой он принадлежит
        /// </summary>
        public string groupName { get; set; }
	}
}