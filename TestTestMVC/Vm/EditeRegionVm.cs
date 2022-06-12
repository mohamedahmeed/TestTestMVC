using System.Collections.Generic;
using TestTest;

namespace TestTestMVC.Vm
{
    public class EditeRegionVm
    {
        public int Id { get; set; }
        public string regionName { get; set; }
        public int countryId { get; set; }
        
        public List<Country> countries { get; set; }


    }
    
}
