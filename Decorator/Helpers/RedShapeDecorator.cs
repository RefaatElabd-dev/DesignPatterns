using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Helpers
{
    internal class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(IShape decoratoredShape): base(decoratoredShape)
        {  
        }

        public override void Draw()
        {
            setRedColor(decoratoredShape);
        }

        private void setRedColor(IShape decoratoredShape)
        {
           Console.ForegroundColor = ConsoleColor.Red;
           decoratoredShape.Draw();
           Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
