using Stakeholder.Enums;
using Stakeholder.Utils;
using System.Collections.Generic;


namespace Stakeholder.Generators;

public static class NetworkActivity
{
    public static string GenerateEndpoint(DevelopmentType devType)
    {
        List<string> endpoints = devType switch {
            DevelopmentType.Backend => [
                "/api/v1/users",
                "/api/v1/users/{id}",
                "/api/v1/products",
                "/api/v1/orders",
                "/api/v1/payments",
                "/api/v1/auth/login",
                "/api/v1/auth/refresh",
                "/api/v1/analytics/report",
                "/api/v1/notifications",
                "/api/v1/system/health",
                "/api/v2/recommendations",
                "/internal/metrics",
                "/internal/cache/flush",
                "/webhook/payment-provider",
                "/graphql",
            ],
            DevelopmentType.Frontend => [
                "/assets/main.js",
                "/assets/styles.css",
                "/api/v1/user-preferences",
                "/api/v1/cart",
                "/api/v1/products/featured",
                "/api/v1/auth/session",
                "/assets/fonts/roboto.woff2",
                "/api/v1/notifications/unread",
                "/assets/images/hero.webp",
                "/api/v1/search/autocomplete",
                "/socket.io/",
                "/api/v1/analytics/client-events",
                "/manifest.json",
                "/service-worker.js",
                "/api/v1/feature-flags",
            ],
            DevelopmentType.Fullstack => [
                "/api/v1/users/profile",
                "/api/v1/cart/checkout",
                "/api/v1/products/recommendations",
                "/api/v1/orders/history",
                "/api/v1/sync/client-state",
                "/api/v1/settings/preferences",
                "/api/v1/notifications/subscribe",
                "/api/v1/auth/validate",
                "/api/v1/content/dynamic",
                "/api/v1/analytics/events",
                "/graphql",
                "/socket.io/",
                "/api/v1/realtime/connect",
                "/api/v1/system/status",
                "/api/v1/feature-flags",
            ],
            DevelopmentType.DataScience => [
                "/api/v1/data/insights",
                "/api/v1/models/predict",
                "/api/v1/datasets/process",
                "/api/v1/analytics/report",
                "/api/v1/visualization/render",
                "/api/v1/features/importance",
                "/api/v1/experiments/results",
                "/api/v1/models/evaluate",
                "/api/v1/pipeline/execute",
                "/api/v1/data/validate",
                "/api/v1/data/transform",
                "/api/v1/models/train/status",
                "/api/v1/datasets/schema",
                "/api/v1/metrics/model-performance",
                "/api/v1/data/export",
            ],
            DevelopmentType.DevOps => [
                "/api/v1/infrastructure/status",
                "/api/v1/deployments/latest",
                "/api/v1/metrics/system",
                "/api/v1/alerts",
                "/api/v1/logs/query",
                "/api/v1/scaling/triggers",
                "/api/v1/config/validate",
                "/api/v1/backups/status",
                "/api/v1/security/scan-results",
                "/api/v1/environments/health",
                "/api/v1/pipeline/status",
                "/api/v1/services/dependencies",
                "/api/v1/resources/utilization",
                "/api/v1/network/topology",
                "/api/v1/incidents/active",
            ],
            DevelopmentType.Blockchain => [
                "/api/v1/transactions/submit",
                "/api/v1/blocks/latest",
                "/api/v1/wallet/balance",
                "/api/v1/smart-contracts/execute",
                "/api/v1/nodes/status",
                "/api/v1/network/peers",
                "/api/v1/consensus/status",
                "/api/v1/transactions/verify",
                "/api/v1/wallet/sign",
                "/api/v1/tokens/transfer",
                "/api/v1/chain/info",
                "/api/v1/mempool/status",
                "/api/v1/validators/performance",
                "/api/v1/oracle/data",
                "/api/v1/smart-contracts/audit",
            ],
            DevelopmentType.MachineLearning => [
                "/api/v1/models/infer",
                "/api/v1/models/train",
                "/api/v1/datasets/process",
                "/api/v1/features/extract",
                "/api/v1/models/evaluate",
                "/api/v1/hyperparameters/optimize",
                "/api/v1/experiments/results",
                "/api/v1/models/export",
                "/api/v1/models/versions",
                "/api/v1/predictions/batch",
                "/api/v1/embeddings/generate",
                "/api/v1/models/metrics",
                "/api/v1/training/status",
                "/api/v1/deployment/model",
                "/api/v1/features/importance",
            ],
            DevelopmentType.SystemsProgramming => [
                "/api/v1/memory/profile",
                "/api/v1/processes/stats",
                "/api/v1/threads/activity",
                "/api/v1/io/performance",
                "/api/v1/cpu/utilization",
                "/api/v1/network/statistics",
                "/api/v1/locks/contention",
                "/api/v1/allocations/trace",
                "/api/v1/system/interrupts",
                "/api/v1/devices/status",
                "/api/v1/filesystem/stats",
                "/api/v1/cache/performance",
                "/api/v1/kernel/parameters",
                "/api/v1/syscalls/frequency",
                "/api/v1/performance/profile",
            ],
            DevelopmentType.GameDevelopment => [
                "/api/v1/assets/download",
                "/api/v1/player/progress",
                "/api/v1/matchmaking/find",
                "/api/v1/leaderboard/global",
                "/api/v1/game/state/sync",
                "/api/v1/player/inventory",
                "/api/v1/player/achievements",
                "/api/v1/multiplayer/session",
                "/api/v1/analytics/gameplay",
                "/api/v1/content/updates",
                "/api/v1/physics/simulation",
                "/api/v1/rendering/performance",
                "/api/v1/player/settings",
                "/api/v1/server/regions",
                "/api/v1/telemetry/submit",
            ],
            DevelopmentType.Security => [
                "/api/v1/auth/token",
                "/api/v1/auth/validate",
                "/api/v1/users/permissions",
                "/api/v1/audit/logs",
                "/api/v1/security/scan",
                "/api/v1/vulnerabilities/report",
                "/api/v1/threats/intelligence",
                "/api/v1/compliance/check",
                "/api/v1/encryption/keys",
                "/api/v1/certificates/validate",
                "/api/v1/firewall/rules",
                "/api/v1/access/control",
                "/api/v1/identity/verify",
                "/api/v1/incidents/report",
                "/api/v1/monitoring/alerts",
            ],
            _ => []
        };

        return endpoints.RandomElement();
    }

