//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Bots.ApiLayer.Api.Discuss;
//using Bots.ApiLayer.Api.Message;
//using Bots.ApiLayer.Models.Message.Forms;
//using Bots.ApiLayer.Models.Message.Views;
//using Bots.ApiLayer.Models.Post;
//using Bots.ApiLayer.Models.User.Views;
//using Bots.Common.ExternelModels.Requests.BotEvents;
//using Bots.Common.ExternelModels.Requests.BotEvents.PostGroupDiscuss;
//using Bots.Common.ExternelModels.Requests.BotEvents.PostGroupEvent;
//using Bots.Common.ExternelModels.Requests.BotEvents.PostMessage;
//using Bots.Common.ExternelModels.Responses.BotEvents;
//using Bots.Common.ExternelModels.Responses.BotEvents.Message;
//using Bots.Common.ExternelModels.Responses.BotEvents.PostGroupDiscuss;
//using Bots.Common.Models.Events;
//using Bots.Common.RequestProcessors.Base;
//using Bots.Common.RequestProcessors.Events;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Newtonsoft.Json.Linq;

//namespace Bots.Common.Tests.RequestProcessorsTests.BaseEventsRequestProcessorTests
//{
//	[TestClass]
//	public class BaseEventsRequestProcessorTests
//	{
//		private class TestEventRequestProcessor: BaseEventsRequestProcessor
//		{
//			public TestEventRequestProcessor(BaseEventsProcessor eventsProcessor, IMessageApi messageApi, IDiscussApi disucussApi,
//				IProcessSettings settings) 
//				: base(eventsProcessor, messageApi, disucussApi, settings){}
//		}

//		private class TestEventsProcessor : BaseEventsProcessor
//		{
//			private readonly Func<Task> _delayFunc;
//			public TestEventsProcessor(Func<Task> delayFunc)
//			{
//				_delayFunc = delayFunc;
//			}

//			public override async Task<BaseEventsBotResponse<PostMessageResponse>> ProcessAsync(BaseEventsBotRequest<PostMessageRequest> request)
//			{
//				await _delayFunc().ConfigureAwait(false);
//				return new BaseEventsBotResponse<PostMessageResponse>
//				{
//					response = new PostMessageResponse()
//				};
//			}

//			public override async Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<PostGroupDicussRequest> request)
//			{
//				await _delayFunc().ConfigureAwait(false);
//				return new BaseEventsBotResponse<PostGroupDicussResponse>
//				{
//					response = new PostGroupDicussResponse()
//				};
//			}
			
//		}

//		private readonly Mock<IMessageApi> _messageApiMock;
//		private readonly Mock<IDiscussApi> _discussApiMock;
//		private readonly Mock<IProcessSettings> _settingsMock;
//		public BaseEventsRequestProcessorTests()
//		{
//			_discussApiMock = new Mock<IDiscussApi>();
//			_messageApiMock = new Mock<IMessageApi>();
//			_settingsMock = new Mock<IProcessSettings>();
//		}

//		[TestMethod]
//		public async Task BaseEventsRequestProcessorDelayedProcessTest()
//		{
//			var minimalTimeout = new TimeSpan(0, 0, 0, 0, 50);
//			var eventsExecTimeout = new TimeSpan(0, 0, 0, 0, 200);
//			var delayedRequestTimeout = new TimeSpan(0,0,0,0,50);
//			_settingsMock.Setup(x => x.ExecTimeout).Returns(eventsExecTimeout);
//			_settingsMock.Setup(x => x.DelayedRequestTimeout).Returns(delayedRequestTimeout);

//			var messageIsSentThrowApi = false;
//			var userWmid = "wmid";
//			_messageApiMock.Setup(x => x.BotPostAsync(It.IsAny<BotPostMessageForm>(), It.IsAny<TimeSpan>()))
//				.Returns<BotPostMessageForm, TimeSpan>((form, timeout) =>
//				{
//					Assert.IsNotNull(form?.corsWmid);
//					Assert.AreEqual(1, form.corsWmid.Count);
//					Assert.AreEqual(userWmid, form.corsWmid.First());
//					messageIsSentThrowApi = true;
//					return Task.FromResult<IEnumerable<MessageAdvancedView>>(new List<MessageAdvancedView>());
//				});

//			async Task TestBodyMeth(Func<Task> delayFunc)
//			{
//				messageIsSentThrowApi = false;
//				var testEventRequestProcessor = new TestEventRequestProcessor(
//					new TestEventsProcessor(delayFunc), _messageApiMock.Object, _discussApiMock.Object, _settingsMock.Object);

//				await testEventRequestProcessor
//					.ProcessAsync(new BaseEventsBotRequest<JToken>(BotEvent.Message, JToken.FromObject(new PostMessageRequest
//						{
//							author = new UserIdentsView{wmid = userWmid}
//						}), null,
//						null)).ConfigureAwait(false);
//				await Task.Delay(eventsExecTimeout.Add(minimalTimeout).Add(minimalTimeout));
//				Assert.IsTrue(messageIsSentThrowApi);
//			}

//			await TestBodyMeth(async () => Thread.Sleep(eventsExecTimeout.Add(minimalTimeout))).ConfigureAwait(false);
//			await TestBodyMeth(async () => await Task.Delay(eventsExecTimeout.Add(minimalTimeout)).ConfigureAwait(false)).ConfigureAwait(false);
//		}

//	}
//}