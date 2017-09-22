namespace CookingTime.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Dispose();

        void Commit();
    }
}