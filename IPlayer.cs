using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2_may_18
{
    internal interface IPlayer
    {
        Guid Id { get; }
        string Name { get; set; }
        string Email { get; set; }
    }
}
