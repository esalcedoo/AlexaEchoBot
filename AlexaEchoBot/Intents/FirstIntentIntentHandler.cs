using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlexaEchoBot.Intents
{
    public class FirstIntentIntentHandler : IIntentHandler
    {
        async Task IIntentHandler.Handle(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text("1º Intent", "First Intent"), cancellationToken);
        }

        bool IIntentHandler.IsValid(string intent) => intent == "FirstIntent";
    }
}
