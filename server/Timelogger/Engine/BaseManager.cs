namespace Timelogger.Engine
{
    public class BaseManager
    {
        protected readonly TestRepository _repository;
        protected readonly ApiContext _context;

        private BaseManager() { }

        public BaseManager(ApiContext context)
        {
            _repository = new TestRepository(context);
            _context = context;
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
