using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace lab_2
{
    public enum Attitude : int
    {
        Friend = 0,
        Enemy = 1
    }


    public abstract class Character
    {
        [PrimaryKey, Identity, NotNull] public int id { get; set; }
        [Column, NotNull] public string Name { get; set; }
        [Column, NotNull] public int Health { get; set; }
        [NotColumn] public string Message { get; protected set; }

        protected Character(string name, int health)
        {
            this.Name = name;
            this.Health = health;
        }

        public void Heal()
        {
            Message = String.Format("{0} healed", Name);
        }

        public void Spawn()
        {
            Message = String.Format("{0} spawned", Name);
        }

        public override string ToString()
        {
            return Name;
        }

        public abstract void Death();

        public abstract void Sleep(int hours);
    }


    //[Table("\"NonPlayerCharacters\"")]
    public class NonPlayerCharacter : Character
    {
        [Column, NotNull] public string Role { get; set; }
        [Column, NotNull] public int Attitude { get; set; }


        private NonPlayerCharacter() : base("", 0)
        {
            Attitude = 0;
            Role = "Citizen";
        }

        public NonPlayerCharacter(string name, int health) : base(name, health)
        {
            Attitude = 0;
            Role = "Citizen";
        }

        public NonPlayerCharacter(int id, string name, int health, string role, int attitude) : base(name, health)
        {
            this.Role = role;
            this.Attitude = attitude;
        }

        // собственные

        public void Say(string what)
        {
            Message = String.Format("{0} sais {1}", Name, what);
        }

        public void Panic()
        {
            Message = String.Format("{0} panics", Name);
        }

        // переопределенные

        public override void Death()
        {
            Message = String.Format("{0} died", Name);
        }

        public override void Sleep(int hours)
        {
            Message = String.Format("{0} sleps {1} hours", Name, hours);
        }
    }

    //[Table("\"PlayerCharacters\"")]
    public class PlayerCharacter : Character
    {
        private int level = 1;
        private int experience = 0;

        [Column, NotNull]
        public int Level { 
            get { return level; }
            set { level = value; }
        }
        [Column, NotNull]
        public int Experience { 
            get { return experience; } 
            set { experience = value; }
        }

        private PlayerCharacter() : base("", 0)
        {

        }

        public PlayerCharacter(string name, int health) : base(name, health)
        {
        }

        public PlayerCharacter(int id, string name, int health, int level, int experience) : base(name, health)
        {
            this.id = id;
            this.level = level;
            this.experience = experience;
        }

        // собственные

        public void LevelUp()
        {
            level++;
            Message = String.Format("{0} leveled up to {1}", Name, level);
        }

        public void AddExperience(int value)
        {
            Message = String.Format("{0} gived {1} exps", Name, value);

            experience += value;
            int maxExp = level * 1000;
            int n = 0;
            while (experience >= maxExp)
            {
                n++;
                level++;
                experience -= maxExp;
                maxExp = level * 1000;
            }
            if (n > 0)
            {
                Message = String.Format("{0}\n{} leveled up to {1}", Message, Name, level);
            }
        }

        // переопределенные

        public override void Death()
        {
            Message = String.Format("{0} died\nGame over", Name);
        }

        public override void Sleep(int hours)
        {
            Message = String.Format("{0} sleps {1} hours", Name, hours);
        }
    }
}
