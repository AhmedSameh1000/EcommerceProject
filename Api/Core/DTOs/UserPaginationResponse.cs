﻿using Api.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class UserPaginationResponse
    {

        public List<UserDto> Users { get; set; }
        public int currentPage { get; set; }

        public int PageCount { get; set; }

        public int ProductsCount { get; set; }
        public double itemsPerPage { get; set; }
    }
}

