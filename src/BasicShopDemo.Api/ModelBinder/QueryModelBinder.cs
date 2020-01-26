using BasicShopDemo.Api.Core.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BasicShopDemo.Api.Core.ModelBinder
{
    public class QueryModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == null)
            {
                bindingContext.Model = null;
                return Task.CompletedTask;
            }

            NameValueCollection result = HttpUtility.ParseQueryString(bindingContext.HttpContext.Request.QueryString.Value);

            var query = new Query();

            foreach (string key in result.AllKeys.Select(s => s.Trim().ToLower()))
            {
                switch (key)
                {
                    case "$skip":
                        query.Skip = Convert.ToUInt32(result.Get(key));
                        break;
                    case "$top":
                        query.Take = Convert.ToUInt32(result.Get(key));
                        break;
                    case "$filter":
                        query.Filter = result.Get(key);
                        break;
                }
            }

            bindingContext.Result = ModelBindingResult.Success(query);

            return Task.CompletedTask;
        }
    }
}
