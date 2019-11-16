namespace Marmota.Consul
{
    public interface IMarmotaConsul
    {
        void ServiceRegister();
        void ServiceDeregister();
    }
}
