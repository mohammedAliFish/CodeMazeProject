


using System.Text.Json;
using CompanyEmployees.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController] 
    public class AuthenticationController : ControllerBase
    { 
        private readonly IServiceManager _service; 
        public AuthenticationController(IServiceManager service) => _service = service;
    }
}
