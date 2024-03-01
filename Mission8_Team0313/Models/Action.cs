using System;
using System.Collections.Generic;

namespace Mission8_Team0313.Models;

public partial class Action
{
    public int TaskId { get; set; }

    public string Task { get; set; } = null!;

    public DateOnly? DueDate { get; set; }

    public int Quadrant { get; set; }

    public int Completed { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
