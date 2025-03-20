using Stakeholder.Enums;

namespace Stakeholder;
    
public record SessionConfig(
    DevelopmentType DevType,
    JargonLevel JargonLevel,
    Complexity Complexity,
    bool AlertsEnabled,
    string ProjectName,
    bool MinimalOutput,
    bool TeamActivity,
    string Framework
);
