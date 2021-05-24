using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP_NoSQL_SearchEngines.IRepositories
{
    interface ISearchRepository
    {
        Task CreateIndex<T>() where T : class;
        Task CreateIndexIfNotExists<T>() where T : class;
        Task DeleteIndex<T>() where T : class;
        Task DropAndCreateIndex<T>() where T : class;
    }
}
