namespace Bots.ApiLayer.Models.Event
{
	public enum TaskStatus
	{
		Waiting = 0,
        WaitingExecuter = 5,
        Launched = 1,
        Finished = 2,
        MentorExpired = 3,
        Postpone = 4,
        ExecutersReactTimeoutExpired = 6,
        ControllersReactTimeoutExpired = 7,
        DateEndExpired = 8
	}
}