namespace Mission8_Team0313.Models
{
    public interface IManagementRepository
    {
        List<Action> Actions { get; }

        public void AddAction(Action action);
    }
}
