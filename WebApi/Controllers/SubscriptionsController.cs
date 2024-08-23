using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private static HashSet<string> _subscriptions = new HashSet<string>();

        [HttpPost]
        public IActionResult Subscribe([FromBody] SubscriptionRequestModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_subscriptions.Add(model.Email))
                {
                    return Conflict("Email is already subscribed.");
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Unsubscribe([FromBody] SubscriptionRequestModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_subscriptions.Remove(model.Email))
                {
                    return NotFound("Email not found.");
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
