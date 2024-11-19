using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace bazy_samochody
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Picture { get; set; }

    }
}
