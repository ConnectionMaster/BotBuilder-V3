﻿using Microsoft.Bot.Connector.SkillAuthentication;
using System.Configuration;
using System.Linq;

namespace EchoBot.Authentication
{
    public class CustomSkillAuthenticationConfiguration : AuthenticationConfiguration
    {
        private const string AllowedCallersConfigKey = "AllowedCallers";
        public CustomSkillAuthenticationConfiguration()
        {
            var allowedCallers = ConfigurationManager.AppSettings[AllowedCallersConfigKey].Split(',').Select(s=>s.Trim()).ToList();
            ClaimsValidator = new CustomAllowedCallersClaimsValidator(allowedCallers);
        }
        
        public override ClaimsValidator ClaimsValidator { get => base.ClaimsValidator; set => base.ClaimsValidator = value; }
    }
}