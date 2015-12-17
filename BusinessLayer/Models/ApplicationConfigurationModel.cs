using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class ApplicationConfigurationModel
    {
        public string ApplicationName { get; set; }
        public string AppGuid { get; set; }
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Value { get; set; }
        public string UserId { get; set; }
        public string IsEncrypted { get; set; }
        public string Name { get; set; }
    }
}
