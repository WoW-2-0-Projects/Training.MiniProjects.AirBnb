using AirBnb.Application.RequestContexts.Brokers;
using AirBnb.Application.RequestContexts.Constants;
using AirBnb.Application.RequestContexts.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AirBnb.Infrastructure.RequestContexts.Brokers;

/// <summary>
/// Provides request context broker functionalities
/// </summary>
public class RequestContextProvider(IHttpContextAccessor httpContextAccessor) : IRequestContextProvider
{
    public RequestContext GetRequestContext()
    {
        var httpContext = httpContextAccessor.HttpContext!;
        var userInfoCookie = httpContext.Request.Cookies.TryGetValue(CookieConstants.UserInfoCookieKey, out var userInfoCookieValue)
            ? JsonConvert.DeserializeObject<UserInfo>(userInfoCookieValue!)
            : default;

        var requestContext = new RequestContext
        {
            UserInfo = userInfoCookie
        };

        return requestContext;
    }
}