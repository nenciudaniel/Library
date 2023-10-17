namespace Library.Business.Services.Interfaces
{
    public interface IHttpContextAcessorService
    {
        string GetName();

        string GetSurname();

        string GetUsername();

        string GetRole();

        bool IsAdmin();
    }
}
