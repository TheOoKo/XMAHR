using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class PersonalData
    {
        public PersonalDivisionSection personalDivisionSection { get; set; }
        public List<Division> divisionData { get; set; }
        public List<Section> sectionData { get; set; }
    }
}
