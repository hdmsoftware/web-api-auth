using System;
namespace DataModel.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Dispose();
        DataModel.GenericRepository.GenericRepository<DataModel.Product> ProductRepository { get; }
        void Save();
        DataModel.GenericRepository.GenericRepository<DataModel.Token> TokenRepository { get; }
        DataModel.GenericRepository.GenericRepository<DataModel.User> UserRepository { get; }
    }
}
