using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBinder.Models;
using Newtonsoft.Json;

namespace ModelBinder.ModelBinders
{
    public class CustomBinder : IModelBinder
    {
        public CustomBinder()
        {

        }
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var jsonContent = await GetJsonContent(bindingContext.ActionContext);
            var jObject = Newtonsoft.Json.Linq.JObject.Parse(jsonContent);

            var type = Convert.ToInt16(jObject.SelectToken("type").ToString());

            //var specificJsonContent = jObject.SelectToken("JsonKey").ToString();
            //jObject.Remove("JsonKey");

            var settings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            BaseModel? model = null;

            switch (type)
            {
                case 1:
                    model = JsonConvert.DeserializeObject<ChildModel>(jObject.ToString(), settings);
                    break;
                case 2:
                    model = JsonConvert.DeserializeObject<ChildModel2>(jObject.ToString(), settings);
                    break;
                default:
                    break;
            }

            if (model is not null)
            {
                bindingContext.Result = ModelBindingResult.Success(model);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
        }

        private async static Task<string> GetJsonContent(ActionContext actionContext)
        {
            var content = actionContext.HttpContext.Request.Body;
            return await new StreamReader(content).ReadToEndAsync();
        }
    }
}
