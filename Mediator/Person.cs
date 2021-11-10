using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Person
    {
        public string Name;
        public ChatRoom Room;
        public List<string> chatLog = new List<string>();


        public Person(string name)
        {
            Name = name;
        }

        public void Say(string message)
        {
            Room.BroadCast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.message(Name, who, message);
        }

        public void Receive(string sender, string message)
        {
            string s = $"{sender}: '{message}'";
            chatLog.Add(s);
            Console.WriteLine($"[{Name}'s chat session] {s}");
        }
    }
}
