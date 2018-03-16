namespace Bots.Common.ExternelModels.Requests.BotActions
{
	public class BaseActionsBotRequest<TRequestBody> : BaseBotRequest<TRequestBody>
	{
		public BaseActionsBotRequest(){}

		public BaseActionsBotRequest(string attachmentUid, string actionUid, string userWmid, TRequestBody context, string lng, string token, 
			BotActionContextType contextType) 
			: base(context, token, lng, BotRequestType.BotAction)
		{
			this.attachmentUid = attachmentUid;
			this.actionUid = actionUid;
			this.userWmid = userWmid;
			this.contextType = contextType;
		}
		public BotActionContextType contextType { get; set; }
		public string attachmentUid { get; set; }
		public string actionUid { get; set; }
		public string userWmid { get; set; }
	}
}