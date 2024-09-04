using System;

namespace RepoZ.Api.Common
{
    public class SystemClock : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}
