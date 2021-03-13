using ProjectApp.Models;
using System.Collections.Generic;

namespace ProjectApp.Services
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
