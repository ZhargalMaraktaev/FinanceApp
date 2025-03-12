using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class AddCategoryCommand : ICommand
    {
        private CategoryFacade facade;
        private Category category;

        public AddCategoryCommand(CategoryFacade facade, Category category)
        {
            this.facade = facade;
            this.category = category;
        }

        public void Execute()
        {
            facade.AddCategory(category);
        }
    }

}
