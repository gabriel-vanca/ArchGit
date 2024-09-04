using System;

namespace RepoZ.Api.Common
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
