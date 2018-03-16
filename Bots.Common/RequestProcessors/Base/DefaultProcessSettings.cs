using System;

namespace Bots.Common.RequestProcessors.Base
{
	public class DefaultProcessSettings: IProcessSettings
	{
		public TimeSpan ExecTimeout => new TimeSpan(0,0,0,2);
		public TimeSpan DelayedRequestTimeout => new TimeSpan(0,0,0,30);
	}
}