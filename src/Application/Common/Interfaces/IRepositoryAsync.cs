using Ardalis.Specification;


namespace WebApiTest.Application.Common.Interfaces;

public  interface IRepositoryAsync<T> : IRepositoryBase<T> where T: class
{

}

public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
{

}
