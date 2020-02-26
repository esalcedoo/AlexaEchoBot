using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace AlexaEchoBot.Intents
{
    public interface IIntentHandler
    {
        internal Task Handle(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken);
        internal bool IsValid (string intent);
    }
}
