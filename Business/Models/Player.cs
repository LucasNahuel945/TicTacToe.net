using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Player
    {
        public int Id { get; init; }

        public Player(int id)
        {
            this.Id = id;
        }
    }
}
