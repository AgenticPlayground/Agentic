using DbUp.Engine.Output;
using Microsoft.Extensions.Logging;

namespace Agentic.Deployment;

#pragma warning disable CA2254
public class LoggerAdapter(ILogger<LoggerAdapter> logger)
    : IUpgradeLog
{
    public void LogTrace(string format, params object[] args) => logger.LogTrace(format, args);
    public void LogDebug(string format, params object[] args)=> logger.LogDebug(format, args);
    public void LogInformation(string format, params object[] args) => logger.LogInformation(format, args);
    public void LogWarning(string format, params object[] args)=> logger.LogWarning(format, args);
    public void LogError(string format, params object[] args)=> logger.LogError(format, args);
    public void LogError(Exception ex, string format, params object[] args)=> logger.LogError(ex, format, args);
}
#pragma warning restore CA2254
