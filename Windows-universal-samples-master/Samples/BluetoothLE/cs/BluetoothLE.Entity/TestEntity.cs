using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntity
{
    [Table("per_info")]
    class Person
    {
        [Column("id")]
        [PrimaryKey]
        [AutoIncrement()]
        public int ID { get; set; }

        [Column("name")]
        [NotNull]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("gender")]
        [NotNull]
        public string Gender { get; set; }
    }
}