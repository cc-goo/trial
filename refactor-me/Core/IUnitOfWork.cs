using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using refactor_me.Core.Repositories;

namespace refactor_me.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IProductOptionRepository ProductOptions { get; }

        int Complete();
    }
}
