using System;

namespace JuniorSkillsFastChallenge.Services.Exceptions
{
    public class ServiceExecption : Exception
    {
        public ServiceExecption(string message) : base(message)
        {
        }
    }
}
