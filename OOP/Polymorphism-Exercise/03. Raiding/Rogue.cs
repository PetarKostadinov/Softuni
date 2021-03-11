

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int Power = 80;
        public Rogue(string name) 
            : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {Power} damage";
        }
    }
}
