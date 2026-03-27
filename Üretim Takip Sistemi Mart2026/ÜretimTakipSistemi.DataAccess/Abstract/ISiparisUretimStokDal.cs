namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface ISiparisUretimStokDal
    {
        void UretimStoklariniGuncelle(string stokNo, int uretilenAdet);
    }
}
