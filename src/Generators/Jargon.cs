using Stakeholder.Enums;
using Stakeholder.Utils;
using System.Collections.Generic;

namespace Stakeholder.Generators
{
    public class Jargon
    {
        public static string GenerateCodeJargon(DevelopmentType devType, JargonLevel level)
        {
            List<string> basicTerms = devType switch
            {
                DevelopmentType.Backend => [
                    "Optimized query execution paths for improved database throughput",
                    "Reduced API latency via connection pooling and request batching",
                    "Implemented stateless authentication with JWT token rotation",
                    "Applied circuit breaker pattern to prevent cascading failures",
                    "Utilized CQRS pattern for complex domain operations",
                ],
                DevelopmentType.Frontend => [
                    "Implemented virtual DOM diffing for optimal rendering performance",
                    "Applied tree-shaking and code-splitting for bundle optimization",
                    "Utilized CSS containment for layout performance improvement",
                    "Implemented intersection observer for lazy-loading optimization",
                    "Reduced reflow calculations with CSS will-change property",
                ],
                DevelopmentType.Fullstack => [
                    "Optimized client-server data synchronization protocols",
                    "Implemented isomorphic rendering for optimal user experience",
                    "Applied domain-driven design across frontend and backend boundaries",
                    "Utilized BFF pattern to optimize client-specific API responses",
                    "Implemented event sourcing for consistent system state",
                ],
                DevelopmentType.DataScience => [
                    "Applied regularization techniques to prevent overfitting",
                    "Implemented feature engineering pipeline with dimensionality reduction",
                    "Utilized distributed computing for parallel data processing",
                    "Optimized data transformations with vectorized operations",
                    "Applied statistical significance testing to validate results",
                ],
                DevelopmentType.DevOps => [
                    "Implemented infrastructure as code with immutable deployment patterns",
                    "Applied blue-green deployment strategy for zero-downtime updates",
                    "Utilized service mesh for enhanced observability and traffic control",
                    "Implemented GitOps workflow for declarative configuration management",
                    "Applied chaos engineering principles to improve resilience",
                ],
                DevelopmentType.Blockchain => [
                    "Optimized transaction validation through merkle tree verification",
                    "Implemented sharding for improved blockchain throughput",
                    "Applied zero-knowledge proofs for privacy-preserving transactions",
                    "Utilized state channels for off-chain scaling optimization",
                    "Implemented consensus algorithm with Byzantine fault tolerance",
                ],
                DevelopmentType.MachineLearning => [
                    "Applied gradient boosting for improved model performance",
                    "Implemented feature importance analysis for model interpretability",
                    "Utilized transfer learning to optimize training efficiency",
                    "Applied hyperparameter tuning with Bayesian optimization",
                    "Implemented ensemble methods for model robustness",
                ],
                DevelopmentType.SystemsProgramming => [
                    "Optimized cache locality with data-oriented design patterns",
                    "Implemented zero-copy memory management for I/O operations",
                    "Applied lock-free algorithms for concurrent data structures",
                    "Utilized SIMD instructions for vectorized processing",
                    "Implemented memory pooling for reduced allocation overhead",
                ],
                DevelopmentType.GameDevelopment => [
                    "Optimized spatial partitioning for collision detection performance",
                    "Implemented entity component system for flexible game architecture",
                    "Applied level of detail techniques for rendering optimization",
                    "Utilized GPU instancing for rendering large object counts",
                    "Implemented deterministic physics for consistent simulation",
                ],
                DevelopmentType.Security => [
                    "Applied principle of least privilege across security boundaries",
                    "Implemented defense-in-depth strategies for layered security",
                    "Utilized cryptographic primitives for secure data exchange",
                    "Applied security by design with threat modeling methodology",
                    "Implemented zero-trust architecture for access control",
                ],
                _ => [],
            };

            List<string> advancedTerms = devType switch
            {
                DevelopmentType.Backend => [
                    "Implemented polyglot persistence with domain-specific data storage optimization",
                    "Applied event-driven architecture with CQRS and event sourcing for eventual consistency",
                    "Utilized domain-driven hexagonal architecture for maintainable business logic isolation",
                    "Implemented reactive non-blocking I/O with backpressure handling for system resilience",
                    "Applied saga pattern for distributed transaction management with compensating actions",
                ],
                DevelopmentType.Frontend => [
                    "Implemented compile-time static analysis for type-safe component composition",
                    "Applied atomic CSS methodology with tree-shakable style injection",
                    "Utilized custom rendering reconciliation with incremental DOM diffing",
                    "Implemented time-sliced rendering with priority-based task scheduling",
                    "Applied declarative animation system with hardware acceleration optimization",
                ],
                DevelopmentType.Fullstack => [
                    "Implemented protocol buffers for bandwidth-efficient binary communication",
                    "Applied graphql federation with distributed schema composition",
                    "Utilized optimistic UI updates with conflict resolution strategies",
                    "Implemented real-time synchronization with operational transformation",
                    "Applied CQRS with event sourcing for cross-boundary domain consistency",
                ],
                DevelopmentType.DataScience => [
                    "Implemented ensemble stacking with meta-learner optimization",
                    "Applied automated feature engineering with genetic programming",
                    "Utilized distributed training with parameter server architecture",
                    "Implemented gradient checkpointing for memory-efficient backpropagation",
                    "Applied causal inference methods with propensity score matching",
                ],
                DevelopmentType.DevOps => [
                    "Implemented policy-as-code with OPA for declarative security guardrails",
                    "Applied progressive delivery with automated canary analysis",
                    "Utilized custom control plane for multi-cluster orchestration",
                    "Implemented observability with distributed tracing and context propagation",
                    "Applied predictive scaling based on time-series forecasting",
                ],
                DevelopmentType.Blockchain => [
                    "Implemented plasma chains with fraud proofs for scalable layer-2 solutions",
                    "Applied zero-knowledge SNARKs for privacy-preserving transaction validation",
                    "Utilized threshold signatures for distributed key management",
                    "Implemented state channels with watch towers for secure off-chain transactions",
                    "Applied formal verification for smart contract security guarantees",
                ],
                DevelopmentType.MachineLearning => [
                    "Implemented neural architecture search with reinforcement learning",
                    "Applied differentiable programming for end-to-end trainable pipelines",
                    "Utilized federated learning with secure aggregation protocols",
                    "Implemented attention mechanisms with sparse transformers",
                    "Applied meta-learning for few-shot adaptation capabilities",
                ],
                DevelopmentType.SystemsProgramming => [
                    "Implemented heterogeneous memory management with NUMA awareness",
                    "Applied compile-time computation with constexpr metaprogramming",
                    "Utilized lock-free concurrency with hazard pointers for memory reclamation",
                    "Implemented vectorized processing with auto-vectorization hints",
                    "Applied formal correctness proofs for critical system components",
                ],
                DevelopmentType.GameDevelopment => [
                    "Implemented procedural generation with constraint-based wave function collapse",
                    "Applied hierarchical task network for advanced AI planning",
                    "Utilized data-oriented entity component system with SoA memory layout",
                    "Implemented GPU-driven rendering pipeline with indirect drawing",
                    "Applied reinforcement learning for emergent NPC behavior",
                ],
                DevelopmentType.Security => [
                    "Implemented homomorphic encryption for secure multi-party computation",
                    "Applied formal verification for cryptographic protocol security",
                    "Utilized post-quantum cryptographic primitives for forward security",
                    "Implemented secure multi-party computation with secret sharing",
                    "Applied hardware-backed trusted execution environments for secure enclaves",
                ],
                _ => []
            };

            List<string> extremeTerms = [
                "Implemented isomorphic polymorphic runtime with transpiled metaprogramming for cross-paradigm interoperability",
                "Utilized quantum-resistant cryptographic primitives with homomorphic computation capabilities",
                "Applied non-euclidean topology optimization for multi-dimensional data representation",
                "Implemented stochastic gradient Langevin dynamics with cyclical annealing for robust convergence",
                "Utilized differentiable neural computers with external memory addressing for complex reasoning tasks",
                "Applied topological data analysis with persistent homology for feature extraction",
                "Implemented zero-knowledge recursive composition for scalable verifiable computation",
                "Utilized category theory-based functional abstractions for composable system architecture",
                "Applied generalized abstract non-commutative algebra for cryptographic protocol design",
            ];

            return level switch
            {
                JargonLevel.Low => basicTerms.RandomElement(),
                JargonLevel.Medium => basicTerms.RandomElement(),
                JargonLevel.High => advancedTerms.RandomElement(),
                JargonLevel.Extreme => extremeTerms.RandomElement(0.7, advancedTerms),
                _ => ""
            };
        }

