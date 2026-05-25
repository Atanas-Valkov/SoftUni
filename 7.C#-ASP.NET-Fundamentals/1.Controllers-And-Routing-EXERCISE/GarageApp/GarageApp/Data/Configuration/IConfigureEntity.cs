namespace GarageApp.Data.Configuration
{
    public interface IConfigureEntity<T>
    {
        void Configure(T entity);
    }
}