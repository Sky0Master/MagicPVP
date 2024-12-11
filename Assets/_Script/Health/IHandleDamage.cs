
namespace VinoUtility.Gameplay
{
    public interface IHandleDamage
    {
        public float CalculateDamage(float damage);
        public int Priority();
    }
}