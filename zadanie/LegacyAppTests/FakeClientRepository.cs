using LegacyApp;

namespace LegacyAppTests;

public class FakeClientRepository : IClientRepository
{
    public Client GetById(int clientId)
    {
        return new Client();
    }
}