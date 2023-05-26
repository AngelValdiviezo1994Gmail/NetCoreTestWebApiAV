﻿using Ardalis.Specification;

namespace WebApiTest.Application.Common.Interfaces;

public interface IRepositoryMarcacionesAsync<T> : IRepositoryBase<T> where T : class
{

}

public interface IReadRepositoryMarcacionesAsync<T> : IReadRepositoryBase<T> where T : class
{

}
