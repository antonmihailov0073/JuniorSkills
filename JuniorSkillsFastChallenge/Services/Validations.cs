using JuniorSkillsFastChallenge.Helpers;
using System.Linq;
using System.Text.RegularExpressions;

namespace JuniorSkillsFastChallenge.Services
{
    public static class Validations
    {
        private const int MinEmailLength = 10;
        private const int MinPasswordLength = 6;
        private const int MaxPasswordLength = 30;
        private const string EmailPattern = "[a-zA-Z0-9]+@[a-zA-Z]+\\.[a-zA-Z]+";
        
        private static readonly char[] _passwordMustContain = new[] { '!', '@', '#', '$', '%', '^' };


        public static void ValidateEmail(string email)
        {
            ValidationHelper.Validate(
                email,
                e => e.Length >= MinEmailLength,
                $"Email length must be at least {MinEmailLength} chars!");

            ValidationHelper.Validate(
                email, 
                e => Regex.IsMatch(e, EmailPattern),
                $"Incorrect email!");
        }

        public static void ValidatePassword(string password)
        {
            ValidationHelper.Validate(
                password,
                p => p.Length >= MinPasswordLength,
                $"Password length must be at least {MinPasswordLength} chars!");

            ValidationHelper.Validate(
                password, 
                p => p.Length <= MaxPasswordLength, 
                $"Password length must be less or equals to {MaxPasswordLength} chars!");

            ValidationHelper.Validate(
                password,
                p => p.Any(c => _passwordMustContain.Contains(c)), 
                $"Password must contain \"!@#$%^\" symbols!");

            ValidationHelper.Validate(
                password, 
                p => Regex.IsMatch(p, ".*[a-z]+.*"),
                $"Incorrect password!");

            ValidationHelper.Validate(
                password, 
                p => Regex.IsMatch(p, ".*[A-Z]+.*"),
                $"Incorrect password!");

            ValidationHelper.Validate(
                password,
                p => Regex.IsMatch(p, ".*[0-9]+.*"), 
                $"Incorrect password!");
        }
    }
}
