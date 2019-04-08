using System;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }

    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the none intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("Greeting")]
    public async Task Greeting(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Hi Patient, My name is Dr.Botter, your friendly doctor bot :D \n How may I help you?"); //
        context.Wait(MessageReceived);
    }
    
    [LuisIntent("IllChecker")]
    public async Task IllChecker(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Dear Patient, before i look into your condition, may I have your name please?"); //
        context.Wait(MessageReceived);
    }
    
    [LuisIntent("NameChecker")]
    public async Task NameChecker(IDialogContext context, LuisResult result)
    {
        var username = result.Query;
        await context.PostAsync($"Dear " + username + ". What is your condition?"); //
        context.Wait(MessageReceived);
    }
    
    [LuisIntent("MedicalConditionChecker")]
    public async Task MedicalConditionChecker(IDialogContext context, LuisResult result)
    {
        var condition = result.Query;
        await context.PostAsync($"To confirm, did you say that you are suffering from " + condition); //
        context.Wait(MessageReceived);
    }
}