    public static string GenerateMethod()
    {
        List<string> methods = ["GET", "POST", "PUT", "DELETE", "PATCH", "OPTIONS", "HEAD"];
        List<int> weights = [15, 8, 5, 3, 2, 1, 1]; // Weighted distribution
        return methods.RandomWeightedElement(weights);
    }

    public static int GenerateStatus() 
    {
        List<int> statusCodes = [
            // 2xx Success
            200, 201, 204, // 3xx Redirection
            301, 302, 304, // 4xx Client Error
            400, 401, 403, 404, 422, 429, // 5xx Server Error
            500, 502, 503, 504,
        ];

        List<int> weights = [
            // 2xx - most common
            60, 10, 5, // 3xx - less common
            3, 3, 5, // 4xx - somewhat common
            5, 3, 2, 8, 3, 2, // 5xx - least common
            2, 1, 1, 1,
        ];

        return statusCodes.RandomWeightedElement(weights);
    }

    public static string GenerateRequestDetails(DevelopmentType devType)
    {
        List<string> details = devType switch 
        {
            DevelopmentType.Backend => [
                "Content-Type: application/json, User authenticated, Rate limit: 1000/hour",
                "Database queries: 3, Cache hit ratio: 85%, Auth: JWT",
                "Processed in service layer, Business rules applied: 5, Validation passed",
                "Using connection pool, Transaction isolation: READ_COMMITTED",
                "Response compression: gzip, Caching: public, max-age=3600",
                "API version: v1, Deprecation warning: Use v2 endpoint",
                "Rate limited client: example-corp, Remaining: 240/minute",
                "Downstream services: payment-service, notification-service",
                "Tenant: acme-corp, Shard: eu-central-1-b, Replica: 3",
                "Auth scopes: read:users,write:orders, Principal: system-service",
            ],
            DevelopmentType.Frontend => [
                "Asset loaded from CDN, Cache status: HIT, Compression: Brotli",
                "Component rendered: ProductCard, Props: 8, Re-renders: 0",
                "User session active, Feature flags: new-checkout,dark-mode",
                "Local storage usage: 120KB, IndexedDB tables: 3",
                "RTT: 78ms, Resource timing: tcpConnect=45ms, ttfb=120ms",
                "View transition animated, FPS: 58, Layout shifts: 0",
                "Form validation, Fields: 6, Errors: 2, Async validation",
                "State update batched, Components affected: 3, Virtual DOM diff: minimal",
                "Client capabilities: webp,webgl,bluetooth, Viewport: mobile",
                "A/B test: checkout-flow-v2, Variation: B, User cohort: returning-purchaser",
            ],
            DevelopmentType.Fullstack => [
                "End-to-end transaction, Client version: 3.5.2, Server version: 4.1.0",
                "Data synchronization, Client state: stale, Delta sync applied",
                "Authentication: OAuth2, Scopes: profile,orders,payment",
                "Request origin: iOS native app, API version: v2, Feature flags: 5",
                "Response transformation applied, Fields pruned: 12, Size reduction: 68%",
                "Validated against schema v3, Frontend compatible: true",
                "Backend services: user-service, inventory-service, pricing-service",
                "Client capabilities detected, Optimized response stream enabled",
                "Session context propagated, Tenant: example-corp, User tier: premium",
                "Real-time channel established, Protocol: WebSocket, Compression: enabled",
            ],
            DevelopmentType.DataScience => [
                "Dataset: user_behavior_v2, Records: 25K, Features: 18, Processing mode: batch",
                "Model: recommendation_engine_v3, Architecture: gradient_boosting, Accuracy: 92.5%",
                "Feature importance analyzed, Top features: last_purchase_date, category_affinity",
                "Transformation pipeline applied: normalize, encode_categorical, reduce_dimensions",
                "Prediction confidence: 87.3%, Alternative predictions generated: 3",
                "Processing node: data-science-pod-7, GPUs allocated: 2, Batch size: 256",
                "Cross-validation: 5-fold, Metrics: precision=0.88, recall=0.92, f1=0.90",
                "Time-series forecast, Horizon: 30 days, MAPE: 12.5%, Seasonality detected",
                "Anomaly detection, Threshold: 3.5σ, Anomalies found: 7, Confidence: high",
                "Experiment: price_elasticity_test, Group: control, Version: A, Sample size: 15K",
            ],
            DevelopmentType.DevOps => [
                "Deployment: canary, Version: v2.5.3, Rollout: 15%, Health: green",
                "Infrastructure: Kubernetes, Namespace: production, Pod count: 24/24 ready",
                "Autoscaling event, Trigger: CPU utilization 85%, New replicas: 5, Cooldown: 300s",
                "CI/CD pipeline: main-branch, Stage: integration-tests, Duration: 8m45s",
                "Resource allocation: CPU: 250m/500m, Memory: 1.2GB/2GB, Storage: 45GB/100GB",
                "Monitoring alert: Response latency p95 > 500ms, Duration: 15m, Severity: warning",
                "Log aggregation: 15K events/min, Retention: 30 days, Sampling rate: 100%",
                "Infrastructure as Code: Terraform v1.2.0, Modules: networking, compute, storage",
                "Service mesh: traffic shifted, Destination: v2=80%,v1=20%, Retry budget: 3x",
                "Security scan complete, Vulnerabilities: 0 critical, 2 high, 8 medium, CVEs: 5",
            ],
            DevelopmentType.Blockchain => [
                "Transaction hash: 0x3f5e..., Gas used: 45,000, Block: 14,322,556, Confirmations: 12",
                "Smart contract: Token (0x742A...), Method: transfer, Arguments: address,uint256",
                "Block producer: validator-12, Slot: 52341, Transactions: 126, Size: 1.2MB",
                "Consensus round: 567432, Validators participated: 95/100, Agreement: 98.5%",
                "Wallet balance: 1,250.75 tokens, Nonce: 42, Available: 1,245.75 (5 staked)",
                "Network status: Ethereum mainnet, Gas price: 25 gwei, TPS: 15.3, Finality: 15 blocks",
                "Token transfer: 125.5 USDC → 0x9eA2..., Network fee: 0.0025 ETH, Status: confirmed",
                "Mempool: 1,560 pending transactions, Priority fee range: 1-30 gwei",
                "Smart contract verification: source matches bytecode, Optimizer: enabled (200 runs)",
                "Blockchain analytics: daily active addresses: 125K, New wallets: 8.2K, Volume: $1.2B",
            ],
            DevelopmentType.MachineLearning => [
                "Model: resnet50_v2, Batch size: 64, Hardware: GPU T4, Memory usage: 8.5GB",
                "Training iteration: 12,500/50,000, Loss: 0.0045, Learning rate: 0.0001, ETA: 2h15m",
                "Inference request, Model: sentiment_analyzer_v3, Version: production, Latency: 45ms",
                "Dataset: customer_feedback_2023, Samples: 1.2M, Features: 25, Classes: 5",
                "Hyperparameter tuning, Trial: 28/100, Parameters: lr=0.001,dropout=0.3,layers=3",
                "Model deployment: recommendation_engine, Environment: production, A/B test: enabled",
                "Feature engineering pipeline, Steps: 8, Transformations: normalize,pca,encoding",
                "Model evaluation, Metrics: accuracy=0.925,precision=0.88,recall=0.91,f1=0.895",
                "Experiment tracking: run_id=78b3e, Framework: PyTorch 2.0, Checkpoints: 5",
                "Model serving, Requests: 250/s, p99 latency: 120ms, Cache hit ratio: 85%",
            ],
            DevelopmentType.SystemsProgramming => [
                "Memory profile: Heap: 245MB, Stack: 12MB, Allocations: 12K, Fragmentation: 8%",
                "Thread activity: Threads: 24, Blocked: 2, CPU-bound: 18, I/O-wait: 4",
                "I/O operations: Read: 12MB/s, Write: 4MB/s, IOPS: 250, Queue depth: 3",
                "Process stats: PID: 12458, CPU: 45%, Memory: 1.2GB, Open files: 128, Uptime: 5d12h",
                "Lock contention: Mutex M1: 15% contended, RwLock R1: reader-heavy (98/2)",
                "System calls: Rate: 15K/s, Top: read=25%,write=15%,futex=12%,poll=10%",
                "Cache statistics: L1 miss: 2.5%, L2 miss: 8.5%, L3 miss: 12%, TLB miss: 0.5%",
                "Network stack: TCP connections: 1,250, UDP sockets: 25, Listen backlog: 2/100",
                "Context switches: 25K/s, Voluntary: 85%, Involuntary: 15%, Latency: 12μs avg",
                "Interrupt handling: Rate: 15K/s, Top sources: network=45%,disk=25%,timer=15%",
            ],
            DevelopmentType.GameDevelopment => [
                "Rendering stats: FPS: 120, Draw calls: 450, Triangles: 2.5M, Textures: 120MB",
                "Physics simulation: Bodies: 1,250, Contacts: 850, Sub-steps: 3, Time: 3.5ms",
                "Animation system: Skeletons: 25, Blend operations: 85, Memory: 12MB",
                "Asset loading: Streaming: 15MB/s, Loaded textures: 85/120, Mesh LODs: 3/5",
                "Game state: Players: 45, NPCs: 120, Interactive objects: 350, Memory: 85MB",
                "Multiplayer: Clients: 48/64, Bandwidth: 1.2Mbit/s, Latency: 45ms, Packet loss: 0.5%",
                "Particle systems: Active: 25, Particles: 12K, Update time: 1.2ms",
                "AI processing: Pathfinding: 35 agents, Behavior trees: 120, CPU time: 4.5ms",
                "Audio engine: Channels: 24/32, Sounds: 45, 3D sources: 18, Memory: 24MB",
                "Player telemetry: Events: 120/min, Session: 45min, Area: desert_ruins_05",
            ],
            DevelopmentType.Security => [
                "Authentication: Method: OIDC, Provider: Azure AD, Session: 2h45m remaining",
                "Authorization check: Principal: user@example.com, Roles: admin,editor, Access: granted",
                "Security scan: Resources checked: 45, Vulnerabilities: 0 critical, 2 high, 8 medium",
                "Certificate: Subject: api.example.com, Issuer: Let's Encrypt, Expires: 60 days",
                "Encryption: Algorithm: AES-256-GCM, Key rotation: 25 days ago, KMS: AWS",
                "Audit log: User: admin@example.com, Action: user.create, Status: success, IP: 203.0.113.42",
                "Rate limiting: Client: mobile-app-v3, Limit: 100/min, Current: 45/min",
                "Threat intelligence: IP reputation: medium risk, Known signatures: 0, Geo: Netherlands",
                "WAF analysis: Rules triggered: 0, Inspected: headers,body,cookies, Mode: block",
                "Security token: JWT, Signature: RS256, Claims: 12, Scope: api:full",
            ],
            _ => ["Recovering from unrecoverable error"]
        };

        return details.RandomElement();
    }
}
