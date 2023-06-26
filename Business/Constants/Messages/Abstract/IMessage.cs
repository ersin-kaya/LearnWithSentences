﻿using System;
namespace Business.Constants.Messages.Abstract
{
	public interface IMessage
	{
        //Language
        string LanguagesListed { get; }
        string LanguageAlreadyExists { get; }
        string LanguageAdded { get; }
        string LanguageDeleted { get; }
        string LanguageUpdated { get; }

        //Folder
        string FoldersListed { get; }
        string FolderAlreadyExists { get; }
        string FolderAdded { get; }
    }
}

