using RepoZ.Api.Git;
using System.Collections.Generic;

namespace Specs.Mocks
{
    internal class UselessRepositoryStore : IRepositoryStore
    {
        public IEnumerable<string> Get() => new string[0];

        public void Set(IEnumerable<string> paths)
        {
        }
    }
}