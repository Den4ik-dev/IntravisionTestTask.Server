using Api.Common;
using Api.Common.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/admins")]
public class AdminsController : ApiController
{
    [CustomAuthorize]
    [HttpGet("isAdmin")]
    public bool IsAdmin() => true;
}
