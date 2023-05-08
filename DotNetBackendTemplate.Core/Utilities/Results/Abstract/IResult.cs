﻿using System;
namespace DotNetBackendTemplate.Core.Utilities.Results.Abstract
{
	public interface IResult
	{
		bool Success { get; }
		string Message { get; }
	}
}

