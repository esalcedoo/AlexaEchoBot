using AlexaEchoBot.Alexa;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Alexa;
using AlexaNET = Alexa.NET;

namespace AlexaEchoBot.Bots
{
    public class AlexaBot : AlexaActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var alexaRequestBody = turnContext.GetAlexaRequestBody().Request as AlexaNET.Request.Type.IntentRequest;
            var alexaRequestBodyFromChannelData = turnContext.Activity.ChannelData as AlexaNET.Request.SkillRequest;
            await turnContext.SendActivityAsync(MessageFactory.Text($"Echo: {turnContext.Activity.Text}"), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text($"Hola mundo!"), cancellationToken);
        }
    }
}
