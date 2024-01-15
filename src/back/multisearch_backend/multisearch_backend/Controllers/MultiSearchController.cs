using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using multisearch_backend.DTO;
using multisearch_backend.Services;

namespace multisearch_backend.Controllers
{
    [ApiController]
    [Route("MultiSearch")]
    public class MultiSearchController : ControllerBase
    {
        [HttpPost(Name = "PostMultiSearch")]
        [EnableCors("AllowSpecificOrigin")]
        public MultiSearchDTO? Post(String? search)
        {
            return DataAcessService.GetAll(search);
        }
    }
}
