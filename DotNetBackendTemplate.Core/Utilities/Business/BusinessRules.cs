using System;
using DotNetBackendTemplate.Core.Utilities.Results.Abstract;

namespace DotNetBackendTemplate.Core.Utilities.Business
{
	public class BusinessRules
	{
		public static IResult Run(params IResult[] logics)
		{
			foreach (var result in logics)
			{
				if (!result.Success)
				{
					return result;
				}
			}
			return null;
		} 
	}
}

