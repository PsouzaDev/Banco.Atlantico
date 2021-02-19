using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Banco.Atlantico.Application.Enum
{
    public enum TiposStatus
    {
        [Description("ATIVO")]
        ATIVO = 1,
        [Description("BLOQUEADO")]
        BLOQUEADO = 2
    }
}
