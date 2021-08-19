using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HubEntities.Database {
    public class User {
        [Key]
        public string Email { get; set; }

        public List<Team> Teams { get; set; }
    }

}