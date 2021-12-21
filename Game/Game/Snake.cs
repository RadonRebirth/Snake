using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Snake
    {
        private readonly ConsoleColor HeadColor;
        private readonly ConsoleColor BodyColor;

        public Snake(int initialX,
            int initialY,
            ConsoleColor headColor,
            ConsoleColor bodyColor,
            int bodylength = 3)
        {
            HeadColor = headColor;
            BodyColor = bodyColor;

            Head = new Pixel(initialX, initialY, HeadColor);

            for (int i = bodylength; i >= 0; i--)
            {
                Body.Enqueue(new Pixel(Head.X - i - 1, initialY, BodyColor));
            }
            Draw();
        }
        public Pixel Head { get; private set; }

        public Queue<Pixel> Body { get; } = new Queue<Pixel>();

        public void Move(Direction direction, bool eat = false)
        {
            Clear();

            Body.Enqueue(new Pixel(Head.X, Head.Y, BodyColor));

            if (!eat)
                Body.Dequeue();

            Head = direction switch
            {
                Direction.Right => new Pixel(Head.X + 1, Head.Y, HeadColor),
                Direction.Left => new Pixel(Head.X - 1, Head.Y, HeadColor),
                Direction.Up => new Pixel(Head.X, Head.Y - 1, HeadColor),
                Direction.Down => new Pixel(Head.X, Head.Y + 1, HeadColor),
                _ => Head
            };
            Draw();
        }

        public void Draw()
        {
            Head.Draw();

            foreach (Pixel pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();

            foreach (Pixel pixel in Body)
            {
                pixel.Clear();
            }
        }
    }
}
