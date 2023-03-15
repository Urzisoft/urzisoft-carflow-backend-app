using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrzisoftCarflowBackendApp.Entities
{
    public class Gas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Quality { get; set; }
        public double Price { get; set; }
    }
}
