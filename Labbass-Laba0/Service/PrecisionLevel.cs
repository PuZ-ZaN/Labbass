using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labbass_Laba0.Service
{
    public class PrecisionLevel
    {
        public double VirtualValue { get; private set; }
        public string TextValue { get; private set; }
        public double PixelOffset { get; private set; }

        public PrecisionLevel(string text, double pixOffset, double virtValue)
        {
            TextValue = text;
            PixelOffset = pixOffset;
            VirtualValue = virtValue;
        }

        public override string ToString()
        {
            return $"{TextValue} : {PixelOffset} pix per move";
        }

        public static PrecisionLevel Create(int value)
        {
            return ReturnPrecisionLevelByIntValue(value);
        }


        private static PrecisionLevel ReturnPrecisionLevelByIntValue(int value)
        {
            if (value < 0 || value > 3)
                throw new ArgumentOutOfRangeException($"Invalid prevision level");

            switch (value)
            {
                case 0:
                    return new PrecisionLevel("10 mm", 10, 10d);
                case 1:
                    return new PrecisionLevel("1 mm", 1, 1d);
                case 2:
                    return new PrecisionLevel("0.1 mm", 0.1, 0.1d);
                case 3:
                    return new PrecisionLevel("0.01 mm", 0.01, 0.01d);
            }
            return null;
        }
    }
}
