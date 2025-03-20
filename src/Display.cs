using Stakeholder.Enums;
using Stakeholder.Utils;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Stakeholder;

public class Display
{
    public static void DisplayBootSequence(SessionConfig config) 
    {
        var pb = new ProgressBar(100, "{spinner:.green} [{elapsed_precise}] [{bar:40.cyan/blue}] {pos}/{len} ({eta})");

        Concole.WriteLine();
        Concole.WriteLine(ConsoleColor.Cyan, "INITIALIZING DEVELOPMENT ENVIRONMENT");
        Concole.WriteLine(config.MinimalOutput, ConsoleColor.Yellow, $"Project: {config.ProjectName.ToUpper()}");
        Concole.WriteLine(config.MinimalOutput, ConsoleColor.Green, $"Environment: {config.DevType} Development");

        if (!string.IsNullOrEmpty(config.Framework))
        {
            Concole.WriteLine(config.MinimalOutput, ConsoleColor.Blue, $"Framework: {config.Framework}");
        }
        Concole.WriteLine();

        for (var i = 0; i < 100; i++)
        {
            pb.SetPosition(i);

            if (i % 20 == 0)
            {
                var message = i switch {
                    0 => "Loading configuration files...",
                    20 => "Establishing secure connections...",
                    40 => "Initializing development modules...",
                    60 => "Syncing with repository...",
                    80 => "Analyzing code dependencies...",
                    100 => "Environment ready!",
                    _ => "",
                };

                if (!string.IsNullOrEmpty(message))
                {
                    pb.WriteLine($"  {message}");
                }
            }
            Rng.RandomSleep(50..100);
        }

        pb.FinishAndClear();
        Concole.WriteLine();
        Concole.WriteLine(ConsoleColor.Green, "✅ DEVELOPMENT ENVIRONMENT INITIALIZED");
        Concole.WriteLine();
        Thread.Sleep(500);
    }

    public static void DisplayRandomAlert(SessionConfig config) 
    {
        List<string> alertTypes = [
            "SECURITY",
            "PERFORMANCE",
            "RESOURCE",
            "DEPLOYMENT",
            "COMPLIANCE",
        ];

        var alertType = alertTypes.RandomElement();
        var severity = Rng.RandomTrue(0.25) ? "CRITICAL" : (Rng.RandomTrue(0.33) ? "HIGH" : "MEDIUM");

        var alertMessage = alertType switch 
        {
            "SECURITY" => config.DevType switch 
            {
                DevelopmentType.Security => "Potential intrusion attempt detected on production server",
                DevelopmentType.Backend => "API authentication token expiration approaching",
                DevelopmentType.Frontend => "Cross-site scripting vulnerability detected in form input",
                DevelopmentType.Blockchain => "Smart contract privilege escalation vulnerability detected",
                _ => "Unusual login pattern detected in production environment",
            },
            "PERFORMANCE" => config.DevType switch
            {
                DevelopmentType.Backend => "API response time degradation detected in payment endpoint",
                DevelopmentType.Frontend => "Rendering performance issue detected in main dashboard",
                DevelopmentType.DataScience => "Data processing pipeline throughput reduced by 25%",
                DevelopmentType.MachineLearning => "Model inference latency exceeding threshold",
                _ => "Performance regression detected in latest deployment",
            },
            "RESOURCE" => config.DevType switch 
            {
                DevelopmentType.DevOps => "Kubernetes cluster resource allocation approaching limit",
                DevelopmentType.Backend => "Database connection pool nearing capacity",
                DevelopmentType.DataScience => "Data processing job memory usage exceeding allocation",
                _ => "System resource utilization approaching threshold",
            },
            "DEPLOYMENT" => config.DevType switch
            {
                DevelopmentType.DevOps => "Canary deployment showing increased error rate",
                DevelopmentType.Backend => "Service deployment incomplete on 3 nodes",
                DevelopmentType.Frontend => "Asset optimization failed in production build",
                _ => "CI/CD pipeline failure detected in release branch",
            },
            "COMPLIANCE" => config.DevType switch
            {
                DevelopmentType.Security => "Potential data handling policy violation detected",
                DevelopmentType.Backend => "API endpoint missing required audit logging",
                DevelopmentType.Blockchain => "Smart contract failing regulatory compliance check",
                _ => "Code scan detected potential compliance issue",
            },
            _ => "System alert condition detected",
        };

        var severityColor = severity switch {
            "CRITICAL" => ConsoleColor.Red,
            "HIGH" => ConsoleColor.Yellow,
            "MEDIUM" => ConsoleColor.Cyan,
            _ => ConsoleColor.White,
        };

        var alertDisplay = $"🚨 {alertType} ALERT [{severity}]: {alertMessage}";

        Concole.WriteLine(config.MinimalOutput, severityColor, alertDisplay);

        // Show automated response action
        var responseAction = alertType switch 
        {
            "SECURITY" => "Initiating security protocol and notifying security team",
            "PERFORMANCE" => "Analyzing performance metrics and scaling resources",
            "RESOURCE" => "Optimizing resource allocation and preparing scaling plan",
            "DEPLOYMENT" => "Running deployment recovery procedure and notifying DevOps",
            "COMPLIANCE" => "Documenting issue and preparing compliance report",
            _ => "Initiating standard recovery procedure",
        };

        Concole.WriteLine($"  ↳ AUTOMATED RESPONSE: {responseAction}");
        Concole.WriteLine();

        // Pause for dramatic effect
        Thread.Sleep(1000);
    }

