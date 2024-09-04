using RepoZ.Api.IO;

namespace RepoZ.Api.Common.IO
{
    public class DefaultPathCrawlerFactory : IPathCrawlerFactory
    {
        private readonly IPathSkipper _pathSkipper;

        public DefaultPathCrawlerFactory(IPathSkipper pathSkipper)
        {
            _pathSkipper = pathSkipper;
        }

        public IPathCrawler Create() => new GravellPathCrawler(_pathSkipper);
    }
}
