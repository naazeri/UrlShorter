using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UrlShorter.Models;

public class Url
{
    public int Id { get; set; }
    [Required]
    public string OriginalUrl { get; set; }
    public string ShortUrl { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiryDate { get; set; }

    public virtual IdentityUser User { get; set; }
}
