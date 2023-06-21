using System;
namespace Business.Constants.Messages.Abstract
{
	public interface IMessage
	{
        string LanguageAlreadyExists { get; }
        string LanguageAdded { get; }
    }
}

