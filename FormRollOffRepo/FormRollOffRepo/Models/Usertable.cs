using System;
using System.Collections.Generic;

#nullable disable

namespace FormRollOffRepo.Models
{
    public partial class Usertable
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Roll { get; set; }
    }
}
