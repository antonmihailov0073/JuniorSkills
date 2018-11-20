using JuniorSkillsFastChallenge.Services.Exceptions;
using System;

namespace JuniorSkillsFastChallenge.Helpers
{
    public static class ValidationHelper
    {
        private const string DefaultErrorMessage = "Validation error!";


        public static void Validate<TObject>(TObject obj, Func<TObject, bool> validator, string errorMessage = DefaultErrorMessage)
        {
            if (!validator(obj)) throw new ServiceExecption(errorMessage);
        }
    }
}
