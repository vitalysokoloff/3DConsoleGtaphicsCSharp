namespace OrthoGraph
{
    public class Graphics
    {
        public GraphicsContext Context { get; }

        //protected StreamWriter _output;

        public Graphics(int width, int height)
        {
            //_output = new StreamWriter(Console.OpenStandardOutput());
            Context = new GraphicsContext(width, height);
            Context.Reset();
        }

        public void Begin()
        {
            Context.Reset();
            Console.SetCursorPosition(0,0);
        }

        public void End()
        {
           //_output.WriteLine(Context.PixelBuffer);
            //_output.Flush();
            Console.WriteLine(Context.PixelBuffer);
        }        
    }
}