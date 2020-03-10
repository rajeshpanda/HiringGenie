﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Models.DTOs
{
    public class BaseRequestDTO
    {
        public int Take { get; set; } = 100;

        public int Skip { get; set; } = 0;

        public string Search { get; set; }
    }
}
