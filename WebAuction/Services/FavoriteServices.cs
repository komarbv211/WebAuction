using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAuction.Extensions;

namespace WebAuction.Services
{
    internal class FavoriteServices
    {
        private readonly HttpContext httpContext;
        public FavoriteServices(IHttpContextAccessor contextAccessor)
        {
            httpContext = contextAccessor.HttpContext!;
        }

        public int GetCount()
        {
            var ids = httpContext.Session.Get<List<int>>("favorite_items");

            if (ids == null) return 0;

            return ids.Distinct().Count();
        }
    }
}
