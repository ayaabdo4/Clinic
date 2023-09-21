using Microsoft.EntityFrameworkCore;

namespace NewwebApp.ViewModel
{
    [Keyless]
    public class RoleViewmodel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }

    }
}