using HyperSpeed.Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Desktop.Helpers
{
    public sealed class SessionManager
    {
        private static readonly Lazy<SessionManager> _instance =
            new(() => new SessionManager());

        public static SessionManager Instance => _instance.Value;
        private SessionManager() { }

        public UserResponseDto? CurrentUser { get; private set; }
        public bool IsAuthenticated => CurrentUser != null;
        public bool IsAdmin => CurrentUser?.IsAdmin ?? false;


        public void SetUser(UserResponseDto user)
        {
            CurrentUser = user;
        }

        public void Clear()
        {
            CurrentUser = null;
        }

        public string GetEmail() => CurrentUser?.Email ?? string.Empty;

        public string GetDisplayName()
        {
            var email = GetEmail();
            if (string.IsNullOrEmpty(email)) return "Usuário";

            var at = email.IndexOf('@');
            return at > 0 ? email[..at] : email;
        }
    }
}
