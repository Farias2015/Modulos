using Modulos.IO.Domain.Core.Commands;
using Modulos.IO.Domain.Core.Events;
using System.Threading.Tasks;

namespace Modulos.IO.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Command;
    }
}
