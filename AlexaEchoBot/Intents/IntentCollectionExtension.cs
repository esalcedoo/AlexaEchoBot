using AlexaEchoBot.Intents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IntentCollectionExtension
    {
        public static IServiceCollection AddIntents(this IServiceCollection services)
        {
            services.AddTransient<IIntentHandler, FirstIntentIntentHandler>();
            services.AddTransient<IIntentHandler, SecondIntentIntentHandler>();
            return services;
        }
    }
}
