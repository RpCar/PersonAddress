using Raven.Client.Documents;
using Raven.Embedded;

namespace AddressService.Infrastructure.DataBase
{
    public class RavenDbServer : IDisposable
    {
        private readonly IDocumentStore _store;

        public RavenDbServer()
        {
            EmbeddedServer.Instance.StartServer(new ServerOptions
            {
                DataDirectory = "RavenDB_Data",
                CommandLineArgs = { "--RunInMemory=true" }
            });

            _store = EmbeddedServer.Instance.GetDocumentStore(new DatabaseOptions("LocalDatabase"));
        }

        public IDocumentStore GetDocumentStore() => _store;

        public void Dispose()
        {
            _store?.Dispose();
            EmbeddedServer.Instance?.Dispose();
        }
    }
}
