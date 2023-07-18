using System;
namespace Business.Constants.Messages.Abstract
{
	public interface IMessage
    {
        //Parse Errors
        string ParseErrorForAccountId { get; }

        //Language
        string LanguagesListed { get; }
        string LanguageAlreadyExists { get; }
        string LanguageAdded { get; }
        string LanguageUpdated { get; }
        string LanguageDeleted { get; }

        //Folder
        string FoldersListed { get; }
        string FolderAlreadyExists { get; }
        string FolderAdded { get; }
        string FolderUpdated { get; }
        string FolderDeleted { get; }

        //StudySet
        string StudySetsListed { get; }
        string StudySetAlreadyExists { get; }
        string StudySetAdded { get; }
        string StudySetUpdated { get; }
        string StudySetDeleted { get; }

        //Term
        string TermAdded { get; }
        string TermUpdated { get; }
        string TermDeleted { get; }

        //Definition
        string DefinitionAdded { get; }
        string DefinitionUpdated { get; }
        string DefinitionDeleted { get; }
    }
}

