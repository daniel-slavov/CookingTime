using CookingTime.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingTime.Models;
using CookingTime.Data.Contracts;
using CookingTime.Factories;

namespace CookingTime.Services
{
    public class IngredientService : IIngredientService
    {
//        private readonly IRepository<Ingredient> IngredientRepository;
//        private readonly IUnitOfWork UnitOfWork;
//        private readonly IIngredientFactory IngredientFactory;

//        public IngredientService(
//            IRepository<Ingredient> ingredientRepository,
//            IUnitOfWork unitOfWork,
//            IIngredientFactory ingredientFactory
//            )
//        {
//            this.IngredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
//            this.UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
//            this.IngredientFactory = ingredientFactory ?? throw new ArgumentNullException(nameof(ingredientFactory));
//        }

//        public Ingredient Create(string name)
//        {
//            throw new NotImplementedException();
//        }

//        public ICollection<Ingredient> GetAllByName(ICollection<string> names)
//        {
//            ICollection<Ingredient> ingredients = this.IngredientRepository.All
//                .Where(x => names.Contains(x.Name)).ToList();

//            return ingredients;
//        }

//        public Ingredient GetByName(string name)
//        {
//            Ingredient ingredient = this.IngredientRepository.All
//                .FirstOrDefault(x => x.Name == name);

//            return ingredient;
//        }
    }
}
