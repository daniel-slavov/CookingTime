using CookingTime.Models;
using System;
using System.Collections.Generic;

namespace CookingTime.Services.Contracts
{
    public interface IRecipeService
    {
        Recipe GetById(Guid id);

        IEnumerable<Recipe> GetAll();

        IEnumerable<Recipe> GetAllWithDeleted();

        Guid Create(string title, string description, string imageUrl, string userId);

        void Update(Guid id, string title, string description, string imageUrl);

        void Delete(Guid id);

        void Recover(Guid id);
    }
}
