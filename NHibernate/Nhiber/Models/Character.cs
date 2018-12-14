using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Nhiber.Models
{
    public class Character
    {
        public Character() { }
        public Character(string nick, int level, int strength, int agility, int inteligence)
        {
            Nick = nick;
            Level = level;
            Strength = strength;
            Agility = agility;
            Inteligence = inteligence;
        }

        public virtual int ID { get; set; }
        public virtual string Nick { get; set; }
        public virtual int Level { get; set; }
        public virtual int Strength { get; set; }
        public virtual int Agility { get; set; }
        public virtual int Inteligence { get; set; }

    }

    public class CharacterMap : ClassMapping<Character>
    {
        public CharacterMap()
        {
            Id(x => x.ID, map => map.Generator(Generators.Native));
            Property(x => x.Nick);
            Property(x => x.Level);
            Property(x => x.Strength);
            Property(x => x.Agility);
            Property(x => x.Inteligence);

        }
    }
}