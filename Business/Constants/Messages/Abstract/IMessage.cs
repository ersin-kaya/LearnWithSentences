using System;
namespace Business.Constants.Messages.Abstract
{
	public interface IMessage
	{
        string LanguagesListed { get; }
        string LanguageAlreadyExists { get; }
        string LanguageAdded { get; }
        string LanguageDeleted { get; }
        string LanguageUpdated { get; }
    }
}

