namespace Core.Security.Enums;

public enum AuthenticatorType
{
    None = 0,  //Kullanıcı direk email ve password ile authecantion olacak
    Email = 1, //email platformunu kullnarak sadece olacak
    Otp = 2
}