using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long SoftwareHouseId { get; set; }

        public Videogame(long id, string name, string overview, DateTime release_date, long softwarehouse_id) 
        { 
            Id = id;
            Name = name;
            Overview = overview;
            ReleaseDate = release_date;
            SoftwareHouseId = softwarehouse_id;
        }
    }
}
