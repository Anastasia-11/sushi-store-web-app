using System.Collections.Generic;
using CourseProject.Models;
using Microsoft.AspNetCore.Identity;

namespace CourseProject.ViewModels
{
    public class EditRoleViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}