using System.Collections.Generic;

namespace RepoZ.Api.Git
{
    public interface IRepositoryStore
    {
        IEnumerable<string> Get();

        void Set(IEnumerable<string> paths);
    }
}
