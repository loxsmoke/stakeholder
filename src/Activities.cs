using Stakeholder.Generators;
using Stakeholder.Enums;
using Stakeholder.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stakeholder;

public class Activities
{
    public static void RunCodeAnalysis(SessionConfig config)
    {
        var filesToAnalyze = Rng.RandomRange(5, 25);
        var totalLines = Rng.RandomRange(1000, 10000);
        var frameworkSpecific = string.IsNullOrEmpty(config.Framework) ? "" : $" ({config.Framework} specific)";

        var title = config.DevType switch
        {
            DevelopmentType.Backend => $"🔍 Running Code Analysis on API Components{frameworkSpecific}",
            DevelopmentType.Frontend => $"🔍 Analyzing UI Components{frameworkSpecific}",
            DevelopmentType.Fullstack => "🔍 Analyzing Full-Stack Integration Points",
            DevelopmentType.DataScience => "🔍 Analyzing Data Pipeline Components",
            DevelopmentType.DevOps => "🔍 Analyzing Infrastructure Configuration",
            DevelopmentType.Blockchain => "🔍 Analyzing Smart Contract Security",
            DevelopmentType.MachineLearning => "🔍 Analyzing Model Prediction Accuracy",
            DevelopmentType.SystemsProgramming => "🔍 Analyzing Memory Safety Patterns",
            DevelopmentType.GameDevelopment => "🔍 Analyzing Game Physics Components",
            DevelopmentType.Security => "🔍 Running Security Vulnerability Scan",
            _ => "🔍 Running...",
        };

        Concole.WriteLine(config.MinimalOutput, ConsoleColor.Blue, title);

        var pb = new ProgressBar(filesToAnalyze, "{spinner:.green} [{elapsed_precise}] [{bar:40.cyan/blue}] {pos}/{len} files ({eta})");

        for (var i = 0; i < filesToAnalyze; i++)
        {
            pb.SetPosition(i);

            if (Rng.RandomTrue(0.33))
            { 
                var fileName = CodeAnalyzer.GenerateFilename(config.DevType);
                var issueType = CodeAnalyzer.GenerateCodeIssue(config.DevType);
                var complexity = CodeAnalyzer.GenerateComplexityMetric();

                var message = Rng.RandomTrue(0.25) ? $"  ⚠️ {fileName} - {issueType}: {complexity}" : $"  ✓ {fileName} - {complexity}";

                pb.WriteLine(message);
            }

            Rng.RandomSleep(100, 300);
        }

        pb.Finish();

        // Final analysis summary
        int issuesFound = Rng.RandomRange(0, 5);
        int codeQuality = Rng.RandomRange(85, 99);
        int techDebt = Rng.RandomRange(1, 15);

        Concole.WriteLine($"📊 Analysis Complete: {filesToAnalyze} files, {totalLines} lines of code");
        Concole.WriteLine($"  - Issues found: {issuesFound}");
        Concole.WriteLine($"  - Code quality score: {codeQuality}%");
        Concole.WriteLine($"  - Technical debt: {techDebt}%");

        if (config.JargonLevel >= JargonLevel.Medium)
        {
            Concole.WriteLine($"  - {Jargon.GenerateCodeJargon(config.DevType, config.JargonLevel)}");
        }

        Concole.WriteLine();
    }

