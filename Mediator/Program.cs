using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatRoom room = new ChatRoom();

            Person Refaat = new("Refaat");
            Person Mazher = new("Mazher");
            Person AbdElrahman = new("Abdelrahman");

            room.join(Refaat);
            room.join(Mazher);

            Refaat.Say("hi");
            Mazher.Say("oh, hi Refaat");

            room.join(AbdElrahman);
            AbdElrahman.Say("hi everyone");

            Mazher.PrivateMessage("AbdElrahman", "glad you could join us!");

        }
    }
}
