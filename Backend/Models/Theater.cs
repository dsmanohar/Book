﻿using System;
using System.Collections.Generic;

namespace BookMyShow.Models
{
    public partial class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
    }
}
