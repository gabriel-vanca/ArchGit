using RepoZ.Api.IO;
using System;
using System.IO;

namespace RepoZ.Api.Common.Git
{
    public class DefaultRepositoryStore : FileRepositoryStore
    {
        public DefaultRepositoryStore(IErrorHandler errorHandler, IAppDataPathProvider appDataPathProvider)
            : base(errorHandler)
        {
            AppDataPathProvider = appDataPathProvider ?? throw new ArgumentNullException(nameof(appDataPathProvider));
        }

        public override string GetFileName() => Path.Combine(AppDataPathProvider.GetAppDataPath(), "Repositories.cache");

        public IAppDataPathProvider AppDataPathProvider { get; }
    }
}