using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Atlantico.Domain
{
    public interface IBuilder<out T>
    {
        T Select();
        IQueryBuilder Builder();
    }
}
