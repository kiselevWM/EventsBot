namespace Bots.ApiLayer.Models.Event
{
	/// <summary>
    /// Доступные действия по событию
    /// </summary>
    public enum EventAction
    {
        /// <summary>
        /// Добавить в избранные
        /// </summary>
        FavoriteAdd = 1,
        /// <summary>
        /// Удалить из избранных
        /// </summary>
        FavoriteDel = 2,
        /// <summary>
        /// Подписаться на дискуссию
        /// </summary>
        SubscribeAdd = 3,
        /// <summary>
        /// Отписаться от дискуссии
        /// </summary>
        SubscribeDel = 4,
        /// <summary>
        /// Редактировать
        /// </summary>
        Edit = 5,
        /// <summary>
        /// Удалить
        /// </summary>
        Del = 6,
        /// <summary>
        /// Пометить как спам
        /// </summary>
        Spam = 7,
        /// <summary>
        /// Пометить как спам (расширенные возможности для админа группы)
        /// </summary>
        SpamAdvanced = 8,
        /// <summary>
        /// Скрыть
        /// </summary>
        Hide = 9,
        /// <summary>
        /// Прикрепить задачу
        /// </summary>
        TaskAdd = 10,
        /// <summary>
        /// Удалить задачу
        /// </summary>
        TaskDel = 11,
        /// <summary>
        /// Редактировать задачу
        /// </summary>
        TaskEdit = 12,
        /// <summary>
        /// Повторить задачу
        /// </summary>
        TaskRepeat = 13,
        /// <summary>
        /// Прекратить дискуссию
        /// </summary>
        DiscussionStop = 14,
        /// <summary>
        /// Возобновить дискуссию
        /// </summary>
        DiscussionStart = 15,
        /// <summary>
        /// Выделить событие (в топ ленты группы)
        /// </summary>
        PinSet = 16,
        /// <summary>
        /// Убрать выделение события
        /// </summary>
        PinDel = 17,
        /// <summary>
        /// Перенести в историю (событие с завершенной задачей)
        /// </summary>
        History = 18,
        /// <summary>
        /// Прикрепить голосование
        /// </summary>
        VotingAdd = 19,
        /// <summary>
        /// Удалить голосование
        /// </summary>
        VotingDel = 20,
        /// <summary>
        /// Остановить голосование
        /// </summary>
        VotingStop = 21,
        /// <summary>
        /// Редактировать настройки повторяемости у задачи
        /// </summary>
        TaskEditRepeatOptions = 22,
        /// <summary>
        /// Предоставить доступ к событию
        /// </summary>
        SetAccess = 23,
        /// <summary>
        /// Вернуть в ленту
        /// </summary>
        ShowInFeed = 24
    }
}