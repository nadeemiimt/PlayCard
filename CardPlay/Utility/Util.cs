using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using CardPlay.Implementation;
using CardPlay.Interface;
using log4net;
using log4net.Config;
using Unity;
using Unity.Lifetime;

namespace CardPlay.Utility
{
    public static class Util
    {
        /// <summary>
        /// Register dependencies.
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType(typeof(IApplicationLogger<>), typeof(ApplicationLogger<>), new TransientLifetimeManager());
            container.RegisterType<IDeck, Deck>();
            container.RegisterType<IDeckPlayer, DeckPlayer>();
        }
    }
}
