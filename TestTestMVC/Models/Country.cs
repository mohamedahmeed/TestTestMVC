using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTest
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string countryName { get; set; }

        public virtual List<Region> Regions { get; set; }

    }
}
