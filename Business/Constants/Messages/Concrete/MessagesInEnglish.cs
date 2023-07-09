using System;
using Business.Constants.Messages.Abstract;
using Entities.Concrete;

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
            FolderDeleted = "The folder has been deleted.";
            FolderCouldNotBeCreated = "The folder could not be created.";

            //StudySet
            StudySetsListed = "Study sets were listed.";
            StudySetAlreadyExists = "The study set name already exists.";
            StudySetAdded = "The study set has been successfully added.";
            StudySetUpdated = "The study set has been updated.";
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
        public string FolderDeleted { get; }
        public string FolderCouldNotBeCreated { get; }

        //StudySet
        public string StudySetsListed { get; }
        public string StudySetAlreadyExists { get; }
        public string StudySetAdded { get; }
        public string StudySetUpdated { get; }
    }
}

