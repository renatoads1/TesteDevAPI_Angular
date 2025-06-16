using TesteDev.Models;

namespace TesteDev.Services
{
    public interface ICdbCalculatorService
    {
        CdbResult Calcular(CdbRequest request);
    }
}
