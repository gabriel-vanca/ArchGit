using RepoZ.Ipc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specs.Ipc
{
<<<<<<< HEAD
	class TestIpcEndpoint : IIpcEndpoint
	{
		public string Address => "tcp://localhost:18182";
	}
}
=======
    class TestIpcEndpoint : IIpcEndpoint
    {

#if DEBUG
        public string Address => "tcp://localhost:18183";
#else
        public string Address => "tcp://localhost:18182";
#endif
    }
}
>>>>>>> 14dc727 (fixing the port debug issue)
