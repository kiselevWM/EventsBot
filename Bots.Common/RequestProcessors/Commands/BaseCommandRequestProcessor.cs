using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests;
using Bots.Common.ExternelModels.Requests.BotCommands;
using Bots.Common.ExternelModels.Requests.BotCommands.ChatMessageCommand;
using Bots.Common.ExternelModels.Requests.BotCommands.DiscussCommand;
using Bots.Common.ExternelModels.Requests.BotCommands.EventCommand;
using Bots.Common.ExternelModels.Requests.BotCommands.MessageCommand;
using Bots.Common.ExternelModels.Responses.BotCommands;
using Bots.Common.ExternelModels.Responses.BotCommands.DiscussCommand;
using Bots.Common.ExternelModels.Responses.BotCommands.EventCommand;
using Bots.Common.ExternelModels.Responses.BotCommands.MessageCommand;
using Bots.Common.Models.Command;
using Bots.Common.RequestProcessors.Base;
using Newtonsoft.Json.Linq;

namespace Bots.Common.RequestProcessors.Commands
{
	/// <summary>
	/// Can be singleton
	/// </summary>
	public abstract class BaseCommandRequestProcessor
		: BaseCustomRequestProcessor<BaseCommandBotRequest<JToken>, BaseCommandBotResponse<ICommandResponseBody>, ICommandResponseBody>
	{
		public override BotRequestType RequestType => BotRequestType.BotCommand;
		private readonly IEnumerable<ICommand> _commands;
		private readonly Dictionary<BotCommandContext, Func<ICommand, BaseCommandBotRequest<JToken>,
			Task<BaseCommandBotResponse<ICommandResponseBody>>>> _commandProcessors;

		protected BaseCommandRequestProcessor(IEnumerable<ICommand> commands)
		{
			if (commands == null) throw new ArgumentNullException(nameof(commands));
			var commandsList = commands.ToList();
			if(commandsList.GroupBy(x => x.UniqueName).Any(x => x.Count() > 1)) throw new ArgumentException("duplicate commands", nameof(commands));			
			_commands = commandsList;
			_commandProcessors =
				new Dictionary<BotCommandContext, Func<ICommand, BaseCommandBotRequest<JToken>, Task<BaseCommandBotResponse<ICommandResponseBody>>>>
				{
					{
						BotCommandContext.DiscussPostForm, async (command, request) => CastResponse(
								await ProcessWrapper<BaseCommandBotRequest<DiscussCommandBotRequest>, DiscussCommandBotRequest, 
									BaseCommandBotResponse<IDiscussCommandResponse>, IDiscussCommandResponse>(request, CreateRequest, 
									command.ExecAsync), request.token)
					},
					{
						BotCommandContext.EventPostForm, async (command, request) => CastResponse(
								await ProcessWrapper<BaseCommandBotRequest<EventCommandBotRequest>, EventCommandBotRequest, 
									BaseCommandBotResponse<IEventCommandResponse>, IEventCommandResponse>(request, CreateRequest, command.ExecAsync),
								request.token)
					},
					{
						BotCommandContext.MessagingPostForm, async (command, request) => CastResponse(
								await ProcessWrapper<BaseCommandBotRequest<MessageCommandBotRequest>, MessageCommandBotRequest, 
									BaseCommandBotResponse<IMessageCommandResponse>, IMessageCommandResponse>(request, CreateRequest, command.ExecAsync),
								request.token)
					},
					{
						BotCommandContext.ChatPostForm, async (command, request) => CastResponse(
								await ProcessWrapper<BaseCommandBotRequest<ChatMessageCommandBotRequest>, ChatMessageCommandBotRequest, 
									BaseCommandBotResponse<IMessageCommandResponse>, IMessageCommandResponse>(request, CreateRequest, command.ExecAsync),
								request.token)
					}
				};
		}
		protected BaseCommandBotResponse<ICommandResponseBody> CastResponse<TResponseBody>(BaseCommandBotResponse<TResponseBody> response, string token) where TResponseBody : ICommandResponseBody
		{
			return response == null ? null : new BaseCommandBotResponse<ICommandResponseBody>(response.respType, response.response, token);
		}
		protected override bool TryGetProcessor(BaseCommandBotRequest<JToken> request, 
			out Func<BaseCommandBotRequest<JToken>, Task<BaseCommandBotResponse<ICommandResponseBody>>> func)
		{
			if (!string.IsNullOrEmpty(request.commandName))
			{
				var command = _commands.FirstOrDefault(x => x.UniqueName == request.commandName);
				if (command != null)
				{
					if (_commandProcessors.TryGetValue(request.ctx, out var commandFunc))
					{
						func = botRequest => commandFunc(command, botRequest);
						return true;
					}

				}
			}
			func = null;
			return false;
		}
		private static BaseCommandBotRequest<TRequestBody> CreateRequest<TRequestBody>(BaseCommandBotRequest<JToken> request, TRequestBody requestBody)
		{
			return new BaseCommandBotRequest<TRequestBody>(request.userWmid, request.commandName,requestBody, request.lng, request.token, request.ctx);				
		}
	}
}