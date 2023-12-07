using TaxCalculator.Application.Interfaces;

namespace TaxCalculator.Infrastructure.Contexts;

public partial class AppDbContext : IPersistence
{
    public IQueryable<TEntity> Query<TEntity>() where TEntity : class => Set<TEntity>();
}
