class Ogrenci
{
    public int Numara;
    public string AdSoyad;
    public string Bolum;
    public int Yas;
    public Ogrenci Next; 

    public Ogrenci(int numara, string adSoyad, string bolum, int yas)
    {
        Numara = numara;
        AdSoyad = adSoyad;
        Bolum = bolum;
        Yas = yas;
        Next = null; // İlk başta yeni düğümün bağlantısı yok
    }
}
class OgrenciListesi
{
    private Ogrenci head; // Listenin başlangıç noktası

    // Öğrenci ekleme (Listenin sonuna ekler)
    public void Ekle(int numara, string adSoyad, string bolum, int yas)
    {
        Ogrenci yeniOgrenci = new Ogrenci(numara, adSoyad, bolum, yas);

        if (head == null)
        {
            head = yeniOgrenci;
            return;
        }

        Ogrenci temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = yeniOgrenci;
    }

    // Öğrenci listeleme
    public void Listele()
    {
        Ogrenci temp = head;
        if (temp == null)
        {
            Console.WriteLine("Liste boş!");
            return;
        }

        while (temp != null)
        {
            Console.WriteLine($"Numara: {temp.Numara}, Ad Soyad: {temp.AdSoyad}, Bölüm: {temp.Bolum}, Yaş: {temp.Yas}");
            temp = temp.Next;
        }
    }

    // Öğrenci arama (Numaraya göre)
    public Ogrenci Ara(int numara)
    {
        Ogrenci temp = head;
        while (temp != null)
        {
            if (temp.Numara == numara)
                return temp;
            temp = temp.Next;
        }
        return null;
    }

    // Öğrenci silme (Numaraya göre)
    public void Sil(int numara)
    {
        if (head == null)
        {
            Console.WriteLine("Liste boş, silinecek öğrenci yok!");
            return;
        }

        if (head.Numara == numara)
        {
            head = head.Next;
            Console.WriteLine($"Numara {numara} olan öğrenci silindi.");
            return;
        }

        Ogrenci temp = head;
        while (temp.Next != null && temp.Next.Numara != numara)
        {
            temp = temp.Next;
        }

        if (temp.Next == null)
        {
            Console.WriteLine("Öğrenci bulunamadı!");
            return;
        }

        temp.Next = temp.Next.Next;
        Console.WriteLine($"Numara {numara} olan öğrenci silindi.");
    }
}

class Program
{
    static void Main()
    {
        OgrenciListesi ogrenciListesi = new OgrenciListesi();

        // Öğrenci ekleme
        ogrenciListesi.Ekle(101, "Sena Safa", "Bilgisayar Mühendisliği", 21);
        ogrenciListesi.Ekle(102, "Hesna Safa", "Psikoloji", 22);
        ogrenciListesi.Ekle(103, "Yavuz Selim Uçar", "Polis", 21);

        Console.WriteLine("\nÖğrenci Listesi:");
        ogrenciListesi.Listele();

        // Arama
        Console.WriteLine("\nNumarası 102 olan öğrenciyi arıyoruz...");
        Ogrenci bulunan = ogrenciListesi.Ara(102);
        if (bulunan != null)
            Console.WriteLine($"Bulundu: {bulunan.AdSoyad}, Bölüm: {bulunan.Bolum}");
        else
            Console.WriteLine("Öğrenci bulunamadı!");

        // Silme
        Console.WriteLine("\nNumarası 102 olan öğrenciyi siliyoruz...");
        ogrenciListesi.Sil(102);

        Console.WriteLine("\nGüncellenmiş Öğrenci Listesi:");
        ogrenciListesi.Listele();
    }
}
