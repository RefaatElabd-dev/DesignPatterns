using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Actor
    {
        protected EventBrocker broker;
        public Actor(EventBrocker broker)
        {
            this.broker = broker ?? throw new ArgumentNullException(paramName: nameof(Actor.broker));
        }
    }

    public class FootballPlayer : Actor
    {
        public string Name { get; set; } = "Unknown Player";
        public int GoalsScores { get; set; } = 0;

        public void Score()
        {
            GoalsScores++;
            broker.Publish(new PlayerScoredEvent { Name = Name, GoalsScored = GoalsScores });
        }

        public void AssultReferee()
        {
            broker.Publish(new PlayerSentOffEvent { Name = Name, Reason = "violence" });
        }
        public FootballPlayer(EventBrocker broker, string name) : base(broker)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            broker.OfType<PlayerScoredEvent>().Where(ps => !ps.Name.Equals(name))
                .Subscribe(ps =>
                {
                    Console.WriteLine($"{name}: Nicely done, {ps.Name}! it's your {ps.GoalsScored} goal. ");
                });

            broker.OfType<PlayerSentOffEvent>()
                .Where(po => !po.Name.Equals(name))
                .Subscribe(ps =>
                {
                    Console.WriteLine($"{name}: see you in the lockers, {ps.Name}");
                });
        }
    }

    public class FootballCoach : Actor
    {
        public FootballCoach(EventBrocker broker) : base(broker)
        {
            broker.OfType<PlayerScoredEvent>()
                .Subscribe(pe =>
                {
                    if(pe.GoalsScored < 3)
                        Console.WriteLine($"Coach: well done, {pe.Name}");
                });

            broker.OfType<PlayerSentOffEvent>()
                .Subscribe(pe =>
                {
                    if(pe.Reason == "violence")
                        Console.WriteLine($"Coach: How could you, {pe.Name}.");
                });
        }
    }

    public class PlayerEvent
    {
        public string Name { get; set; }
    }

    public class PlayerScoredEvent: PlayerEvent
    {
        public int GoalsScored { get; set; }
    }


    public class PlayerSentOffEvent: PlayerEvent
    {
        public string Reason { get; set; }
    }

    public class EventBrocker : IObservable<PlayerEvent>
    {
        private Subject<PlayerEvent> subscriptions = new Subject<PlayerEvent>();
        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
            return subscriptions.Subscribe(observer);
        } 
        public void Publish(PlayerEvent pe)
        {
            subscriptions.OnNext(pe);
        }
    }
}
