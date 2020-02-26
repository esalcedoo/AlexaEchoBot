using AlexaEchoBot.Alexa;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Alexa;
using AlexaNET = Alexa.NET;
using AlexaEchoBot.Intents;
using System.Linq;
using Alexa.NET.Request.Type;

namespace AlexaEchoBot.Bots
{
    public class AlexaBot : AlexaActivityHandler
    {
        private readonly IEnumerable<IIntentHandler> _handlers;

        public AlexaBot(IEnumerable<IIntentHandler> handlers)
        {
            _handlers = handlers;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            
            IntentRequest intentRequest = turnContext.GetAlexaRequestBody().Request as IntentRequest;

            var handler = _handlers.FirstOrDefault(intent => intent.IsValid(intentRequest.Intent.Name));
            await handler.Handle(turnContext, cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text("Hola mundo!"), cancellationToken);
        }
    }
}
