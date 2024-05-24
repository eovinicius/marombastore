using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marombastore.Core.Seedwork;

public interface IUnitOfWork
{
    Task Commit();
    Task Rollback();
}