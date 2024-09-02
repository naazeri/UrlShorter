using Microsoft.EntityFrameworkCore;
using UrlShorter.Data;
using UrlShorter.Models;

namespace UrlShorter.Services;

public class UrlShortenedService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;
    private readonly string _baseUrl = "https://yourdomain.com/";

    public async Task<string> ShortenUrlAsync(string originalUrl, string userId)
    {
        // Check if the URL has already been shortened
        var existingUrl = await _context.Urls.FirstOrDefaultAsync(u => u.OriginalUrl == originalUrl);
        if (existingUrl != null)
        {
            return _baseUrl + existingUrl.ShortUrl;
        }

        // Generate a unique short URL
        var shortUrl = GenerateShortUrl();

        // Save the mapping to the database
        var shortenedUrl = new Url
        {
            OriginalUrl = originalUrl,
            ShortUrl = shortUrl,
            UserId = userId,
            CreatedAt = DateTime.Now,
        };

        await _context.Urls.AddAsync(shortenedUrl);
        await _context.SaveChangesAsync();

        return _baseUrl + shortUrl;
    }

    public async Task<string?> GetOriginalUrlAsync(string shortUrl)
    {
        var shortenedUrl = await _context.Urls.FirstOrDefaultAsync(u => u.ShortUrl == shortUrl);
        return shortenedUrl?.OriginalUrl;
    }

    public async Task<List<Url>> GetUserURLsAsync(string userId)
    {
        var userURLs = await _context.Urls.Where(u => u.UserId == userId).ToListAsync();
        return userURLs;
    }

    private static string GenerateShortUrl()
    {
        // Simple method to generate a short string, customize as needed
        var guid = Guid.NewGuid().ToString("N")[..6];
        return guid;
    }
}
