using System;
using Business.Constants.Messages.Abstract;

namespace Business.Constants.Messages.Concrete
{
    public class MessagesInEnglish : IMessage
    {
        public MessagesInEnglish()
        {
            //Language
            LanguagesListed = "Languages were listed.";
            LanguageAlreadyExists = "The language already exists.";
            LanguageAdded = "The language has been successfully added.";
            LanguageDeleted = "The language has been deleted.";
            LanguageUpdated = "The language has been updated.";

            //Folder
            FoldersListed = "Folders were listed.";
            FolderAlreadyExists = "The folder name already exists.";
            FolderAdded = "The folder has been successfully added.";
            FolderUpdated = "The folder has been updated.";
        }

        //Language
        public string LanguagesListed { get; }
        public string LanguageAlreadyExists { get; }
        public string LanguageAdded { get; }
        public string LanguageDeleted { get; }
        public string LanguageUpdated { get; }

        //Folder
        public string FoldersListed { get; }
        public string FolderAlreadyExists { get; }
        public string FolderAdded { get; }
        public string FolderUpdated { get; }
    }
}

