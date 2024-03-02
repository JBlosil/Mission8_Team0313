namespace Mission8_Team0313.Models
{
    public interface IManagementRepository
    {
        // Assuming 'Action' is the name of your entity for actions/tasks
        IQueryable<Action> Actions { get; }
        IQueryable<Category> Categories { get; }

        Action GetActionById(int actionId);
        void AddAction(Action action);
        void UpdateAction(Action action);
        void DeleteAction(int actionId);
        void SaveChanges();
    }
}
