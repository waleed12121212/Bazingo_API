﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bazingo_API.Controllers
{
    /// <summary>
    /// Controller for managing roles in the system. Requires Admin access.
    /// </summary>
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns>List of roles</returns>
        [HttpGet]
        public IActionResult GetRoles( )
        {
            var roles = _roleManager.Roles;
            return Ok(roles);
        }

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
        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
                return NotFound(new { message = $"Role '{roleName}' not found." });

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return Ok(new { message = $"Role '{roleName}' deleted successfully." });

            return BadRequest(new { errors = result.Errors });
        }
    }
}
