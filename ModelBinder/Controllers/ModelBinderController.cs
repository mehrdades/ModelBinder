using Microsoft.AspNetCore.Mvc;
using ModelBinder.ModelBinders;
using ModelBinder.Models;

namespace ModelBinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelBinderController : ControllerBase
    {
        [HttpPost("bind")]
        //Using the model binder for a specific API, or use the model binder provider to use for all APIs
        public async Task<ActionResult> Bind([FromBody][ModelBinder(BinderType = typeof(CustomBinder))] BaseModel baseModel)
        {
            var modelType = baseModel.GetType().Name;

            return Ok(baseModel);
        }
    }
}
