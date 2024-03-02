namespace Mission8_Team0313.Models
{
    public class EFManagementRepository(TimeManagementContext context) : IManagementRepository
    {

        private readonly TimeManagementContext _context = context;

        public IQueryable<Action> Actions => _context.Actions;

        public IQueryable<Category> Categories => _context.Categories;

        public void AddAction(Action action)
        {
            _context.Actions.Add(action);
        }

        public void DeleteAction(int actionId)
        {
            var actionToDelete = _context.Actions.FirstOrDefault(a => a.TaskID == actionId);
            if (actionToDelete != null)
            {
                _context.Actions.Remove(actionToDelete);
            }
        }

        public Action GetActionById(int actionId)
        {
            return _context.Actions.FirstOrDefault(a => a.TaskID == actionId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateAction(Action action)
        {
            _context.Actions.Update(action);
        }
    }
}
