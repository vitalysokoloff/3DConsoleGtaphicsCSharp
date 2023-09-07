namespace OrthoGraph
{
    public class App
    {
        Graphics graphics;
        Entity [] entities;

        public App()
        {
            graphics = new Graphics(120, 30);
            entities = new Entity[] {
                new Square(new Vector3(8, 7, 1), 16, '.'),
                new Cube(new Vector3(35, 7, 1), 16, ':')
            };
            entities[0].Rotate(new Vector3(1, 0, 1), CalculateAngle(0.3f));
            entities[1].Rotate(new Vector3(1, 0, 1), CalculateAngle(-0.85f)); 
        }
        
        public void Start()
        {            
            Thread drawing = new Thread(new ThreadStart(Draw));
            Thread updating = new Thread(new ThreadStart(Update)); 

            drawing.Start();
            updating.Start();
        }

        public void Draw()
        {                      
            graphics.Begin();
            for (int i = 0; i < entities.Length; i++)
                entities[i].Draw(graphics.Context);
            Thread.Sleep(32); 
            graphics.End();
            Draw();
        }

        public void Update()
        { 
            entities[0].Rotate(new Vector3(1, 0, 1), CalculateAngle(0.05f));
            entities[1].Rotate(new Vector3(1, 0, 1), CalculateAngle(-0.03f));              
            Thread.Sleep(32);
            Update();
        }

        public static float CalculateAngle(float sum)
        {
            if (sum == 6.283f)
                sum = 0;

            if (sum > 6.283f)
                sum = CalculateAngle(sum - 6.283f);
            if (sum < 0f)
                sum = CalculateAngle(6.283f + sum);

            return sum;
        }
    }
}