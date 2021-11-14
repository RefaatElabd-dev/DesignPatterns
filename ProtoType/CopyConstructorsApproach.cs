using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProtoType
{
    public class person
    {
        public readonly string[] Names;
        public readonly address Address;

        public person(string[] names, address address)
        {
            Names = names;
            Address = address;
        }
        public person(person other)
        {
            Names = other.Names.ToArray();
            Address = new address(other.Address);
        }

        public override string ToString()
        {
            return $"Name is : {string.Join(' ', Names)}, and Address is {Address}";
        }

    }

    public class address
    {
        public readonly string StreetName;
        public int HouseNumber;

        public address(address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"StreetName: {StreetName}, HouseNumber: {HouseNumber}";
        }
    }
}
