using System.Reflection;
using DbUp;
using DbUp.Engine.Output;
using Microsoft.Extensions.Configuration;

namespace Agentic.Deployment;

public class Deployment(IConfiguration configuration, IUpgradeLog upgradeLog)
{
    public void DeployInfrastructure()
    {
        UpgradeDatabase(configuration, upgradeLog);
    }

    private static void UpgradeDatabase(IConfiguration configuration, IUpgradeLog upgradeLog)
    {
        var connectionString = configuration.GetConnectionString("Database");

        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var result =
            DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogTo(upgradeLog)
                .Build()
                .PerformUpgrade();

        if (!result.Successful) Environment.Exit(-1);
    }
}
