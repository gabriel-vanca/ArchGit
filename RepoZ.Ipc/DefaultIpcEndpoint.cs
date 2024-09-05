namespace RepoZ.Ipc
{
<<<<<<< HEAD
	public class DefaultIpcEndpoint : IIpcEndpoint
	{
		public string Address => "tcp://localhost:18181";
	}
=======
    public class DefaultIpcEndpoint : IIpcEndpoint
    {
#if DEBUG
        public string Address => "tcp://localhost:18183";
#else
        public string Address => "tcp://localhost:18182";
#endif
    }
>>>>>>> 3895eb2 (Colours)
}