using System.ComponentModel;

namespace Bots.ApiLayer.Models.Discuss
{
	public enum DiscussionType
	{
		[Description("обычное")]
        Regular = 1,

        [Description("ручное через API (мобильные устройства)")]
        APICreated = 2,

        [Description("Системное уведомление")]
        SystemNotify = 3,

        [Description("Направленный комментарий")]
        DirectedAccess = 4,

        [Description("Системное уведомление, предоставление доступа к событию")]
        SystemNotifyAccessGrantedToEvent = 5,

        [Description("Системное уведомление, удаление доступа к событию")]
        SystemNotifyRemoveAccessFromEvent = 6,

        [Description("Системное уведомление, пользователь согласился быть исполнителем задачи")]
        SystemNotifyTaskExecuterAgree = 7,

        [Description("Системное уведомление, пользователь отказался быть исполнителем задачи")]
        SystemNotifyTaskExecuterDisagree = 8,

        [Description("Системное уведомление, пользователь согласился быть контролером задачи")]
        SystemNotifyTaskControllerAgree = 9,

        [Description("Системное уведомление, пользователь отказался быть контролером задачи")]
        SystemNotifyTaskControllerDisagree = 10,

        [Description("Системное уведомление, исполнитель отметил, что задача выполнена")]
        SystemNotifyTaskExecuterSetFinish = 11,

        [Description("Системное уведомление, контролер отметил, что задача выполнена")]
        SystemNotifyTaskControllerSetFinish = 12,

        [Description("Системное уведомление, контролер не принял решение задачи")]
        SystemNotifyTaskControllerPostponed = 13,

        [Description("Системное уведомление, истек срок выполнения платной задачи, задача отменена, средства возвращены на исходный кошелек")]
        SystemNotifyTaskMentorExpire = 14,

        [Description("Системное уведомление, задача не принята к исполнению, переведена в состояние неактивна")]
        SystemNotifyTaskExecutersNotConfirmed = 15,

        [Description("Системное уведомление, контролер не принял участие в задаче, задача переведена в состояние неактивна")]
        SystemNotifyTaskControllersNotConfirmed = 16,

        [Description("Системное уведомление, при попытке автоматически завершить задачу в менторе - произошла ошибка")]
        SystemNotifyTaskAutoFinishedError = 17,

        [Description("Системное уведомление, ввиду длительного отсутствия реакции от контролера - задача автоматически переведена в состояние завершена")]
        SystemNotifyTaskAutoFinished = 18,

        [Description("Системное уведомление, истек срок выполнения задачи")]
        SystemNotifyTaskExpire = 19,

        [Description("Системное уведомление, файл откредактировать у события")]
        SystemNotifyReplaceAttachment = 20,

        [Description("Системное уведомление, задача прикпелена к событию")]
        SystemNotifyTaskAttached = 21,

        [Description("Системное уведомление, голосовалка прикпелена к событию")]
        SystemNotifyVotingAttached = 22,

        [Description("Системное уведомление, файлы прикреплены к событию")]
        SystemNotifyFilesAttached = 23,

        [Description("Системное уведомление, пользователь забанне в рамках события")]
        UserBanned = 24,
	}
}