        public static string GeneratePerformanceJargon(DevelopmentType devType, JargonLevel level)
        {
            List<string> basicTerms = devType switch
            {
                DevelopmentType.Backend => [
                    "Optimized request handling with connection pooling",
                    "Implemented caching layer for frequently accessed data",
                    "Applied query optimization for improved database performance",
                    "Utilized async I/O for non-blocking request processing",
                    "Implemented rate limiting to prevent resource contention",
                ],
                DevelopmentType.Frontend => [
                    "Optimized rendering pipeline with virtual DOM diffing",
                    "Implemented code splitting for reduced initial load time",
                    "Applied tree-shaking for reduced bundle size",
                    "Utilized resource prioritization for critical path rendering",
                    "Implemented request batching for reduced network overhead",
                ],
                _ => [
                    "Optimized execution path for improved throughput",
                    "Implemented data caching for repeated operations",
                    "Applied resource pooling for reduced initialization overhead",
                    "Utilized parallel processing for compute-intensive operations",
                    "Implemented lazy evaluation for on-demand computation",
                ],
            };

            List<string> advancedTerms = devType switch
            {
                DevelopmentType.Backend => [
                    "Implemented adaptive rate limiting with token bucket algorithm",
                    "Applied distributed caching with write-through invalidation",
                    "Utilized query denormalization for read-path optimization",
                    "Implemented database sharding with consistent hashing",
                    "Applied predictive data preloading based on access patterns",
                ],
                DevelopmentType.Frontend => [
                    "Implemented speculative rendering for perceived performance improvement",
                    "Applied RAIL performance model with user-centric metrics",
                    "Utilized intersection observer for just-in-time resource loading",
                    "Implemented partial hydration with selective client-side execution",
                    "Applied computation caching with memoization strategies",
                ],
                _ => [
                    "Implemented adaptive computation with context-aware optimization",
                    "Applied memory access pattern optimization for cache efficiency",
                    "Utilized workload partitioning with load balancing strategies",
                    "Implemented algorithm selection based on input characteristics",
                    "Applied predictive execution for latency hiding",
                ],
            };

            List<string> extremeTerms = [
                "Implemented quantum-inspired optimization for NP-hard scheduling problems",
                "Applied multi-level heterogeneous caching with ML-driven eviction policies",
                "Utilized holographic data compression with lossy reconstruction tolerance",
                "Implemented custom memory hierarchy with algorithmic complexity-aware caching",
                "Applied tensor computation with specialized hardware acceleration paths",
            ];

            return level switch
            {
                JargonLevel.Low => basicTerms.RandomElement(),
                JargonLevel.Medium => basicTerms.RandomElement(),
                JargonLevel.High => advancedTerms.RandomElement(),
                JargonLevel.Extreme => extremeTerms.RandomElement(0.7, advancedTerms),
                _ => ""
            };
        }

