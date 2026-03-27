using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi
{
    public partial class Press_Bolumu : Form
    {
        public Press_Bolumu()
        {
            InitializeComponent();
            _pressTakipSayacService = InstanceFactory.GetInstance<IPressTakipSayacService>();
            _urunlerService = InstanceFactory.GetInstance<IUrunlerService>();
        }
        private IPressTakipSayacService _pressTakipSayacService;
        private IUrunlerService _urunlerService;

        PressTakipSayac _pressTakipSayac = new PressTakipSayac();


        PressTakipDal _PressTakipDal = new PressTakipDal();
        
        private void Kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Press_Bolumu_Load(object sender, EventArgs e)
        {
            timer1.Start();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ekosan();
            Tomruk2();
            Tomruk1();
            Emek4();
            Emek1();
            Emek2();
            Karakaya();
            Emek3();
            Hp11();
            Hp10();
          //  Deneme();
        }

        private void Hp11()
        {
            try
            {
                PressTakip pressTakip = _PressTakipDal.UrunListele().FindLast(p => p.PressId == 11);
                if (pressTakip.DurumId == 1)
                {
                    lblHP11StokKodu.Text = pressTakip.StokKodu;
                    lblHP11StokAdi.Text = pressTakip.StokAdi;
                    lblHP11Operasyon.Text = pressTakip.Operasyon;
                    lblHP11Adet.Text = pressTakip.Adet.ToString();
                    btnHP11.BackColor = Color.Green;
                }
                else if (pressTakip.DurumId == 2)
                {
                    lblHP11StokKodu.Text = "Press Durmuştur...";
                    lblHP11StokAdi.Text = "";
                    lblHP11Operasyon.Text = "";
                    lblHP11Adet.Text = "";
                    btnHP11.BackColor = Color.Red;
                }
                else
                {
                    lblHP11StokKodu.Text = "Kalıp Değişimi...";
                    lblHP11StokAdi.Text = "";
                    lblHP11Operasyon.Text = "";
                    lblHP11Adet.Text = "";
                    btnHP11.BackColor = Color.Blue;
                }
            }
            catch (Exception)
            {
                lblHP11StokKodu.Text = "Press Durmuştur...";
                lblHP11StokAdi.Text = "";
                lblHP11Operasyon.Text = "";
                lblHP11Adet.Text = "";
            }
        }

        private void Hp10()
        {
            try
            {
                PressTakip pressTakip = _PressTakipDal.UrunListele().FindLast(p => p.PressId == 10);
                if (pressTakip.DurumId == 1)
                {
                    lblHP10StokKodu.Text = pressTakip.StokKodu;
                    lblHP10StokAdi.Text = pressTakip.StokAdi;
                    lblHP10Operasyon.Text = pressTakip.Operasyon;
                    lblHP10Adet.Text = pressTakip.Adet.ToString();
                    btnHP10.BackColor = Color.Green;
                }
                else if (pressTakip.DurumId == 2)
                {
                    lblHP10StokKodu.Text = "Press Durmuştur...";
                    lblHP10StokAdi.Text = "";
                    lblHP10Operasyon.Text = "";
                    lblHP10Adet.Text = "";
                    btnHP10.BackColor = Color.Red;
                }
                else
                {
                    lblHP10StokKodu.Text = "Kalıp Değişimi...";
                    lblHP10StokAdi.Text = "";
                    lblHP10Operasyon.Text = "";
                    lblHP10Adet.Text = "";
                    btnHP10.BackColor = Color.Blue;
                }
            }
            catch (Exception)
            {
                lblHP10StokKodu.Text = "Press Durmuştur...";
                lblHP10StokAdi.Text = "";
                lblHP10Operasyon.Text = "";
                lblHP10Adet.Text = "";
            }
        }

        private void PressDurum(int DurumId)
        {
            if (DurumId == 1)
            {

            }
            else if (DurumId == 2)
            {

            }
            else
            {

            }

        } // Bunun gibi bir yöntem planla

        private void Deneme()
        {
             _pressTakipSayac =_pressTakipSayacService.GetAll().FindLast(p => p.PressId ==38);
            label129.Text = _pressTakipSayac.Adet.ToString();
           // dataGridView1.DataSource = _urunlerService.GetAll();
        }

        private void Ekosan()
        {
            try
            {
                PressTakip pressTakip = _PressTakipDal.UrunListele().FindLast(p => p.PressId == 36);
                if (pressTakip.DurumId == 1)
                {
                    lblEkosanStokKodu.Text = pressTakip.StokKodu;
                    lblEkosanStokAdi.Text = pressTakip.StokAdi;
                    lblEkosanOperasyon.Text = pressTakip.Operasyon;
                    lblEkosanAdet.Text = pressTakip.Adet.ToString();
                    btnEkosan.BackColor = Color.Green;
                }
                else if (pressTakip.DurumId == 2)
                {
                    lblEkosanStokKodu.Text = "Press Durmuştur...";
                    lblEkosanStokAdi.Text = "";
                    lblEkosanOperasyon.Text = "";
                    lblEkosanAdet.Text = "";
                    btnEkosan.BackColor = Color.Red;
                }
                else
                {
                    lblEkosanStokKodu.Text = "Kalıp Değişimi...";
                    lblEkosanStokAdi.Text = "";
                    lblEkosanOperasyon.Text = "";
                    lblEkosanAdet.Text = "";
                    btnEkosan.BackColor = Color.Blue;
                }
            }
            catch (Exception)
            {
                lblEkosanStokKodu.Text = "Press Durmuştur...";
                lblEkosanStokAdi.Text = "";
                lblEkosanOperasyon.Text = "";
                lblEkosanAdet.Text = "";
            }
        }

        private void Tomruk2()
        {
            try
            {
                PressTakip pressTakip = _PressTakipDal.UrunListele().FindLast(p => p.PressId == 39);
                if (pressTakip.DurumId == 1)
                {
                    lblTomruk2StokKodu.Text = pressTakip.StokKodu;
                    lblTomruk2StokAdi.Text = pressTakip.StokAdi;
                    lblTomruk2Operasyon.Text = pressTakip.Operasyon;
                    lblTomruk2Adet.Text = pressTakip.Adet.ToString();
                    btnTomruk2.BackColor = Color.Green;
                }
                else if (pressTakip.DurumId == 2)
                {
                    lblTomruk2StokKodu.Text = "Kalıp Değişimi...";
                    lblTomruk2StokAdi.Text = "";
                    lblTomruk2Operasyon.Text = "";
                    lblTomruk2Adet.Text = "";
                    btnTomruk2.BackColor = Color.Red;
                }
                else
                {
                    lblTomruk2StokKodu.Text = "Kalıp Değişimi...";
                    lblTomruk2StokAdi.Text = "";
                    lblTomruk2Operasyon.Text = "";
                    lblTomruk2Adet.Text = "";
                    btnTomruk2.BackColor = Color.Blue;
                }
            }
            catch (Exception)
            {
                lblTomruk2StokKodu.Text = "Kalıp Değişimi...";
                lblTomruk2StokAdi.Text = "";
                lblTomruk2Operasyon.Text = "";
                lblTomruk2Adet.Text = "";
            }
        }

        private void Tomruk1()
        {
            try
            {
                PressTakip pressTakip = _PressTakipDal.UrunListele().FindLast(p => p.PressId == 35);
                if (pressTakip.DurumId == 1)
                {
                    lblTomruk1StokKodu.Text = pressTakip.StokKodu;
                    lblTomruk1StokAdi.Text = pressTakip.StokAdi;
                    lblTomruk1Operasyon.Text = pressTakip.Operasyon;
                    lblTomruk1Adet.Text = pressTakip.Adet.ToString();
                    btnTomruk1.BackColor = Color.Green;
                }
                else if (pressTakip.DurumId == 2)
                {
                    lblTomruk1StokKodu.Text = "Press Durmuştur...";
                    lblTomruk1StokAdi.Text = "";
                    lblTomruk1Operasyon.Text = "";
                    lblTomruk1Adet.Text = "";
                    btnTomruk1.BackColor = Color.Red;
                }
                else
                {
                    lblTomruk1StokKodu.Text = "Kalıp Değişimi...";
                    lblTomruk1StokAdi.Text = "";
                    lblTomruk1Operasyon.Text = "";
                    lblTomruk1Adet.Text = "";
                    btnTomruk1.BackColor = Color.Blue;
                }
            }
            catch (Exception)
            {
                lblTomruk1StokKodu.Text = "Press Durmuştur...";
                lblTomruk1StokAdi.Text = "";
                lblTomruk1Operasyon.Text = "";
                lblTomruk1Adet.Text = "";
            }
        }

        private void Emek4()
        {
            try
            {
                PressTakip pressTakip = _PressTakipDal.UrunListele().FindLast(p => p.PressId == 38);

                if (pressTakip.DurumId == 1)
                {
                    lblEmek4StokKodu.Text = pressTakip.StokKodu;
                    lblEmek4StokAdi.Text = pressTakip.StokAdi;
                    lblEmek4Operasyon.Text = pressTakip.Operasyon;
                    lblEmek4Adet.Text = pressTakip.Adet.ToString();
                    btnEmek4.BackColor = Color.Green;
                }
                else if (pressTakip.DurumId == 2)
                {
                    lblEmek4StokKodu.Text = "Press Durmuştur...";
                    lblEmek4StokAdi.Text = "";
                    lblEmek4Operasyon.Text = "";
                    lblEmek4Adet.Text = "";
                    btnEmek4.BackColor = Color.Red;
                }
                else
                {
                    lblEmek4StokKodu.Text = "Kalıp Değişimi...";
                    lblEmek4StokAdi.Text = "";
                    lblEmek4Operasyon.Text = "";
                    lblEmek4Adet.Text = "";
                    btnEmek4.BackColor = Color.Blue;
                }
            }
            catch (Exception)
            {
                lblEmek4StokKodu.Text = "Press Durmuştur...";
                lblEmek4StokAdi.Text = "";
                lblEmek4Operasyon.Text = "";
                lblEmek4Adet.Text = "";
            }
        }

        private void Emek1()
        {
            try
            {
                PressTakip pressTakip = _PressTakipDal.UrunListele().FindLast(p => p.PressId == 33);
                if (pressTakip.DurumId == 1)
                {
                    lblEmek1StokKodu.Text = pressTakip.StokKodu;
                    lblEmek1StokAdi.Text = pressTakip.StokAdi;
                    lblEmek1Operasyon.Text = pressTakip.Operasyon;
                    lblEmek1Adet.Text = pressTakip.Adet.ToString();
                    btnEmek1.BackColor = Color.Green;
                }
                else if (pressTakip.DurumId == 2)
                {
                    lblEmek1StokKodu.Text = "Press Durmuştur...";
                    lblEmek1StokAdi.Text = "";
                    lblEmek1Operasyon.Text = "";
                    lblEmek1Adet.Text = "";
                    btnEmek1.BackColor = Color.Red;
                }
                else
                {
                    lblEmek1StokKodu.Text = "Kalıp Değişimi...";
                    lblEmek1StokAdi.Text = "";
                    lblEmek1Operasyon.Text = "";
                    lblEmek1Adet.Text = "";
                    btnEmek1.BackColor = Color.Blue;
                }
            }
            catch (Exception)
            {
                lblEmek1StokKodu.Text = "Press Durmuştur...";
                lblEmek1StokAdi.Text = "";
                lblEmek1Operasyon.Text = "";
                lblEmek1Adet.Text = "";
            }
        }

        private void Emek2()
        {
            try
            {
                PressTakip pressTakip = _PressTakipDal.UrunListele().FindLast(p => p.PressId == 34);
                if (pressTakip.DurumId == 1)
                {
                    lblEmek2StokKodu.Text = pressTakip.StokKodu;
                    lblEmek2StokAdi.Text = pressTakip.StokAdi;
                    lblEmek2Operasyon.Text = pressTakip.Operasyon;
                    lblEmek2Adet.Text = pressTakip.Adet.ToString();
                    btnEmek2.BackColor = Color.Green;
                }
                else if (pressTakip.DurumId == 2)
                {
                    lblEmek2StokKodu.Text = "Press Durmuştur...";
                    lblEmek2StokAdi.Text = "Press Durmuştur...";
                    lblEmek2Operasyon.Text = "Press Durmuştur...";
                    lblEmek2Adet.Text = "Press Durmuştur...";
                    btnEmek2.BackColor = Color.Red;
                }
                else
                {
                    lblEmek2StokKodu.Text = "Kalıp Değişimi...";
                    lblEmek2StokAdi.Text = "";
                    lblEmek2Operasyon.Text = "";
                    lblEmek2Adet.Text = "";
                    btnEmek2.BackColor = Color.Blue;
                }
            }
            catch (Exception)
            {
                lblEmek2StokKodu.Text = "Press Durmuştur...";
                lblEmek2StokAdi.Text = "Press Durmuştur...";
                lblEmek2Operasyon.Text = "Press Durmuştur...";
                lblEmek2Adet.Text = "Press Durmuştur...";
            }
        }

        private void Karakaya()
        {
            try
            {
                PressTakip pressTakip = _PressTakipDal.UrunListele().FindLast(p => p.PressId == 32);
                if (pressTakip.DurumId == 1)
                {
                    lblKarakayaStokKodu.Text = pressTakip.StokKodu;
                    lblKarakayaStokAdi.Text = pressTakip.StokAdi;
                    lblKarakayaOperasyon.Text = pressTakip.Operasyon;
                    lblKarakayaAdet.Text = pressTakip.Adet.ToString();
                    btnKarakaya.BackColor = Color.Green;
                }
                else if (pressTakip.DurumId == 2)
                {
                    lblKarakayaStokKodu.Text = "Press Durmuştur...";
                    lblKarakayaStokAdi.Text = "";
                    lblKarakayaOperasyon.Text = "";
                    lblKarakayaAdet.Text = "";
                    btnKarakaya.BackColor = Color.Red;
                }
                else
                {
                    lblKarakayaStokKodu.Text = "Kalıp Değişimi...";
                    lblKarakayaStokAdi.Text = "";
                    lblKarakayaOperasyon.Text = "";
                    lblKarakayaAdet.Text = "";
                    btnKarakaya.BackColor = Color.Blue;
                }
            }
            catch (Exception)
            {
                lblKarakayaStokKodu.Text = "Press Durmuştur...";
                lblKarakayaStokAdi.Text = "";
                lblKarakayaOperasyon.Text = "";
                lblKarakayaAdet.Text = "";
            }
        }

        private void Emek3()
        {
            try
            {
                PressTakip pressTakip = _PressTakipDal.UrunListele().FindLast(p => p.PressId == 37);
                if (pressTakip.DurumId == 1)
                {
                    lblEmek3StokKodu.Text = pressTakip.StokKodu;
                    lblEmek3StokAdi.Text = pressTakip.StokAdi;
                    lblEmek3Operasyon.Text = pressTakip.Operasyon;
                    lblEmek3Adet.Text = pressTakip.Adet.ToString();
                    btnEmek3.BackColor = Color.Green;
                }
                else if (pressTakip.DurumId == 2)
                {
                    lblEmek3StokKodu.Text = "Press Durmuştur...";
                    lblEmek3StokAdi.Text = "";
                    lblEmek3Operasyon.Text = "";
                    lblEmek3Adet.Text = "";
                    btnEmek3.BackColor = Color.Red;
                }
                else
                {
                    lblEmek3StokKodu.Text = "Kalıp Değişimi...";
                    lblEmek3StokAdi.Text = "";
                    lblEmek3Operasyon.Text = "";
                    lblEmek3Adet.Text = "";
                    btnEmek3.BackColor = Color.Red;
                }
            }
            catch (Exception)
            {
                lblEmek3StokKodu.Text = "Press Durmuştur...";
                lblEmek3StokAdi.Text = "";
                lblEmek3Operasyon.Text = "";
                lblEmek3Adet.Text = "";
            }
        }
    }
}
