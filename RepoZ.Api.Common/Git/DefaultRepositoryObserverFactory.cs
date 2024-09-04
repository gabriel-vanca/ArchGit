using RepoZ.Api.Git;

namespace RepoZ.Api.Common.Git
{
    public class DefaultRepositoryObserverFactory : IRepositoryObserverFactory
    {
        public IRepositoryObserver Create() => new DefaultRepositoryObserver();
    }
}