        public static string GenerateDataJargon(DevelopmentType devType, JargonLevel level)
        {
            List<string> basicTerms = devType switch
            {
                DevelopmentType.DataScience or DevelopmentType.MachineLearning => [
                    "Applied feature normalization for improved model convergence",
                    "Implemented data augmentation for enhanced training set diversity",
                    "Utilized cross-validation for robust model evaluation",
                    "Applied dimensionality reduction for feature space optimization",
                    "Implemented ensemble methods for improved prediction accuracy",
                ],
                _ => [
                    "Optimized data serialization for efficient transmission",
                    "Implemented data compression for reduced storage requirements",
                    "Applied data partitioning for improved query performance",
                    "Utilized caching strategies for frequently accessed data",
                    "Implemented data validation for improved consistency",
                ],
            };

            List<string> advancedTerms = devType switch
            {
                DevelopmentType.DataScience or DevelopmentType.MachineLearning => [
                    "Implemented adversarial validation for dataset shift detection",
                    "Applied bayesian hyperparameter optimization with gaussian processes",
                    "Utilized gradient accumulation for large batch training",
                    "Implemented feature interaction discovery with neural factorization machines",
                    "Applied time-series forecasting with attention-based sequence models",
                ],
                _ => [
                    "Implemented custom serialization with schema evolution support",
                    "Applied data denormalization with materialized view maintenance",
                    "Utilized bloom filters for membership testing optimization",
                    "Implemented data sharding with consistent hashing algorithms",
                    "Applied real-time stream processing with windowed aggregation",
                ],
            };

            List<string> extremeTerms = [
                "Implemented manifold learning with locally linear embedding for nonlinear dimensionality reduction",
                "Applied topological data analysis with persistent homology for feature engineering",
                "Utilized quantum-resistant homomorphic encryption for privacy-preserving data processing",
                "Implemented causal inference with structural equation modeling and counterfactual analysis",
                "Applied differentiable programming for end-to-end trainable data transformation",
            ];

            return level switch
            {
                JargonLevel.Low => basicTerms.RandomElement(),
                JargonLevel.Medium => basicTerms.RandomElement(),
                JargonLevel.High => advancedTerms.RandomElement(),
                JargonLevel.Extreme => extremeTerms.RandomElement(0.7, advancedTerms),
                _ => ""
            };
        }

