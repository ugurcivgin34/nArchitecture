namespace Core.Persistence.Repositories;

public interface IQuery<T>
{

    //Kendi sorgularımızı yazabildiğimiz , store producure lerimizi çalıştırabileceğimiz yapıları 
    //yapabiliriz IQueryable sayesinde.Bu yapıyı o yüzden oluşturduk.
    IQueryable<T> Query();
}