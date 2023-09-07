namespace OrthoGraph
{
    public class GraphicsContext
    {
        public char[] PixelBuffer { get; protected set;}
        public int Width { get; }
        public int Height { get; }
        public Matrix Projection {get; set;}
        public float Aspect { get; } // соотношение сторон консоли
        public float PixelAspect { get; set;} // соотношение размера символа

        public GraphicsContext(int width, int height)
        {
            Width = width;
            Height = height;
            PixelBuffer = new char[Width * Height];
            Projection = new Matrix(new float[,]{
                                    {1, 0, 0},
                                    {0, 1, 0},
                                    {0, 0, 0}
                                    }); // Плоскость x-y
            Aspect = (float)width / height;
            PixelAspect = 8.0f / 16.0f;
        }

        public void Reset()
        {
            PixelBuffer = new char[Width * Height];
        }

        public void DrawLine(char texture, Vector3 va, Vector3 vb)
        {
            va = (Projection * va).ToVector3();
            vb = (Projection * vb).ToVector3(); 
 
            float vx = va.X == 0? va.Y : va.X;
            float vy = va.Y == 0? va.Z : va.Y;
            Point a = new Point((int)(vx * Aspect * PixelAspect), (int)vy);

            vx = vb.X == 0? vb.Y : vb.X;
            vy = vb.Y == 0? vb.Z : vb.Y;
            Point b = new Point((int)(vx  * Aspect * PixelAspect), (int)vy); 


            //https://ru.wikipedia.org/wiki/Алгоритм_Брезенхэма
            //https://ru.wikibooks.org/wiki/Реализации_алгоритмов/Алгоритм_Брезенхэма

            int deltaX = Math.Abs(b.X - a.X);
            int deltaY = Math.Abs(b.Y - a.Y);
            int signX = Sign(b.X - a.X);
            int signY = Sign(b.Y - a.Y);
            int error = deltaX - deltaY;
            int coor = b.X + b.Y * Width;
            
            if (coor < PixelBuffer.Length && coor > 0)
                PixelBuffer[b.X + b.Y * Width] = texture;
            int x = a.X, y = a.Y;
            
            while (x != b.X || y != b.Y)
            {
                coor = x + y * Width;
                if (coor < PixelBuffer.Length && coor > 0)
                    PixelBuffer[coor] = texture;
                int error2 = error * 2;
                if (error2 > -deltaY)
                {
                    error -= deltaY;
                    x += signX;
                }
                if (error2 < deltaX)
                {
                    error += deltaX;
                    y += signY;
                }
            }

            int Sign(int x)
            {
                return (x > 0) ? 1 : (x < 0) ? -1 : 0;
            }
        }
    }
}