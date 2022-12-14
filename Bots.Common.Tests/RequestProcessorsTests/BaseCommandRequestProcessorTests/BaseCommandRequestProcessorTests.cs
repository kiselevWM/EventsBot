using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using BaseCommandRequestProcessor = Bots.Common.RequestProcessors.Commands.BaseCommandRequestProcessor;

namespace Bots.Common.Tests.RequestProcessorsTests.BaseCommandRequestProcessorTests
{
	[TestClass]
	public class BaseCommandRequestProcessorTests
	{
		private abstract class BaseCmd
		{
			public bool MesCmdExecuted { get; set; }
			public bool DiscussCmdExecuted { get; set; }
			public bool EventCmdExecuted { get; set; }
			public bool ChatMesCmdExecuted { get; set; }

			public Task<BaseCommandBotResponse<IMessageCommandResponse>> ExecAsync(BaseCommandBotRequest<MessageCommandBotRequest> request)
			{
				MesCmdExecuted = true;
				return Task.FromResult<BaseCommandBotResponse<IMessageCommandResponse>>(null);
			}

			public Task<BaseCommandBotResponse<IDiscussCommandResponse>> ExecAsync(BaseCommandBotRequest<DiscussCommandBotRequest> request)
			{
				DiscussCmdExecuted = true;
				return Task.FromResult<BaseCommandBotResponse<IDiscussCommandResponse>>(null);
			}

			public Task<BaseCommandBotResponse<IEventCommandResponse>> ExecAsync(BaseCommandBotRequest<EventCommandBotRequest> request)
			{
				EventCmdExecuted = true;
				return Task.FromResult<BaseCommandBotResponse<IEventCommandResponse>>(null);
			}
			public Task<BaseCommandBotResponse<IMessageCommandResponse>> ExecAsync(BaseCommandBotRequest<ChatMessageCommandBotRequest> request)
			{
				ChatMesCmdExecuted = true;
				return Task.FromResult<BaseCommandBotResponse<IMessageCommandResponse>>(null);
			}
		}

		private const string Cmd1Name = "cmd1";
		private class Cmd : BaseCmd, ICommand
		{
			public string UniqueName => Cmd1Name;
		}
		private class CmdDouble : BaseCmd, ICommand
		{
			public string UniqueName => Cmd1Name;
		}
		private class Cmd2 : BaseCmd, ICommand
		{
			public string UniqueName => "Cmd2";
		}
		private class CommandRequestProcessorTest : BaseCommandRequestProcessor
		{
			public CommandRequestProcessorTest(IEnumerable<ICommand> commands) : base(commands)
			{
			}
		}

		[TestMethod]
		public async Task BCRPDublicateCmdFail()
		{
			var cmd = new Cmd();
			try
			{
				new CommandRequestProcessorTest(new List<ICommand> { cmd, new CmdDouble() });
				Assert.Fail("Do not process doublicate commands");
			}
			catch (ArgumentException e) { }

			try
			{
				new CommandRequestProcessorTest(new List<ICommand> { cmd, cmd });
				Assert.Fail("Do not process doublicate commands");
			}
			catch (ArgumentException e) { }
		}

		private void CheckFailResponse(BaseCommandBotResponse<ICommandResponseBody> botResponse)
		{
			Assert.IsNull(botResponse);
			//Assert.IsNotNull(botResponse);
			//Assert.AreEqual(CommandBotResponseType.StateCommand, botResponse.respType);
			//Assert.IsNotNull(botResponse.response);
			//var botResponseBody = botResponse.response as BotCommandStateResponse;
			//Assert.IsNotNull(botResponseBody);
			//Assert.AreEqual(BotCommandStateType.Error, botResponseBody.state);
		}

		[TestMethod]
		public async Task BCRPNotFoundCmdFail()
		{
			var cmd = new Cmd();
			var processor = new CommandRequestProcessorTest(new List<ICommand>());
			var response = await processor.ProcessAsync(new BaseCommandBotRequest<JToken>(null, null, JToken.FromObject("aaa"), null, null, BotCommandContext.DiscussPostForm ));
			CheckFailResponse(response);

			processor = new CommandRequestProcessorTest(new List<ICommand> { cmd });
			response = await processor.ProcessAsync(new BaseCommandBotRequest<JToken>(null, "notExistedCommand",
				JToken.FromObject(new DiscussCommandBotRequest()), null, null, BotCommandContext.DiscussPostForm));
			CheckFailResponse(response);
		}

		[TestMethod]
		public async Task BCRPNotFoundCtxCmdFail()
		{
			var cmd = new Cmd();
			var cmd2 = new Cmd2();
			var processor = new CommandRequestProcessorTest(new List<ICommand> { cmd, cmd2 });
			var response = await processor.ProcessAsync(new BaseCommandBotRequest<JToken>(null, cmd.UniqueName,
				JToken.FromObject(new DiscussCommandBotRequest()), null, null, (BotCommandContext)5));
			CheckFailResponse(response);
		}

		[TestMethod]
		public async Task BCRPFindCmdOK()
		{ 
			var cmd = new Cmd();
			var cmd2 = new Cmd2();
			var processor = new CommandRequestProcessorTest(new List<ICommand> { cmd, cmd2 });
			var request = new BaseCommandBotRequest<JToken>(null, cmd.UniqueName,
				JToken.FromObject(new DiscussCommandBotRequest()), null, null, BotCommandContext.DiscussPostForm);
			await processor.ProcessAsync(request);
			Assert.IsTrue(cmd.DiscussCmdExecuted);
			Assert.IsFalse(cmd.EventCmdExecuted);
			Assert.IsFalse(cmd.MesCmdExecuted);
			Assert.IsFalse(cmd.ChatMesCmdExecuted);
			cmd.DiscussCmdExecuted = false;

			request.ctx = BotCommandContext.EventPostForm;
			await processor.ProcessAsync(request);
			Assert.IsFalse(cmd.DiscussCmdExecuted);
			Assert.IsTrue(cmd.EventCmdExecuted);
			Assert.IsFalse(cmd.MesCmdExecuted);
			Assert.IsFalse(cmd.ChatMesCmdExecuted);
			cmd.EventCmdExecuted = false;

			request.ctx = BotCommandContext.MessagingPostForm;
			await processor.ProcessAsync(request);
			Assert.IsFalse(cmd.DiscussCmdExecuted);
			Assert.IsFalse(cmd.EventCmdExecuted);
			Assert.IsTrue(cmd.MesCmdExecuted);
			Assert.IsFalse(cmd.ChatMesCmdExecuted);

			cmd.MesCmdExecuted = false;
			request.ctx = BotCommandContext.ChatPostForm;
			await processor.ProcessAsync(request);
			Assert.IsFalse(cmd.DiscussCmdExecuted);
			Assert.IsFalse(cmd.EventCmdExecuted);
			Assert.IsFalse(cmd.MesCmdExecuted);
			Assert.IsTrue(cmd.ChatMesCmdExecuted);
		}
	}
}