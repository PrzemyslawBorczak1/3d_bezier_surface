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
        static List<IDisplayStrategy> strategies = new List<IDisplayStrategy> {  TriangleNet.GetInstance(), Shadow.GetInstance()};



        public static void UpdateStrategy(IDisplayStrategy strategy)
        {
            if (strategies.Remove(strategy))
                return;

            strategies.Add(strategy);
        }

        public static void DrawAll(Surface surface, Graphics g)
        {
            // TODO
            g.Clear(Color.LightBlue);

            Updater.UpdateSurface(surface);
            foreach (var strategy in strategies)
            {
                strategy.Draw(surface,  g);
            }

        }
    }
}
