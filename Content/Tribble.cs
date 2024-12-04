using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame___Animation_with_Classes
{
    public class Tribble
    {
        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed;

        public Tribble(Texture2D texture, Rectangle rectangle, Vector2 speed)
        {
            _texture = texture;
            _rectangle = rectangle;
            _speed = speed;
        }

        public Texture2D Texture
        {
            get { return _texture; }

        }
        public Rectangle Rectangle 
        {
            get { return _rectangle; }
        }

        public Vector2 Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public void Move (Rectangle window)
        {
            _rectangle.Offset(_speed);

            if (_rectangle.Right >= window.Width || _rectangle.Left <= 0)
                _speed.X *= -1;
            if (_rectangle.Top <= 0 || _rectangle.Bottom >= window.Height)
                _speed.Y *= -1;
        }
    }
}