    public static void RunPerformanceMetrics(SessionConfig config)
    {
        string title = config.DevType switch {
            DevelopmentType.Backend => "⚡ Analyzing API Response Time",
            DevelopmentType.Frontend => "⚡ Measuring UI Rendering Performance",
            DevelopmentType.Fullstack => "⚡ Evaluating End-to-End Performance",
            DevelopmentType.DataScience => "⚡ Benchmarking Data Processing Pipeline",
            DevelopmentType.DevOps => "⚡ Evaluating Infrastructure Scalability",
            DevelopmentType.Blockchain => "⚡ Measuring Transaction Throughput",
            DevelopmentType.MachineLearning => "⚡ Benchmarking Model Training Speed",
            DevelopmentType.SystemsProgramming => "⚡ Measuring Memory Allocation Efficiency",
            DevelopmentType.GameDevelopment => "⚡ Analyzing Frame Rate Optimization",
            DevelopmentType.Security => "⚡ Benchmarking Encryption Performance",
            _ => "⚡ Analyzing Performance Metrics"
        };

        Concole.WriteLine(config.MinimalOutput, ConsoleColor.Yellow, title);

        var iterations = Rng.RandomRange(50, 200);
        var pb = new ProgressBar(iterations, "{spinner:.yellow} [{elapsed_precise}] [{bar:40.yellow/blue}] {pos}/{len} samples ({eta})");

        List<double> performanceData = [];

        for (var i = 0; i < iterations; i++)
        {
            pb.SetPosition(i);

            // Generate realistic-looking performance numbers
            var basePerf = config.DevType switch 
            {
                DevelopmentType.Backend => Rng.RandomRange(20,80), // ms
                DevelopmentType.Frontend => Rng.RandomRange(5, 30), // ms
                DevelopmentType.DataScience => Rng.RandomRange(100, 500), // ms
                DevelopmentType.Blockchain => Rng.RandomRange(200, 800), // ms
                DevelopmentType.MachineLearning => Rng.RandomRange(300, 900), // ms
                _ => Rng.RandomRange(10, 100),                       // ms
            };

            // Add some variation but keep it somewhat consistent
            var jitter = Rng.RandomRange(-5, 5);
            var perfValue = Math.Max(basePerf + jitter, 1.0);
            performanceData.Add(perfValue);

            if (i % 10 == 0 && Rng.RandomTrue(0.33))
            {
                var metricName = Metrics.GeneratePerformanceMetric(config.DevType);
                var metricValue = Rng.RandomRange(10, 999);
                var metricUnit = Metrics.GenerateMetricUnit(config.DevType);

                pb.WriteLine($"  📊 {metricName}: {metricValue} {metricUnit}");
            }

            Rng.RandomSleep(50, 100);
        }

        pb.Finish();

        // Calculate and display metrics
        performanceData.Sort();
        var avg = performanceData.Average();
        var median = performanceData[performanceData.Count / 2];
        var p95 = performanceData[(int)(performanceData.Count * 0.95)];
        var p99 = performanceData[(int)(performanceData.Count * 0.99)];

        var unit = config.DevType switch {
            DevelopmentType.DataScience or DevelopmentType.MachineLearning => "seconds",
            _ => "milliseconds",
        };

        Concole.WriteLine("📈 Performance Results:");
        Concole.WriteLine($"  - Average: {Math.Round(avg,2)} {unit}");
        Concole.WriteLine($"  - Median: {Math.Round(median, 2)} {unit}");
        Concole.WriteLine($"  - P95: {Math.Round(p95, 2)} {unit}");
        Concole.WriteLine($"  - P99: {Math.Round(p99, 2)} {unit}");

        // Add optimization recommendations based on dev type
        var rec = Metrics.GenerateOptimizationRecommendation(config.DevType);
        Concole.WriteLine($"💡 Recommendation: {rec}");

        if (config.JargonLevel >= JargonLevel.Medium)
        {
            Concole.WriteLine($"  - {Jargon.GeneratePerformanceJargon(config.DevType, config.JargonLevel)}");
        }

        Concole.WriteLine();
    }

