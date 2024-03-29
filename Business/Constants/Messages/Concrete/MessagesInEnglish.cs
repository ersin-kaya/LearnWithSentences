﻿using System;
using Business.Constants.Messages.Abstract;
using Entities.Concrete;

namespace Business.Constants.Messages.Concrete
{
    public class MessagesInEnglish : IMessage
    {
        public MessagesInEnglish()
        {
            //Parse Errors
            ParseErrorForAccountId = "There was a problem while we were accessing your account information.";

            //Language
            LanguagesListed = "Languages were listed.";
            LanguageAlreadyExists = "The language already exists.";
            LanguageAdded = "The language has been successfully added.";
            LanguageUpdated = "The language has been updated.";
            LanguageDeleted = "The language has been deleted.";

            //Folder
            FoldersListed = "Folders were listed.";
            FolderAlreadyExists = "The folder name already exists.";
            FolderAdded = "The folder has been successfully added.";
            FolderUpdated = "The folder has been updated.";
            FolderDeleted = "The folder has been deleted.";

            //StudySet
            StudySetsListed = "Study sets were listed.";
            StudySetAlreadyExists = "The study set name already exists.";
            StudySetAdded = "The study set has been successfully added.";
            StudySetUpdated = "The study set has been updated.";
            StudySetDeleted = "The study set has been deleted.";

            //Term
            TermAdded = "The term has been successfully added.";
            TermUpdated = "The term has been updated.";
            TermDeleted = "The term has been deleted.";

            //Definition
            DefinitionAdded = "The definition has been successfully added.";
            DefinitionUpdated = "The definition has been updated.";
            DefinitionDeleted = "The definition has been deleted.";
        }

        //Parse Errors
        public string ParseErrorForAccountId { get; }

        //Language
        public string LanguagesListed { get; }
        public string LanguageAlreadyExists { get; }
        public string LanguageAdded { get; }
        public string LanguageUpdated { get; }
        public string LanguageDeleted { get; }

        //Folder
        public string FoldersListed { get; }
        public string FolderAlreadyExists { get; }
        public string FolderAdded { get; }
        public string FolderUpdated { get; }
        public string FolderDeleted { get; }

        //StudySet
        public string StudySetsListed { get; }
        public string StudySetAlreadyExists { get; }
        public string StudySetAdded { get; }
        public string StudySetUpdated { get; }
        public string StudySetDeleted { get; }

        //Term
        public string TermAdded { get; }
        public string TermUpdated { get; }
        public string TermDeleted { get; }

        //Definition
        public string DefinitionAdded { get; }
        public string DefinitionUpdated { get; }
        public string DefinitionDeleted { get; }
    }
}

