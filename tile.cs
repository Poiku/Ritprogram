using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //important

namespace Ritprogram
{
    class tile
    {
        float xpos;
        float ypos;
        Color borderColor = Color.LightGray;
        Color fillColor = Color.Red;
        bool drawFilled = false;


        public tile(float x, float y)
        {
            xpos = x;
            ypos = y;
        }

        public float getX
        {
            get { return xpos; }
        }
        public float getY
        {
            get { return ypos; }
        }

        public Color BorderColor
        {
            get { return borderColor; }
        }

        public Color FillColor
        {
            get { return fillColor; }
        }

        public bool DrawFilled
        {
            get { return drawFilled; }
        }

        public bool registerClick(int hitX, int hitY, bool isLeftClick)
        {
            //kanske ersätta diameter med variabel sen
            //tile x and y pos is top left, add 1/2 of diameter to both sides to get midpoint
            double tileMidPointX = xpos + (9 / 2);
            double tileMidPointY = ypos + (9 / 2);

            double diffX = hitX - tileMidPointX;
            double diffY = hitY - tileMidPointY;
            double diffSum = diffX * diffX + diffY * diffY;
            double distance = Math.Sqrt(diffSum);

            //kanske ersätta diameter med variabel sen
            if(distance <= (9 / 2))
            {
                //determine color or erase
                if (!isLeftClick)
                {
                    fillColor = SystemColors.Control;
                }
                else
                {
                    fillColor = Color.Red;
                }

                drawFilled = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void drawTile()
        {

        }
    }
}