    public static void RunSystemMonitoring(SessionConfig config)
    {
        var title = "🖥️ System Resource Monitoring";
        Concole.WriteLine(config.MinimalOutput, ConsoleColor.Green, title);

        var duration = Rng.RandomRange(5, 15);
        var pb = new ProgressBar(duration, "{spinner:.green} [{elapsed_precise}] [{bar:40.green/blue}] {pos}/{len} seconds");

        var cpuBase = Rng.RandomRange(10,60);
        var memoryBase = Rng.RandomRange(30,70);
        var networkBase = Rng.RandomRange(1,20);
        var diskBase = Rng.RandomRange(5,40);

        for (var i = 0; i < duration; i++)
        {
            pb.SetPosition(i);

            // Generate slightly varied metrics for realistic fluctuation
            var cpu = cpuBase + Rng.RandomRange(-5, 10);
            var memory = memoryBase + Rng.RandomRange(-3, 5);
            var network = networkBase + Rng.RandomRange(-1, 3);
            var disk = diskBase + Rng.RandomRange(-2, 4);

            var processes = Rng.RandomRange(80, 200);

            var cpuStr = cpu > 60 ? $"{cpu}% (!)" : $"{cpu}%    ";
            var memStr = $"{memory}%";

            Concole.Write("  CPU: ");
            Concole.Write(config.MinimalOutput, cpu > 80 ? ConsoleColor.Red : (cpu > 60 ? ConsoleColor.Yellow : ConsoleColor.White), $"{cpuStr}");
            Concole.Write("  |  RAM: ");
            Concole.Write(config.MinimalOutput, memory > 85 ? ConsoleColor.Red : (memory > 70 ? ConsoleColor.Yellow : ConsoleColor.White), $"{memStr}");
            Concole.Write($"  |  Network: ");
            Concole.Write($"{network.ToString(" MB/s", 2)}");
            Concole.Write($"  |  Disk I/O: ");
            Concole.Write($"{disk.ToString(" MB/s", 2)}");
            Concole.Write($"  |  Processes: ");
            Concole.WriteLine($"{processes}");

            if (i % 3 == 0 && Rng.RandomTrue(0.33)) 
            {
                var systemEvent = SystemMonitoring.GenerateSystemEvent();
                pb.WriteLine($"  🔄 {systemEvent}");
            }

            Rng.RandomSleep(200..500);
        }

        pb.Finish();

        // Display summary
        Concole.WriteLine("📊 Resource Utilization Summary:");
        Concole.WriteLine($"  - Peak CPU: {cpuBase + Rng.RandomRange(5, 15)}%");
        Concole.WriteLine($"  - Peak Memory: {memoryBase + Rng.RandomRange(5, 15)}%");
        Concole.WriteLine($"  - Network Throughput: {networkBase + Rng.RandomRange(5, 10)} MB/s");
        Concole.WriteLine($"  - Disk Throughput: {diskBase + Rng.RandomRange(2, 8)} MB/s");
        Concole.WriteLine($"  - {SystemMonitoring.GenerateSystemRecommendation()}");
        Concole.WriteLine();
    }

    public static void RunDataProcessing(SessionConfig config)
    {
        var operations = Rng.RandomRange(5, 20);

        var title = config.DevType switch
        {
            DevelopmentType.Backend => "🔄 Processing API Data Streams",
            DevelopmentType.Frontend => "🔄 Processing User Interaction Data",
            DevelopmentType.Fullstack => "🔄 Synchronizing Client-Server Data",
            DevelopmentType.DataScience => "🔄 Running Data Transformation Pipeline",
            DevelopmentType.DevOps => "🔄 Analyzing System Logs",
            DevelopmentType.Blockchain => "🔄 Validating Transaction Blocks",
            DevelopmentType.MachineLearning => "🔄 Processing Training Data Batches",
            DevelopmentType.SystemsProgramming => "🔄 Optimizing Memory Access Patterns",
            DevelopmentType.GameDevelopment => "🔄 Processing Game Asset Pipeline",
            DevelopmentType.Security => "🔄 Analyzing Security Event Logs",
            _ => "Recovering from unrecoverable error"
        };

        Concole.WriteLine(config.MinimalOutput, ConsoleColor.Cyan, title);

        for (var i = 0; i < operations; i++)
        {
            var operation = DataProcessing.GenerateDataOperation(config.DevType);
            var records = Rng.RandomRange(100,10000);
            var size = Rng.RandomRange(1,100);
            var sizeUnit = Rng.RandomTrue(0.25) ? "GB" : "MB";

            Concole.WriteLine($"  🔄 {operation} {records} records ({size} {sizeUnit})");

            // Sometimes add sub-tasks with progress bars
            if (Rng.RandomTrue(0.33))
            {
                var subtasks = Rng.RandomRange(10, 30);
                var pb = new ProgressBar(subtasks, "     {spinner:.blue} [{elapsed_precise}] [{bar:30.cyan/blue}] {pos}/{len}");

                for (i = 0; i < subtasks; i++)
                {
                    pb.SetPosition(i);
                    Rng.RandomSleep(20, 100);

                    if (Rng.RandomTrue(0.125))
                    {
                        var subOperation = DataProcessing.GenerateDataSubOperation(config.DevType);
                        pb.WriteLine($"       - {subOperation}");
                    }
                }

                pb.FinishAndClear();
            }
            else
            {
                Rng.RandomSleep(300..800);
            }

            // Add some details about the operation
            if (Rng.RandomTrue(0.5))
            {
                var details = DataProcessing.GenerateDataDetails(config.DevType);
                Concole.WriteLine($"     ✓ {details}");
            }
        }

        // Add a summary
        var processedRecords = Rng.RandomRange(10000,1000000);
        var processingRate = Rng.RandomRange(1000,10000);
        var totalSize = Rng.RandomRange(10,500);
        var timeSaved = Rng.RandomRange(10,60);

        Concole.WriteLine("📊 Data Processing Summary:");
        Concole.WriteLine($"  - Records processed: {processedRecords}");
        Concole.WriteLine($"  - Processing rate: {processingRate} records/sec");
        Concole.WriteLine($"  - Total data size: {totalSize} GB");
        Concole.WriteLine($"  - Estimated time saved: {timeSaved} minutes");

        if (config.JargonLevel >= JargonLevel.Medium)
        {
            Concole.WriteLine($"  - {Jargon.GenerateDataJargon(config.DevType, config.JargonLevel)}");
        }
        Concole.WriteLine();
    }

