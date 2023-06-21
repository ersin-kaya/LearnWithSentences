using System;
using Business.Constants.Messages.Abstract;

namespace Business.Constants.Messages.Concrete
{
    public class MessagesInEnglish : IMessage
    {
        public MessagesInEnglish()
        {
            LanguageAlreadyExists = "The language already exists.";
            LanguageAdded = "The language has been successfully added.";
        }

        public string LanguageAlreadyExists { get; }
        public string LanguageAdded { get; }
    }
}

