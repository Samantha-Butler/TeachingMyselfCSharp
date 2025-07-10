using Microsoft.AspNetCore.Identity;

namespace JobTrackr.Api.Models
{
    public class User : IdentityUser
    {
        public ICollection<Application>? Applications { get; set; }
    }
}
