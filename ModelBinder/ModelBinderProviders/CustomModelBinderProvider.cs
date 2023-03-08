using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBinder.ModelBinders;
using ModelBinder.Models;

namespace ModelBinder.ModelBinderProviders
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(BaseModel))
                return new CustomBinder();

            return null;
        }
    }
}
