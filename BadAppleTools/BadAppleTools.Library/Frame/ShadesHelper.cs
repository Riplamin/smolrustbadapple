using System;
using System.Collections.Generic;
using System.Text;

namespace BadAppleTools.Library.Frame
{
    public static class ShadesHelper
    {
        private static Dictionary<Shades, ShadeRange>
            shadeRanges = new Dictionary<Shades, ShadeRange>()
            {
                { Shades.Black, new ShadeRange { MinimumValue = 0.0f,  MaximumValue = 0.28f } },
                { Shades.Gray,  new ShadeRange { MinimumValue = 0.28f, MaximumValue = 0.3f } },
                { Shades.White, new ShadeRange { MinimumValue = 0.3f,  MaximumValue = 1.0f } },
            };

        private static Shades GetShadeFromIntensity(float intensity)
        {
            bool lessThan;
            bool moreThan;
            foreach (var shadeRangeKv in shadeRanges)
            {
                lessThan = intensity < shadeRangeKv.Value.MinimumValue;
                moreThan = intensity > shadeRangeKv.Value.MaximumValue;

                if (!lessThan && !moreThan)
                {
                    return shadeRangeKv.Key;
                }
            }
            return Shades.Black;
        }

        private class ShadeRange
        {
            public float MinimumValue { get; set; }
            public float MaximumValue { get; set; }
        }
    }
}
