namespace FelipeDiasAzevedo.TCS.Business.ViewModels;

public record ServiceViewModel
{
    public required List<ServiceStatusViewModel> Services { get; init; }
}

public record ServiceStatusViewModel
{
    public required string Name { get; init; }

    public required string DisplayName { get; init; }

    public required string ServiceType { get; init; }

    public required string StartType { get; init; }

    public required ServiceStatus Status { get; init; }

    public bool Running => Status is ServiceStatus.Running;

    public bool CanStart => Status is ServiceStatus.Stopped or ServiceStatus.Paused;

    public bool CanStop => Status is ServiceStatus.Running or ServiceStatus.Paused;

    public List<ServiceLogViewModel> Logs { get; init; } = [];
}

public record ServiceLogViewModel
{
    public required DateTime DateTime { get; set; }

    public required string Type { get; set; }

    public required string Message { get; set; }
}

public enum ServiceStatus
{
    Stopped,
    Running,
    Paused,
    Pending
}
