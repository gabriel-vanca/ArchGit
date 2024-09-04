using System;

namespace RepoZ.Api.Common
{
    public interface IThreadDispatcher
    {
        void Invoke(Action act);
    }
}
