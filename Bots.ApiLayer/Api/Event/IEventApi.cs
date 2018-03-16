using System;
using System.Threading.Tasks;
using Bots.ApiLayer.Models.Event.Forms;
using Bots.ApiLayer.Models.Event.Views;

namespace Bots.ApiLayer.Api.Event
{
	public interface IEventApi
	{
		Task<EventView> BotPostAsync(BotPostEventForm form, TimeSpan? timeSpan = null);
		Task<EventAdvancedView> BotUpdateAsync(BotEventUpdateForm form, TimeSpan? timeSpan = null);
	}
}