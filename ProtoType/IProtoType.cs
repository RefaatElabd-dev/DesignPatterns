using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType
{
    public interface IProtoType<T>
    {
        T DeepCopy();
    }
    public class ProtoTypePerson: IProtoType<ProtoTypePerson>
    {
        public readonly string[] Names;
        public readonly ProtoTypeAddress Address;

        public ProtoTypePerson(string[] names, ProtoTypeAddress address)
        {
            Names = names;
            Address = address;
        }

        public ProtoTypePerson DeepCopy()
        {
            return new ProtoTypePerson(Names.ToArray(), Address.DeepCopy());
        }

        public override string ToString()
        {
            return $"Name is : {string.Join(' ', Names)}, and Address is {Address}";
        }

    }


    public class ProtoTypeAddress: IProtoType<ProtoTypeAddress>
    {
        public readonly string StreetName;
        public int HouseNumber;

        public ProtoTypeAddress(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public ProtoTypeAddress DeepCopy()
        {
            return new ProtoTypeAddress(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"StreetName: {StreetName}, HouseNumber: {HouseNumber}";
        }
    }

}
