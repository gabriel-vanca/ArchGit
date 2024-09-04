using RepoZ.Api.Common;
using System;

namespace Tests.Common
{
    public class FakeClock : IClock
    {
        public FakeClock(DateTime fakeValue)
        {
            FakeValue = fakeValue;
        }

        public DateTime Now => FakeValue;

        public DateTime FakeValue { get; }
    }
}
