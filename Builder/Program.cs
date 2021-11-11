using System;

namespace Builder
{
    class Program
    {
        static void Main0(string[] args)
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world");
            Console.WriteLine(builder.ToString()); 
        }

        static void Main(string[] args)
        {
            var builder = new PersonBuilder();
            Person person =  builder
                   .Lives
                         .At("Ahmed Elzomor St.")
                         .In("NasrCity")
                         .WithPostCode("31418")
                   .Works.At("National Technology")
                         .ASA(".Net Developer")
                         .Earns(48000);

            Console.WriteLine(person);
        }
    }
}
