using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookstoreManagementAPI.Data;
using OnlineBookstoreManagementAPI.Models;

namespace OnlineBookstoreManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly BookstoreDbContext _context;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(BookstoreDbContext context, ILogger<AuthorsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Get all authors
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            try
            {
                var authors = await _context.Authors
                    .Where(a => a.IsActive)
                    .ToListAsync();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving authors");
                return StatusCode(500, "An error occurred while retrieving authors");
            }
        }

        /// <summary>
        /// Get author by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            try
            {
                var author = await _context.Authors
                    .FirstOrDefaultAsync(a => a.Id == id && a.IsActive);

                if (author == null)
                {
                    return NotFound();
                }

                return Ok(author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving author with ID {AuthorId}", id);
                return StatusCode(500, "An error occurred while retrieving the author");
            }
        }

        /// <summary>
        /// Create a new author (Admin/Store Owner only)
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<ActionResult<Author>> CreateAuthor(Author author)
        {
            try
            {
                author.CreatedAt = DateTime.UtcNow;
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating author");
                return StatusCode(500, "An error occurred while creating the author");
            }
        }

        /// <summary>
        /// Update an author (Admin/Store Owner only)
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<IActionResult> UpdateAuthor(int id, Author author)
        {
            try
            {
                if (id != author.Id)
                {
                    return BadRequest();
                }

                var existingAuthor = await _context.Authors.FindAsync(id);
                if (existingAuthor == null)
                {
                    return NotFound();
                }

                existingAuthor.FirstName = author.FirstName;
                existingAuthor.LastName = author.LastName;
                existingAuthor.Biography = author.Biography;
                existingAuthor.ImageUrl = author.ImageUrl;
                existingAuthor.Nationality = author.Nationality;
                existingAuthor.DateOfBirth = author.DateOfBirth;
                existingAuthor.DateOfDeath = author.DateOfDeath;
                existingAuthor.IsActive = author.IsActive;
                existingAuthor.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating author with ID {AuthorId}", id);
                return StatusCode(500, "An error occurred while updating the author");
            }
        }

        /// <summary>
        /// Delete an author (Admin/Store Owner only)
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    return NotFound();
                }

                author.IsActive = false;
                author.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting author with ID {AuthorId}", id);
                return StatusCode(500, "An error occurred while deleting the author");
            }
        }
    }
}