        public static string GenerateNetworkJargon(DevelopmentType devType, JargonLevel level)
        {
            List<string> basicTerms = [
                "Optimized request batching for reduced network overhead",
                "Implemented connection pooling for improved throughput",
                "Applied response compression for bandwidth optimization",
                "Utilized HTTP/2 multiplexing for parallel requests",
                "Implemented retry strategies with exponential backoff",
            ];

            List<string> advancedTerms = devType switch
            {
                DevelopmentType.Backend or DevelopmentType.DevOps => [
                    "Implemented adaptive load balancing with consistent hashing",
                    "Applied circuit breaking with health-aware routing",
                    "Utilized connection multiplexing with protocol negotiation",
                    "Implemented traffic shaping with token bucket rate limiting",
                    "Applied distributed tracing with context propagation",
                ],
                _ => [
                    "Implemented request prioritization with critical path analysis",
                    "Applied proactive connection management with warm pooling",
                    "Utilized content negotiation for optimized payload delivery",
                    "Implemented response streaming with backpressure handling",
                    "Applied predictive resource loading based on usage patterns",
                ],
            };

            List<string> extremeTerms = [
                "Implemented quantum-resistant secure transport layer with post-quantum cryptography",
                "Applied autonomous traffic management with ML-driven routing optimization",
                "Utilized programmable data planes with in-network computation capabilities",
                "Implemented distributed consensus with Byzantine fault tolerance guarantees",
                "Applied formal verification for secure protocol implementation correctness",
            ];

            return level switch
            {
                JargonLevel.Low => basicTerms.RandomElement(),
                JargonLevel.Medium => basicTerms.RandomElement(),
                JargonLevel.High => advancedTerms.RandomElement(),
                JargonLevel.Extreme => extremeTerms.RandomElement(0.7, advancedTerms),
                _ => ""
            };
        }
    }
}
