﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Banco.Atlantico.Domain.Enum
{
    public enum TiposStatus
    {
        [Description("ATIVO")]
        ATIVO = 0,
        [Description("BLOQUEADO")]
        BLOQUEADO = 1
    }
}
