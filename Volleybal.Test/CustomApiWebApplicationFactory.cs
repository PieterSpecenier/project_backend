using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
 

namespace Volleybal.Test
{
    public class CustomApiWebApplicationFactory : WebApplicationFactory<Volleybal.API.Services>
    {
    }
}
