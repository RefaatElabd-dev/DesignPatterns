// See https://aka.ms/new-console-template for more information
using Decorator.Helpers;

IShape circle = new Circle();
IShape redCircle = new RedShapeDecorator(circle);
IShape redRectangle = new RedShapeDecorator(new Rectangle());
Console.WriteLine("Shapes With Normal Colors:");
circle.Draw();
Console.WriteLine("\nShapes With Red Colors:");
redCircle.Draw();
redRectangle.Draw();


