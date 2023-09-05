using Covid19ProjectAPI.Entities;
using Covid19ProjectAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid19ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost,Route("SendEmail")]
        public IActionResult SendEmail(EmailSendDTO emailDTO)
        {
            _emailSender.SendEmail(emailDTO);
            return StatusCode(200,new JsonResult("Registration Successfull"));
        }
        
    }
}
