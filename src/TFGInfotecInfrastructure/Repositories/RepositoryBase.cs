namespace TFGInfotecInfrastructure.Repositories
{
	public abstract class RepositoryBase
	{
		protected readonly ApplicationDbContext _context;
		protected readonly ILogger _logger;

		protected const string AddErrorMessage = "An error occurred while adding an entity.";
		protected const string AddAllErrorMessage = "An error occurred while adding entities.";
		protected const string GetByIdErrorMessage = "An error occurred while retrieving an entity by ID.";
		protected const string GetAllErrorMessage = "An error occurred while retrieving all entities.";
		protected const string UpdateErrorMessage = "An error occurred while updating an entity.";
		protected const string DeleteErrorMessage = "An error occurred while deleting an entity.";
		protected const string GetOneErrorMessage = "An error occurred while retrieving a single entity.";
		protected const string GetErrorMessage = "An error occurred while retrieving entities with filters.";

		protected RepositoryBase(ApplicationDbContext context, ILogger logger)
		{
			_context = context;
			_logger = logger;
		}
	}
}