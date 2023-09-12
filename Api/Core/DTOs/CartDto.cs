using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CartDto
    {
        public IEnumerable<cartItem> CartItems { get; set; }

        public double cartTotal { get; set; }

        public int piecesCount { get; set; }
    }

}
