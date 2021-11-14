using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType
{
    public class Person :ICloneable
    {
        public readonly string[] Names;
        public readonly Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public object Clone()
        {
            return new Person((string[])Names.Clone(), (Address)Address.Clone());
        }

        public override string ToString()
        {
            return $"Name is : {string.Join(' ', Names)}, and Address is {Address}";
        }

    }

    public class Address : ICloneable
    {
        public readonly string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"StreetName: {StreetName}, HouseNumber: {HouseNumber}"; 
        }
    }
}
