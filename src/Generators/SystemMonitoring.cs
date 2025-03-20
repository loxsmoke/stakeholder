using Stakeholder.Utils;
using System.Collections.Generic;

namespace Stakeholder.Generators;

public static class SystemMonitoring
{
    public static string GenerateSystemEvent()
    {
        List<string> events = [
            "New process started: backend-api-server (PID: 12358)",
            "Process terminated: worker-thread-pool-7 (PID: 8712)",
            "Memory threshold alert cleared (Usage: 68%)",
            "Connection established to database replica-3",
            "Network interface eth0: Link state changed to UP",
            "Garbage collection completed (Duration: 12ms, Freed: 124MB)",
            "CPU thermal throttling activated (Core temp: 82°C)",
            "Filesystem /data remounted read-write",
            "Docker container backend-api-1 restarted (Exit code: 137)",
            "HTTPS certificate for api.example.com renewed successfully",
            "Scheduled backup started (Target: primary-database)",
            "Swap space usage increased by 215MB (Current: 1.2GB)",
            "New USB device detected: Logitech Webcam C920",
            "System time synchronized with NTP server",
            "SELinux policy reloaded (Contexts: 1250)",
            "Firewall rule added: Allow TCP port 8080 from 10.0.0.0/24",
            "Package update available: security-updates (Priority: High)",
            "GPU driver loaded successfully (CUDA 12.1)",
            "Systemd service backend-api.service entered running state",
            "Cron job system-maintenance completed (Status: Success)",
            "SMART warning on /dev/sda (Reallocated sectors: 5)",
            "User authorization pattern changed (Last modified: 2 minutes ago)",
            "VM snapshot created (Size: 4.5GB, Name: pre-deployment)",
            "Load balancer added new backend server (Total: 5 active)",
            "Kubernetes pod scheduled on node worker-03",
            "Memory cgroup limit reached for container backend-api-2",
            "Audit log rotation completed (Archived: 250MB)",
            "Power source changed to battery (Remaining: 95%)",
            "System upgrade scheduled for next maintenance window",
            "Network traffic spike detected (Interface: eth0, 850Mbps)",
        ];

        return events.RandomElement();
    }

    public static string GenerateSystemRecommendation()
    {
        List<string> recommendations = [
            "Consider increasing memory allocation based on current usage patterns",
            "CPU utilization consistently high - evaluate scaling compute resources",
            "Network I/O bottleneck detected - consider optimizing data transfer patterns",
            "Disk I/O latency above threshold - evaluate storage performance options",
            "Process restart frequency increased - investigate potential memory leaks",
            "Connection pool utilization high - consider increasing maximum connections",
            "Thread contention detected - review synchronization strategies",
            "Database query cache hit ratio low - analyze query patterns",
            "Garbage collection pause times increasing - review memory management",
            "System load variability high - consider auto-scaling implementation",
            "Log volume increased by 45% - review logging verbosity",
            "SSL/TLS handshake failures detected - verify certificate configuration",
            "API endpoint response time degradation - review recent code changes",
            "Cache eviction rate high - consider increasing cache capacity",
            "Disk space trending toward threshold - implement cleanup procedures",
            "Background task queue growing - evaluate worker pool size",
            "Network packet retransmission rate above baseline - investigate network health",
            "Authentication failures increased - review security policies",
            "Container restart frequency above threshold - analyze container health checks",
            "Database connection establishment latency increasing - review connection handling",
            "Memory fragmentation detected - consider periodic service restarts",
            "File descriptor usage approaching limit - review resource management",
            "Thread pool saturation detected - evaluate concurrency settings",
            "Kernel parameter tuning recommended for workload profile",
            "Consider upgrading system packages for performance improvements",
            "Database index fragmentation detected - schedule maintenance window",
            "Background CPU usage high - investigate system processes",
            "TCP connection establishment rate above baseline - review connection pooling",
            "Memory swapping detected - increase physical memory or reduce consumption",
            "Consider implementing distributed tracing for performance analysis",
        ];
        return recommendations.RandomElement();
    }
}
