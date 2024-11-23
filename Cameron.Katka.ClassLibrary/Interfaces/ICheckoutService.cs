
namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface ICheckoutService
    {
        void Scan(string item);

        int GetTotalPrice();
    }
}
