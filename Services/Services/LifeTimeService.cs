using Services.Abstractions.Servive_interfaces;

namespace Services.Services
{
    public class LifeTimeService : ILifeTimeService
    {
        private readonly Guid Id;

        public LifeTimeService()
        {
            Id = Guid.NewGuid();
        }

        public string GetGuid() => Id.ToString();
    }
}