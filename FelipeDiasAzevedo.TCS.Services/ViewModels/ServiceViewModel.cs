namespace FelipeDiasAzevedo.TCS.Business.ViewModels;

public record ServiceViewModel
{
    public required List<ServiceStatusViewModel> Services { get; init; }
}

public record ServiceStatusViewModel
{
    public required string Name { get; init; }
    //public required string DisplayName { get; init; }

    public bool Running { get; init; }
}

public enum ServiceStatus
{
    Stopped,
    Running,
    Paused,
    Pending
}
