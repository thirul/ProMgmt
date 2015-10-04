using ProMgmt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMgmt.Data.Repository
{
    public  interface ICategoryRepositoy:IRepository<Category>
    {
        void UpdateName(Category category);
    }
}
