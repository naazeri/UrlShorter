using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrlShorter.Data;
using UrlShorter.Services;

namespace UrlShorter.Controllers;

[Authorize]
public class HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, UrlShortenedService urlShortenedService) : Controller
{
    private readonly ApplicationDbContext _context = context;
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly UrlShortenedService _urlShortenedService = urlShortenedService;

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return NotFound();
        }

        var URLs = await _urlShortenedService.GetUserURLsAsync(userId);
        return View(URLs);
    }

    // Define the route directly at the root level for short URLs
    [Route("{shortUrl}")]
    [AllowAnonymous] // Allow access without being logged in
    public async Task<IActionResult> RedirectToOriginal(string shortUrl)
    {
        var originalUrl = await _urlShortenedService.GetOriginalUrlAsync(shortUrl);

        if (originalUrl == null)
        {
            return NotFound();
        }

        return Redirect(originalUrl);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string OriginalUrl)
    {
        if (ModelState.IsValid)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return NotFound();
            }

            var shortUrl = await _urlShortenedService.ShortenUrlAsync(OriginalUrl, userId);
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

}
