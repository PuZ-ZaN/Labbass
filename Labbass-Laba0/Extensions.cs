using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labbass_Laba0
{
    public static class Extensions
    {
        public static Image Rescale(this Image source, Size newSize)
        {
            return new Bitmap(source, newSize);
        }

        public static T Choice<T>(this IList<T> source)
        {
            Random r = new Random();
            return source[r.Next(0, source.Count)];
        }

        public static Size RelevantResize(this Size template, float scaleX, float scaleY)
        {
            var scale = new Size();
            scale.Width = (int)(template.Width * scaleX);
            scale.Height = (int)(template.Height * scaleY);
            return scale;
        }

        public static Point RelevantPosition(this Size source, float offsetX, float offsetY)
        {
            var newPosition = new Point();
            newPosition.X = (int)(source.Width * offsetX);
            newPosition.Y = (int)(source.Height * offsetY);
            return newPosition;
        }

        public static Point RelevantPosition(this Point source, float offsetX, float offsetY)
        {
            var newPos = new Point();
            newPos.X = (int)(source.X * offsetX);
            newPos.Y = (int)(source.Y * offsetY);
            return newPos;
        }

    }
}
