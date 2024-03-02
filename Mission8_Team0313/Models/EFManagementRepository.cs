namespace Mission8_Team0313.Models
{
    public class EFManagementRepository : IManagementRepository
    {

        private TimeManagementContext _context;
        public EFManagementRepository(TimeManagementContext temp)
        {
            _context = temp;
        }
        
        public List<Action> Actions => _context.Actions.ToList();

        public void AddAction(Action action)
        {
            _context.Add(action);
            _context.SaveChanges();
        }
    }
}
