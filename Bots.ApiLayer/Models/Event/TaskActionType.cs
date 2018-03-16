namespace Bots.ApiLayer.Models.Event
{
	public enum TaskActionType
	{
		/// <summary>
		/// Для контролера. Есть исполнители, которые отметили задачу как выполненную, - от контролера требуется либо принять задачу, либо отложить её. 
		/// +
		/// отложить задачу: ApiTaskController, action = ControllerPostpone
		/// принять задачу: ApiTaskController, action = ControllerSetFinish
		/// String.Format(desc, String.Join(",", participants))
		/// </summary>
		ControllerAcceptOrPostpone = 1,
		/// <summary>
		/// Для исполнителя. Ранее исполнитель отметил задачу, как выполненную. Но один из контролеров не принял задачу. Исполнителю выводится эта информация и какой контролер её отложил + кнопка "ОК" (или "Закрыть").
		/// + красная плашка с текстом: "Задача отложена контролером" с кнопкой ОК (или Закрыть)
		/// ApiTaskController, action = ExecuterAcceptPostpone
		/// String.Format(desc, String.Join(",", participants))
		/// </summary>
		ExecuterPostponed = 3,
		/// <summary>
		/// Для автора платной задачи. Неизвестная ошибка, которая была получена при общении с WebMoney.Mentor. Выводится кнопка "Повторить снова" или "Отменить задачу".
		/// - ? - если на нее нажать, то что?
		/// повторить снова: ApiTaskController, action = MentorCheck
		/// отменить задачу: ApiTaskController, action = MentorCancel
		/// String.Format(desc, String.Join(",", participants))
		/// </summary>
		AuthorMentorUnknowError = 4,
		/// <summary>
		/// Для автора платной задачи. Отсутствует доверие на кошелёк автора, с которого должна проивзводиться оплата задачи. Выводится кнопка "Выставить доверие" или "Отменить задачу".
		/// -
		/// выставить доверие: ApiTaskController, action = MentorTrustSet
		/// отменить задачу: ApiTaskController, action = MentorCancel
		/// String.Format(desc, String.Join(",", participants))
		/// </summary>
		AuthorMentorNoTrustError = 5,
		/// <summary>
		/// Для автора платной задачи. Превышин лимит по кошельку. Выводится сообщение, чтобы изменили ограничение по кошельку и кнопка "Проверить" или "Отменить задачу".
		/// -
		/// проверить: ApiTaskController, action = MentorCheck
		/// отменить задачу: ApiTaskController, action = MentorCancel
		/// String.Format(desc, String.Join(",", participants))
		/// </summary>
		AuthorMentorTrustLimitError = 6,
		/// <summary>
		/// Для автора платной задачи. Не достаточно средств на кошельке. Выводится сообщение, чтобы пополнили кошелек и кнопка "Проверить" или "Отменить задачу".
		/// -
		/// проверить: ApiTaskController, action = MentorCheck
		/// отменить задачу: ApiTaskController, action = MentorCancel
		/// String.Format(desc, String.Join(",", participants))
		/// </summary>
		AuthorMentorNoFundsError = 7,
		/// <summary>
		/// Для исполнителя. Кнопка "задача выполнена".
		/// +
		/// ApiTaskController, action = ExecuterSetFinish
		/// </summary>
		ExecuterDone = 8,
		/// <summary>
		/// Для любого участника группы. Кнопка "Стать исполнителем".
		/// + желтая плашка с кнопкой стать исполнителем
		/// ApiTaskController, action = BecomeExecuter
		/// выводить просто desc
		/// </summary>
		BecomeExecuter = 9,
        /// <summary>
        /// Согласиться или отказаться от участия в задаче
        /// </summary>
        AgreeOrDisagree = 10
	}
}