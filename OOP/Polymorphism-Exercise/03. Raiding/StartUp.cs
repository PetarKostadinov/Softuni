using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int num = int.Parse(Console.ReadLine());

            while (num != 0)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                BaseHero hero = null;

                if (type == nameof(Druid))
                {
                    hero = new Druid(name);
                }
                else if (type == nameof(Paladin))
                {
                    hero = new Paladin(name);
                }
                else if (type == nameof(Rogue))
                {
                    hero = new Rogue(name);
                }
                else if (type == nameof(Warrior))
                {
                    hero = new Warrior(name);
                }

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heroes.Add(hero);


                num--;
            }
            int bossPower = int.Parse(Console.ReadLine());

            int sumHeroesPoer = heroes.Sum(x => x.Power);

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (sumHeroesPoer >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
