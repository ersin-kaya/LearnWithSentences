using System;
namespace DotNetBackendTemplate.Core.Utilities.Results.Abstract
{
	public interface IDataResult<T> : IResult
	{
		T Data { get; }
	}
}

