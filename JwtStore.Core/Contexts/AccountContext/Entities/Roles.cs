﻿using JwtStore.Core.Contexts.SharedContext.Entities;

namespace JwtStore.Core.Contexts.AccountContext.Entities;

public class Roles : Entity
{
    public string Name { get; set; } = string.Empty;

    public List<User> Users { get; set; } = [];
}
