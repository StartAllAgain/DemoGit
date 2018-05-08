using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string Roles { get; set; }

        public List<Action> Action { get; set; }
    }
    public class Action
    {
        public int Id { get; set; }
        public string AcionName { get; set; }
    }
}