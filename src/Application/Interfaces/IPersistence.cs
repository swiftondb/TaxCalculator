namespace TaxCalculator.Application.Interfaces;

public interface IPersistence
{
    IQueryable<TEntity> Query<TEntity>() where TEntity : class;
}
