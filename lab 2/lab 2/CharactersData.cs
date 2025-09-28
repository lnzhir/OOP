using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Common;


namespace lab_2
{
    /*[Table("nonplayers")]
    public class NonPlayers
    {
        [PrimaryKey, Identity, NotNull] public int id { get; set; }
        [Column, NotNull] public string Name { get; set; }
        [Column, NotNull] public int Health { get; set; }
        [Column, NotNull] public string Role { get; set; }
        [Column, NotNull] public int Attitude { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    [Table("PlayerCharacter")]
    public class Players
    {
        [PrimaryKey, Identity, NotNull] public int id { get; set; }
        [Column, NotNull] public string Name { get; set; }
        [Column, NotNull] public int Health { get; set; }
        [Column, NotNull] public int Level { get; set; }
        [Column, NotNull] public int Experience { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }*/


    public class DBProvider : LinqToDB.Data.DataConnection
    {
        private static DBProvider db = new DBProvider();
        public DBProvider DB
        {
            get { return db; }
        }

        private ITable<NonPlayerCharacter> nonplayers() 
        {
            return this.GetTable<NonPlayerCharacter>();
        }

        private ITable<PlayerCharacter> players()
        {
            return this.GetTable<PlayerCharacter>();
        }


        private DBProvider() : base("CharactersData")
        {
        }

        public static List<PlayerCharacter> GetPlayers()
        {
            var query = from p in db.players() select p;
            return query.ToList();
        }

        public static List<NonPlayerCharacter> GetNonPlayers()
        {
            var query = from p in db.nonplayers() select p;
            return query.ToList();
        }

        public static PlayerCharacter GetPlayerWithId(int id)
        {
            var query = from p in db.players() where p.id == id select p;
            return query.ToList()[0];
        }

        public static NonPlayerCharacter GetNonPlayerWithId(int id)
        {
            var query = from p in db.nonplayers() where p.id == id select p;
            return query.ToList()[0];
        }

        public static void AddPlayer(string name, int health)
        {
            var player = new PlayerCharacter(name, health);
        }

        public static void AddNonPlayer(string name, int health)
        {
            var npc = new NonPlayerCharacter(name, health);
            //db.nonplayers().Append(npc);
        }

        public static void AddPlayer(PlayerCharacter pc)
        {
            db.players()
                .Value(p => p.Name, pc.Name)
                .Value(p => p.Health, pc.Health)
                .Value(p => p.Level, pc.Level)
                .Value(p => p.Experience, pc.Experience)
                .Insert();
        }

        public static void AddNonPlayer(NonPlayerCharacter npc)
        {
            db.nonplayers()
                .Value(p => p.Name, npc.Name)
                .Value(p => p.Health, npc.Health)
                .Value(p => p.Role, npc.Role)
                .Value(p => p.Attitude, npc.Attitude)
                .Insert();
        }

        public static void DeletePlayer(PlayerCharacter player)
        {
            db.players().Where(p => p.id == player.id).Delete();
        }

        public static void DeleteNonPlayer(NonPlayerCharacter npc)
        {
            db.nonplayers().Where(p => p.id == npc.id).Delete();
        }

        public static void ChangePlayer(PlayerCharacter player)
        {
            db.players().Where(p => p.id == player.id)
            .Set(p => p.Name, player.Name)
            .Set(p => p.Health, player.Health)
            .Set(p => p.Level, player.Level)
            .Set(p => p.Experience, player.Experience)
            .Update();
        }

        public static void ChangeNonPlayer(NonPlayerCharacter npc)
        {
            db.nonplayers().Where(p => p.id == npc.id)
            .Set(p => p.Name, npc.Name)
            .Set(p => p.Health, npc.Health)
            .Set(p => p.Role, npc.Role)
            .Set(p => p.Attitude, npc.Attitude)
            .Update();
        }
    }
}