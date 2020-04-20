using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Vos.Mappers
{
    interface VoMapper<T, K>
    {
        T MapFromVo(K vo);
        K MapToVo(T o);
    }
}
