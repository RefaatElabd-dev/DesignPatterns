using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Helpers
{
    internal class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Sahpe: Circle");
        }
    }
}
