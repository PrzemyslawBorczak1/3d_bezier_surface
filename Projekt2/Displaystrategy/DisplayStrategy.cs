using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public interface IDisplayStrategy
    {
        public void Draw(Surface surface, Graphics g);

    }


    public static class DisplayStrategy
    {
        static List<IDisplayStrategy> strategies = new List<IDisplayStrategy> { ControlNet.GetInstance() , DrawFiledl.GetInstance() };



        public static void AddStrategy(IDisplayStrategy strategy)
        {
            if(strategies.Contains(strategy))
               return;
            strategies.Add(strategy);
        }

        public static void RemoveStrategy(IDisplayStrategy strategy)
        {
            strategies.Remove(strategy);
        }


        public static void DrawAll(Surface surface, Graphics g)
        {
            // TODO change backgorund
            g.Clear(Color.Black);

            Updater.UpdateSurface(surface);
            foreach (var strategy in strategies)
            {
                strategy.Draw(surface,  g);
            }

        }
    }
}
