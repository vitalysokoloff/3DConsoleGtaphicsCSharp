namespace OrthoGraph
{
    public class Vector3
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator + (Vector3 a, Vector3 b)
        {
            return new Vector3 { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }

        public static Vector3 operator - (Vector3 a, Vector3 b)
        {
            return new Vector3 { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z};
        }
    }
}