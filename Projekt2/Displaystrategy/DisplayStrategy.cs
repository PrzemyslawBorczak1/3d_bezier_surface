using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public interface IDisplayStrategy
    {
        public StrategyType Type { get; }
        public void Draw(Surface surface, Graphics g);

    }
    public enum StrategyType
    {
        None = 0,
        DrawFilled = 1,
        Mesh = 2,
        ControlNet = 4,
    }


    public static class DisplayStrategy
    {

        private static StrategyType strategies = StrategyType.DrawFilled | StrategyType.ControlNet;


        public static void AddStrategy(IDisplayStrategy strategy)
        {
            strategies |= strategy.Type;
        }

        public static void RemoveStrategy(IDisplayStrategy strategy)
        {
            strategies &= ~strategy.Type;
        }


        public static void DrawAll(Surface surface, Graphics g)
        {
            g.Clear(Color.Black);


            if (strategies.HasFlag(StrategyType.DrawFilled))
            {
                DrawFilled.GetInstance().Draw(surface, g);
            }


            if (strategies.HasFlag(StrategyType.Mesh))
            {
                Mesh.GetInstance().Draw(surface, g);
            }


            if (strategies.HasFlag(StrategyType.ControlNet))
            {
                ControlNet.GetInstance().Draw(surface, g);

            }
        }
    }
}

