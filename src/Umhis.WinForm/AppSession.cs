using System;
using Umhis.Core;

namespace Umhis
{
    internal static class AppSession
    {
        private static int _logInAttemptCount;
        private static DateTime _logInAttemptExceedTime;
        public static UserAccount CurrentUser  ;

        public static bool CreateNewSession(string username, string password, out string errorMessage)
        {
            errorMessage = "";

            if (CurrentUser != null)
            {
                errorMessage = "Has existing Session.";
                return false;
            }

            if (HasExceededLogInAttempt(ref errorMessage)) return false;

            var user = new UserAccount();
            if (!user.LoadItem(username))
            {
                errorMessage = "Invalid Credentials";
                return false;
            }

            if (!user.Active)
            {
                errorMessage = "Account is Disabled";
                return false;
            }

            if (!PasswordSecurity.VerifyPassword(password, user.Password))
            {
                errorMessage = "Invalid Credentials";
                return false;
            }

            CurrentUser = user;
            return true;
        }

        private static bool HasExceededLogInAttempt(ref string errorMessage)
        {
            _logInAttemptCount++;
            if (_logInAttemptCount < 5)
            {
                _logInAttemptExceedTime = DateTime.Now;
                return false;
            }

            if (DateTime.Now.Subtract(_logInAttemptExceedTime) >= new TimeSpan(0, 1, 0))
            {
                _logInAttemptCount = 0;
                return false;
            }

            errorMessage = "You have exceeded the maximum number of login attempts!. Try again after 1 minute";
            return true;
        }
    }
}
