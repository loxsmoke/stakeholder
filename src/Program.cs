using Stakeholder.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Stakeholder
{
    class Program
    {
        static void Main(string[] arguments)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            var args = Args.Parse(arguments);
            
            var config = new SessionConfig(
                args.DevType,
                args.Jargon,
                args.Complexity,
                args.Alerts,
                args.Project,
                args.Minimal,
                args.Team,
                args.Framework
            );

            var running = true;

            // TODO: Ctrl-C handler sets running to false

            Console.Clear();

            // Display an initial "system boot" to set the mood
            Display.DisplayBootSequence(config);

            // let start_time = Instant::now();
            var clock = Stopwatch.StartNew();

            while (running)
            {
                if (args.Duration > 0 && clock.Elapsed.TotalSeconds >= args.Duration)
                {
                    break;
                }

                // Based on complexity, determine how many activities to show simultaneously
                int activitiesCount = config.Complexity switch
                {
                    Complexity.Low => 1,
                    Complexity.Medium => 2,
                    Complexity.High => 3,
                    Complexity.Extreme => 4,
                    _ => 1,
                };

                // Randomly select and run activities
                List<Action<SessionConfig>> activities = [
                    Activities.RunCodeAnalysis,
                    Activities.RunPerformanceMetrics,
                    Activities.RunSystemMonitoring,
                    Activities.RunDataProcessing,
                    Activities.RunNetworkActivity,
                ];
                // Shuffle the activities to randomize the order
                activities.Shuffle();

                foreach (var activity in activities.Take(activitiesCount))
                {
                    activity(config);

                    // Random short pause between activities
                    Rng.RandomSleep(100..500);
                    
                    // Check if we should exit
                    if (!running || (args.Duration > 0 && clock.Elapsed.TotalSeconds >= args.Duration))
                    {
                        break;
                    }
                }

                if (config.AlertsEnabled && Rng.RandomTrue(0.1))
                {
                    Display.DisplayRandomAlert(config);
                }

                if (config.TeamActivity && Rng.RandomTrue(0.2))
                {
                    Display.DisplayTeamActivity(config);
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Session terminated.");
        }
    }
}