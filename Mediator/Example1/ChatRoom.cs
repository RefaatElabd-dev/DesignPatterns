using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator
{
    public class ChatRoom
    {
        List<Person> People;

        public ChatRoom()
        {
            People = new List<Person>();
        }

        public void join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            BroadCast("room", joinMsg);

            p.Room = this;
            People.Add(p);
        }

        public void BroadCast(string source, string joinMsg)
        {
            foreach (var P in People)
                if (P.Name != source)
                    P.Receive(source, joinMsg);
        }

        public void message(string source, string destination, string msg)
        {
            People.FirstOrDefault(p => p.Name == destination)
                ?.Receive(source, msg);
        }
    }
}