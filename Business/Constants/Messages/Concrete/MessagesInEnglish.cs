using System;
using Business.Constants.Messages.Abstract;

namespace Business.Constants.Messages.Concrete
{
    public class MessagesInEnglish : IMessage
    {
        public MessagesInEnglish()
        {
            LanguagesListed = "Languages were listed.";
            LanguageAlreadyExists = "The language already exists.";
            LanguageAdded = "The language has been successfully added.";
            LanguageDeleted = "The language has been deleted.";
            LanguageUpdated = "The language has been updated.";
        }

        public string LanguagesListed { get; }
        public string LanguageAlreadyExists { get; }
        public string LanguageAdded { get; }
        public string LanguageDeleted { get; }
        public string LanguageUpdated { get; }
    }
}