    public static void RunNetworkActivity(SessionConfig config)
    {
        var title = config.DevType switch 
        {
            DevelopmentType.Backend => "🌐 Monitoring API Network Traffic",
            DevelopmentType.Frontend => "🌐 Analyzing Client-Side Network Requests",
            DevelopmentType.Fullstack => "🌐 Optimizing Client-Server Communication",
            DevelopmentType.DataScience => "🌐 Synchronizing Distributed Data Nodes",
            DevelopmentType.DevOps => "🌐 Monitoring Infrastructure Network",
            DevelopmentType.Blockchain => "🌐 Monitoring Blockchain Network",
            DevelopmentType.MachineLearning => "🌐 Distributing Model Training",
            DevelopmentType.SystemsProgramming => "🌐 Analyzing Network Protocol Efficiency",
            DevelopmentType.GameDevelopment => "🌐 Simulating Multiplayer Network Conditions",
            DevelopmentType.Security => "🌐 Analyzing Network Security Patterns",
            _ => "Recovering from unrecoverable error"
        };

        Concole.WriteLine(config.MinimalOutput, ConsoleColor.Magenta, title);

        var requests = Rng.RandomRange(5, 15);

        for (var i = 0; i < requests; i++)
        {
           var endpoint = NetworkActivity.GenerateEndpoint(config.DevType).PadRight(32);
           var method = NetworkActivity.GenerateMethod();
           var status = NetworkActivity.GenerateStatus();
           var size = Rng.RandomRange(1,1000);
           var time = Rng.RandomRange(10,500);

            var methodColor = method switch {
                "GET" => ConsoleColor.Green,
                "POST" => ConsoleColor.Blue,
                "PUT" => ConsoleColor.Yellow,
                "DELETE" => ConsoleColor.Red,
                _ => ConsoleColor.White,
            };
            method = method.PadRight(8);

            var statusColor = ConsoleColor.Red;
            if (200 <= status && status < 300) statusColor = ConsoleColor.Green;
            else if (300 <= status && status < 400) statusColor = ConsoleColor.Yellow;

            Concole.Write(config.MinimalOutput, methodColor, $"  {method}");
            Concole.Write($"  {endpoint}  → ");
            Concole.Write(config.MinimalOutput, statusColor, status.ToString());
            Concole.WriteLine($" | {time.ToString(" ms", 3)} | {size} KB");

            // Sometimes add request details
            if (Rng.RandomTrue(0.33))
            {
                var details = NetworkActivity.GenerateRequestDetails(config.DevType);
                Concole.WriteLine($"     ↳ {details}");
            }

            Rng.RandomSleep(100,400);
        }

        // Add summary
        var totalRequests = Rng.RandomRange(1000,10000);
        var avgResponse = Rng.RandomRange(50,200);
        var successRate = Rng.RandomRange(95,100);
        var bandwidth = Rng.RandomRange(10,100);

        Concole.WriteLine("📊 Network Activity Summary:");
        Concole.WriteLine($"  - Total requests: {totalRequests}");
        Concole.WriteLine($"  - Average response time: {avgResponse} ms");
        Concole.WriteLine($"  - Success rate: {successRate}%");
        Concole.WriteLine($"  - Bandwidth utilization: {bandwidth} MB/s");

        if (config.JargonLevel >= JargonLevel.Medium)
        {
            Concole.WriteLine($"  - {Jargon.GenerateNetworkJargon(config.DevType, config.JargonLevel)}");
        }

        Concole.WriteLine();
    }
}
