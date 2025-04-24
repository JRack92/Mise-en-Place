using MiseEnPlace.Core.Entities;

namespace MiseEnPlace.Core.Interfaces
{
    public interface IMachineState
    {
        void Handle(Entities.Machinery m);
    }
}
