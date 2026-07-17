using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "What is the best thing that happened to me today?",
            "What did God do as a miracle today in my life?",
            "Who was the most interesting person i interacted with today?",
            "What is the strongest emotion i felt today?",
            "What life lession did i learn today?",
            "What did i do to manage my time today?",
            "What help did i ask the holy spirit for today?",
            "What made me smile today?",
            "What did i do to help someone today?",
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();

        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }
}