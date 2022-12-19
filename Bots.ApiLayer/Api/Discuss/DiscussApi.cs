using System;
using System.Threading.Tasks;
using Bots.ApiLayer.Api.Base;
using Bots.ApiLayer.Models.Discuss.Forms;
using Bots.ApiLayer.Models.Discuss.Views;

namespace Bots.ApiLayer.Api.Discuss
{
	public class DiscussApi: BaseWebApi, IDiscussApi
	{
		public DiscussApi(string token, string apiUrl = null) : base(token, apiUrl){}
		protected override string Controller => "Discuss";
		public async Task<DiscussPostView> BotFastPostAsync(BotPostDiscussionForm form, TimeSpan? timeSpan = null)
		{
			if (form == null) return null;
			return await SendPostRequest<BotPostDiscussionForm, DiscussPostView>("BotFastPost", form, timeSpan).ConfigureAwait(false);
		}

		public async Task<DiscussPostView> BotPostAsync(BotPostDiscussionForm form, TimeSpan? timeSpan = null)
		{
			if (form == null) return null;
			return await SendPostRequest<BotPostDiscussionForm, DiscussPostView>("BotPost", form, timeSpan).ConfigureAwait(false);
		}

		public async Task<DiscussView> BotUpdateAsync(BotUpdateDiscussForm form, TimeSpan? timeSpan = null)
		{
			return await SendPostRequest<BotUpdateDiscussForm, DiscussView>("BotUpdate", form, timeSpan).ConfigureAwait(false);
		}
	}
}