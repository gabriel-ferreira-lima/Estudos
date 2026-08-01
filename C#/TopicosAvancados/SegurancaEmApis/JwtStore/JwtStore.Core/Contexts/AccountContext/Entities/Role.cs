using JwtStore.Core.Contexts.SharedContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtStore.Core.Contexts.AccountContext.Entities {
    public class Role : Entity{
        public string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new List<User>();
    }
}
