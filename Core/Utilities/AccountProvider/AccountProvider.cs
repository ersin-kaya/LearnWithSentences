using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.AccountProvider
{
	public class AccountProvider : IAccountProvider
	{
        private readonly IHttpContextAccessor _httpContextAccessor;

		public AccountProvider(IHttpContextAccessor httpContextAccessor)
		{
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
		}

        public string GetAccountId()
        {
            try
            {
                return _httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

