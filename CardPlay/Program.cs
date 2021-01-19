using CardPlay.Utility;
using System;
using Unity;

namespace CardPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            // Dependencies registrations.
            Util.RegisterTypes(container);

            // Let Unity resolve DeckPlayer and create a build plan.
            var program = container.Resolve<DeckPlayer>();
            program.Start();
        }
    }
}
