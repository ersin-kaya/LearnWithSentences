using System;
namespace Business.Constants.Messages.Abstract
{
	public interface IMessageService
	{
        string LanguageAlreadyExists { get; }
        string LanguageAdded { get; }
    }
}

