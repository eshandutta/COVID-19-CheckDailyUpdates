using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Models
{
    public class CountryDetails
    {
        public string country { get; set; }
        public long cases { get; set; }
        public long todayCases { get; set; }
        public int deaths { get; set; }
        public int todayDeaths { get; set; }
        public long recovered { get; set; }
        public long active { get; set; }
        public long critical { get; set; }
        public int casesPerOneMillion { get; set; }
        public int deathsPerOneMillion { get; set; }
        public string firstCase { get; set; }
    }
}
