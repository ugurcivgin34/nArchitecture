namespace Core.Persistence.Paging;

public class BasePageableModel
{
    public int Index { get; set; } //Kacıncı sayfadayım
    public int Size { get; set; } //Bir sayfada kaç data var
    public int Count { get; set; } //Toplamda kaç data var
    public int Pages { get; set; }//Toplamda kaç sayfa var
    public bool HasPrevious { get; set; } //Önceki sayfa var mı 
    public bool HasNext { get; set; } //Sonraki sayfa var mı
}