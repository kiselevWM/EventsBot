namespace Bots.Common.RequestProcessors.Base
{
	public interface IBotAuthService
	{
		bool IsAuthBotRequest(string requestToken);
	}
}