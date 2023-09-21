using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewwebApp.Models;

namespace NewwebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class UsersController : ControllerBase
    {
        UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            
                return NotFound();
              

           var result= await _userManager.DeleteAsync(user);

            if(!result.Succeeded)
            
                throw new Exception();
            

            return Ok();
        }
    }
}
