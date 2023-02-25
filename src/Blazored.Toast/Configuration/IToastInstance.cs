namespace Blazored.Toast.Configuration;

public interface IToastInstance
{
     Guid Id { get; }
    public void Close();
}
