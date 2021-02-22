using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Banco.Atlantico.Application.Enum
{
    public enum TiposNotas
    {
        [Description("DOIS_REAIS")]
        DOIS = 1,
        [Description("CINCO_REAIS")]
        CINCO = 2,
        [Description("DEZ_REAIS")]
        DEZ = 3,
        [Description("VINTE_REAIS")]
        VINTE = 4,
        [Description("CINQUENTA_REAIS")]
        CINQUENTA = 5,
    }
}
