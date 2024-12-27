using Microsoft.AspNetCore.Authorization;
<<<<<<< HEAD
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bazingo_API.Controllers
{
    /// <summary>
    /// Controller for managing roles in the system. Requires Admin access.
    /// </summary>
    //[Authorize(Roles = "Admin")]
=======
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Authorize(Roles = "Admin")]
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

<<<<<<< HEAD
        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns>List of roles</returns>
=======
        // Get all roles
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
        [HttpGet]
        public IActionResult GetRoles( )
        {
            var roles = _roleManager.Roles;
            return Ok(roles);
        }

<<<<<<< HEAD
        /// <summary>
        /// Create a new role.
        /// </summary>
        /// <param name="roleName">The name of the new role</param>
        /// <returns>Result of the creation</returns>
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest(new { message = "Role name is required." });

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
                return Conflict(new { message = $"Role '{roleName}' already exists." });

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
                return Ok(new { message = $"Role '{roleName}' created successfully." });

            return BadRequest(new { errors = result.Errors });
        }

        /// <summary>
        /// Delete an existing role.
        /// </summary>
        /// <param name="roleName">The name of the role to delete</param>
        /// <returns>Result of the deletion</returns>
=======
        // Create a new role
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return BadRequest("Role name is required");

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists) return BadRequest("Role already exists");

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded) return Ok($"Role '{roleName}' created successfully");

            return BadRequest(result.Errors);
        }

        // Delete a role
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
<<<<<<< HEAD
            if (role == null)
                return NotFound(new { message = $"Role '{roleName}' not found." });

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return Ok(new { message = $"Role '{roleName}' deleted successfully." });

            return BadRequest(new { errors = result.Errors });
=======
            if (role == null) return NotFound("Role not found");

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded) return Ok($"Role '{roleName}' deleted successfully");

            return BadRequest(result.Errors);
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
        }
    }
}
