

namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int Power = 80;
        public Druid(string name) 
            : base(name, Power)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {Power}";
        }
    }
}
