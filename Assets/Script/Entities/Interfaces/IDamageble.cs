using Entities.Health;

namespace Entities.Interfaces
{
    public interface IDamageble
    {
        public void Deal(int damage, HealthBase health);
    }
}