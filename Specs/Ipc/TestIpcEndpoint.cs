using RepoZ.Ipc;

namespace Specs.Ipc
{
    class TestIpcEndpoint : IIpcEndpoint
    {
        public string Address => "tcp://localhost:18182";
    }
}
