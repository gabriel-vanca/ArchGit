using RepoZ.Api.Common;
using System;

namespace Specs
{
    internal class DirectThreadDispatcher : IThreadDispatcher
    {
        public void Invoke(Action act) => act();
    }
}