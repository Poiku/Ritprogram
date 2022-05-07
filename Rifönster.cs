using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ritprogram
{
    public partial class Rifönster : Form
    {
        /*
         * notes: det går att veta om en tile
         * är iklickad eller inte, gör nu så 
         * att den fylls med en speciell färg om
         * det händer.
         */
        int rows = 50;
        int columns = 50;
        int amountOfTiles = 2500; //rows * columns
        tile[] tileGrid = new tile[2500];

        public Rifönster()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generateTiles();
        }

        private void generateTiles()
        {
            int counter = 0;
            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    tile newTile = new tile(10 * c, 10 * r);
                    tileGrid[counter] = newTile;
                    counter++;
                }
            }
        }

        private void drawTiles(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            for (int i = 0; i < amountOfTiles; i++)
            {
                Pen pen = new Pen(tileGrid[i].BorderColor);
                SolidBrush brush = new SolidBrush(tileGrid[i].FillColor);

                //graphics.FillRectangle(brush, (10 * c) + 1  , (10 * r) + 1, 9, 9);
                if (tileGrid[i].DrawFilled)
                {
                    graphics.FillRectangle(brush, tileGrid[i].getX + 1, tileGrid[i].getY + 1, 9, 9);
                }
                graphics.DrawRectangle(pen, tileGrid[i].getX, tileGrid[i].getY, 10, 10);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            bool isLeftClick = true;
            if (e.Button == MouseButtons.Right)
            {
                isLeftClick = false;
            }
            for (int i = 0; i < amountOfTiles; i++)
            {
                if (tileGrid[i].registerClick(e.X, e.Y, isLeftClick))
                {
                    Invalidate();
                    break;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawTiles(e);
            /*
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.LightGray);
            SolidBrush brush = new SolidBrush(Color.Red);

            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    graphics.DrawRectangle(pen, 10 * c, 10 * r, 10, 10);
                    //graphics.FillRectangle(brush, (10 * c) + 1  , (10 * r) + 1, 9, 9);
                }
            }
            */

        }
    }
}
