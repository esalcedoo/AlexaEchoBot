using Bot.Builder.Community.Adapters.Alexa;
using Bot.Builder.Community.Adapters.Alexa.Integration.AspNet.Core;
using Bot.Builder.Community.Adapters.Alexa.Middleware;
using AlexaEchoBot.Bots;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AlexaServiceCollectionExtension
    {
        public static IServiceCollection AddAlexa(this IServiceCollection services)
        {
            // Create the Alexa bot as a transient. In this case the ASP Controller is expecting an IBot.
            services.TryAddTransient<AlexaBot>();

            services.TryAddSingleton<IAlexaHttpAdapter>(_ =>
            {
                AlexaAdapterOptions alexaAdapterOptions = new AlexaAdapterOptions()
                {
                    MultipleOutgoingActivitiesPolicy = MultipleOutgoingActivitiesPolicies.ConcatenateTextSpeakPropertiesFromAllActivities,
                    ShouldEndSessionByDefault = false,
                    ValidateIncomingAlexaRequests = true,
                    TryConvertFirstActivityAttachmentToAlexaCard = false
                };

                var alexaHttpAdapter = new AlexaHttpAdapter(alexaAdapterOptions)
                {
                    OnTurnError = async (context, exception) =>
                    {
                        await context.SendActivityAsync("<say-as interpret-as=\"interjection\">boom</say-as>, explotó.");
                    }
                };
                alexaHttpAdapter.Use(new AlexaIntentRequestToMessageActivityMiddleware(transformPattern: RequestTransformPatterns.MessageActivityTextFromSinglePhraseSlotValue));
                return alexaHttpAdapter;
            });

            return services;
        }
    }
}
