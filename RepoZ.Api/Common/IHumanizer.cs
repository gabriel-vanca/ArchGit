using System;

namespace RepoZ.Api.Common
{
    public interface IHumanizer
    {
        string HumanizeTimestamp(DateTime value);
    }
}
