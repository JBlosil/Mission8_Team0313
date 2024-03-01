using System;
using System.Collections.Generic;

namespace Mission8_Team0313.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Category1 { get; set; } = null!;

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();
}
