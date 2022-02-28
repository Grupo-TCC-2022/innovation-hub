using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /*Controller base de todos os controllers, ele diz que todos os controllers tem como raiz
    a rota /api/(nome do controller)*/
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}