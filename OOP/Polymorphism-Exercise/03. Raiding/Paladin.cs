

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int Power = 100;
        public Paladin(string name) 
            : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {Power}";
        }
    }
}
