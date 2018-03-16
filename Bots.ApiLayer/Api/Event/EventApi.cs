using System;
using System.Threading.Tasks;
using Bots.ApiLayer.Api.Base;
using Bots.ApiLayer.Models.Event.Forms;
using Bots.ApiLayer.Models.Event.Views;

namespace Bots.ApiLayer.Api.Event
{
	public class EventApi: BaseWebApi, IEventApi
	{
		protected override string Controller => "Event";
		public EventApi(string token, string apiUrl = null) : base(token, apiUrl){}
		public async Task<EventView> BotPostAsync(BotPostEventForm form, TimeSpan? timeSpan = null)
		{
			return await SendPostRequest<BotPostEventForm, EventView>("BotPost", form, timeSpan).ConfigureAwait(false);
		}
		public async Task<EventAdvancedView> BotUpdateAsync(BotEventUpdateForm form, TimeSpan? timeSpan = null)
		{
			return await SendPostRequest<BotEventUpdateForm, EventAdvancedView>("BotUpdate", form, timeSpan).ConfigureAwait(false);
		}
	}
}