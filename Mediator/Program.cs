using System;
using Autofac;

namespace Mediator
{
    class Program
    {
        static void Main1(string[] args)
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

        static void Main(string[] args)
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<EventBrocker>().SingleInstance();
            cb.RegisterType<FootballCoach>();
            cb.Register((c, p) => new FootballPlayer(
                c.Resolve<EventBrocker>(),
                p.Named<string>("name")
                ));

            using (var c = cb.Build())
            {
                var coach = c.Resolve<FootballCoach>();

                var player1 = c.Resolve<FootballPlayer>(new NamedParameter("name", "John"));
                var player2 = c.Resolve<FootballPlayer>(new NamedParameter("name", "Cris"));

                player1.Score();
                player1.Score();
                player1.Score();
                player1.Score();

                player1.AssultReferee();

                player2.Score();
            }
        }
    }
}
