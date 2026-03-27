using System.Collections.Generic;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface ISiparisChatDal
    {
        void DosyaGonder(string gonderen, string dosyaAdi, byte[] dosyaVerisi);
        void MesajGonder(string gonderen, string mesaj);
        void MesajSil(int mesajId);
        List<SiparisChatMesaji> GetMesajlar(int sonMesajId);
    }
}
