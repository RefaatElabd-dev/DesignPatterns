using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Helpers
{
    internal abstract class ShapeDecorator : IShape
    {
        protected IShape decoratoredShape;
        public ShapeDecorator(IShape decoratoredShape)
        {
            this.decoratoredShape = decoratoredShape;
        }
        public virtual void Draw()
        {
            decoratoredShape.Draw();
        }
    }
}