    public static void DisplayTeamActivity(SessionConfig config) 
    {
        List<string> teamNames = [
            "Alice", "Bob", "Carlos", "Diana", "Eva", "Felix", "Grace", "Hector", "Irene", "Jack",
        ];
        var teamMember = teamNames.RandomElement();

        List<string> activities = config.DevType switch {
            DevelopmentType.Backend => [
                "pushed new API endpoint implementation",
                "requested code review on service layer refactoring",
                "merged database optimization pull request",
                "commented on your API authentication PR",
                "resolved 3 high-priority backend bugs",
            ],
            DevelopmentType.Frontend => [
                "updated UI component library",
                "pushed new responsive design implementation",
                "fixed cross-browser compatibility issue",
                "requested review on animation performance PR",
                "updated design system documentation",
            ],
            DevelopmentType.Fullstack => [
                "implemented end-to-end feature integration",
                "fixed client-server sync issue",
                "updated full-stack deployment pipeline",
                "refactored shared validation logic",
                "documented API integration patterns",
            ],
            DevelopmentType.DataScience => [
                "updated data transformation pipeline",
                "shared new analysis notebook",
                "optimized data aggregation queries",
                "updated visualization dashboard",
                "documented new data metrics",
            ],
            DevelopmentType.DevOps => [
                "updated Kubernetes configuration",
                "improved CI/CD pipeline performance",
                "added new monitoring alerts",
                "fixed auto-scaling configuration",
                "updated infrastructure documentation",
            ],
            DevelopmentType.Blockchain => [
                "optimized smart contract gas usage",
                "implemented new transaction validation",
                "updated consensus algorithm implementation",
                "fixed wallet integration issue",
                "documented token economics model",
            ],
            DevelopmentType.MachineLearning => [
                "shared improved model accuracy results",
                "optimized model training pipeline",
                "added new feature extraction method",
                "implemented model versioning system",
                "documented model evaluation metrics",
            ],
            DevelopmentType.SystemsProgramming => [
                "optimized memory allocation strategy",
                "reduced thread contention in core module",
                "implemented lock-free data structure",
                "fixed race condition in scheduler",
                "documented concurrency pattern usage",
            ],
            DevelopmentType.GameDevelopment => [
                "optimized rendering pipeline",
                "fixed physics collision detection issue",
                "implemented new particle effect system",
                "reduced loading time by 30%",
                "documented game engine architecture",
            ],
            DevelopmentType.Security => [
                "implemented additional encryption layer",
                "fixed authentication bypass vulnerability",
                "updated security scanning rules",
                "implemented improved access control",
                "documented security compliance requirements",
            ],
            _ => ["Recovering from unrecoverable error"]
        };

        var activity = activities.RandomElement();
        var minutesAgo = Rng.RandomRange(1..30);
        var notification = $"👥 TEAM: {teamMember} {activity} ({minutesAgo} minutes ago)";

        Concole.WriteLine(config.MinimalOutput, ConsoleColor.Cyan, notification);

        // Sometimes add a requested action
        if (Rng.RandomTrue(0.5))
        {
            List<string> actions = [
                "Review requested on PR #342",
                "Mentioned you in a comment",
                "Assigned ticket DEV-867 to you",
                "Requested your input on design decision",
                "Shared documentation for your review",
            ];

            var action = actions.RandomElement();
            Concole.WriteLine($"  ↳ ACTION NEEDED: {action}");
        }

        Concole.WriteLine();

        // Short pause to notice the team activity
        Thread.Sleep(800);
    }
}
