using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class CredentialAuthenticateDto
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
    }
}
