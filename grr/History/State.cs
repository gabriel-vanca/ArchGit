using RepoZ.Ipc;

namespace grr.History
{
    public class State
    {
        public Repository[] LastRepositories { get; set; }

        public bool OverwriteRepositories { get; set; }

        public string LastLocation { get; set; }
    }
}
