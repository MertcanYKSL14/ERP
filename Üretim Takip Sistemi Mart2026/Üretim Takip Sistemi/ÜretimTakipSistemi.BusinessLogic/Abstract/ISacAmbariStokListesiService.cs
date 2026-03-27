using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.BusinessLogic.Abstract
{
    public interface ISacAmbariStokListesiService
    {
        List<SacAmbariStokListesi> GetAll();
    }
}
