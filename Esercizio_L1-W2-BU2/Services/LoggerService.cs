﻿using Serilog;

namespace Esercizio_L1_W2_BU2.Services
{
    public class LoggerService
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("Logs/log_.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void LogInformation(string message)
        {
            Log.Information(message);
        }

        public void LogError(string message)
        {
            Log.Error(message);
        }

        public void LogWarning(string message)
        {
            Log.Warning(message);
        }
    }
}
