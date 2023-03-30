﻿namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
        public IBrandRepository BrandRepository { get; }
        Task Save();
    }
}
