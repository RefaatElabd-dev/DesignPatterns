using System;

namespace ProtoType
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Clonable
            //Clonable
            //Person Refaat = new Person(new[] { "Refaat", "Elabd"}, new Address("AbuAli", 123));

            //Person Mohammed = (Person)Refaat.Clone();

            //Mohammed.Names[0] = "Mohamed";
            //Mohammed.Names[1] = "Khalid";
            //Mohammed.Address.HouseNumber = 365;

            //Console.WriteLine(Refaat);
            //Console.WriteLine(Mohammed);
            #endregion

            #region copy Constructors
            // copy Constructors
            //person Refaat = new person(new[] { "Refaat", "Elabd" }, new address("AbuAli", 123));

            //person Mohammed = new person(Refaat);

            //Mohammed.Names[0] = "Mohamed";
            //Mohammed.Names[1] = "Khalid";
            //Mohammed.Address.HouseNumber = 365;

            //Console.WriteLine(Refaat);
            //Console.WriteLine(Mohammed);
            #endregion

            #region interface
            //IProtoType interface
            //ProtoTypePerson Refaat = new ProtoTypePerson(new[] { "Refaat", "Elabd" }, new ProtoTypeAddress("AbuAli", 123));

            //ProtoTypePerson Mohammed = Refaat.DeepCopy();

            //Mohammed.Names[0] = "Mohamed";
            //Mohammed.Names[1] = "Khalid";
            //Mohammed.Address.HouseNumber = 365;

            //Console.WriteLine(Refaat);
            //Console.WriteLine(Mohammed);
            #endregion

            #region extention methods
            //use Extention Methods
            Person4 Refaat = new Person4(new[] { "Refaat", "Elabd" }, new Address4("AbuAli", 123));

            Person4 Mohammed = Refaat.DeepCopyXML();

            Mohammed.Names[0] = "Mohamed";
            Mohammed.Names[1] = "Khalid";
            Mohammed.Address.HouseNumber = 365;

            Console.WriteLine(Refaat);
            Console.WriteLine(Mohammed);
            #endregion
        }
    }
}
