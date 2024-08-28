using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAuction.Models
{
    public class MessageViewModel
    {
        public bool SendToAll { get; set; }
        public string SelectedUserId { get; set; }
        public List<SelectListItem> Users { get; set; } = new List<SelectListItem>();
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
