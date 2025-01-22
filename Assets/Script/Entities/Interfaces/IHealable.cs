namespace Entities.Interfaces
{
    public interface IHealable
    {
        public int Restore(int heal, int currentHealth);
    }
}