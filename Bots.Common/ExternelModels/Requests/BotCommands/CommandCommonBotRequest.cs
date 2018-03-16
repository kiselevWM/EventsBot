namespace Bots.Common.ExternelModels.Requests.BotCommands
{
	public abstract class CommandCommonBotRequest 
	{
		protected CommandCommonBotRequest(){}
		protected CommandCommonBotRequest(string message)
		{
			this.message = message;
		}
		public string message { get; set; }
	}
}