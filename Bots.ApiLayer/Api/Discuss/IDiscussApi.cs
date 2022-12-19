using System;
using System.Threading.Tasks;
using Bots.ApiLayer.Models.Discuss.Forms;
using Bots.ApiLayer.Models.Discuss.Views;

namespace Bots.ApiLayer.Api.Discuss
{
	public interface IDiscussApi
	{
		Task<DiscussPostView> BotPostAsync(BotPostDiscussionForm form, TimeSpan? timeSpan = null);
		Task<DiscussPostView> BotFastPostAsync(BotPostDiscussionForm form, TimeSpan? timeSpan = null);
		Task<DiscussView> BotUpdateAsync(BotUpdateDiscussForm form, TimeSpan? timeSpan = null);
	}
}