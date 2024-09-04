using RepoZ.Api.IO;

namespace Specs.Mocks
{
    internal class NeverSkippingPathSkipper : IPathSkipper
    {
        public bool ShouldSkip(string path) => false;
    }
}
