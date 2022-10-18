using System;
using System.Collections.Generic;
using System.Text;

namespace BadAppleTools.Library.Frame
{
    public enum Shades
    {
        Black = 0,
        Gray = 1,
        White = 2
    }

    public static class ShadesExtensions
    {
        private static Dictionary<Shades, float>
            shadeIntensities = new Dictionary<Shades, float>() {
                { Shades.Black, 0.0f },
                { Shades.Gray,  0.6f },
                { Shades.White, 1.0f }
            };

        public static float GetIntensity(this Shades shade)
        {
            return shadeIntensities[shade];
        }
    }
}
