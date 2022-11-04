using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ujl_textpreview
{
    internal class Letter
    {
        private Rectangle rectangle = Rectangle.Empty;
        private int offset = 0;
        private int specialChar;

        public Rectangle L_Rectangle
        {
            get { return rectangle; }
        }
        public int L_Offset
        {
            get { return offset; }
        }
        public int L_SpecialChar
        {
            get { return specialChar; }
        }
        public Letter(int specialChar, Rectangle rectangle = new Rectangle(), int offset = 0)
        {
            this.rectangle = rectangle;
            this.offset = offset;
            this.specialChar = specialChar;
        }
    }
}
