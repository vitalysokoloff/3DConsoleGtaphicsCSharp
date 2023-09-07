namespace OrthoGraph
{
    public struct Quaternion
    {
        public float W {get;}
        public float X {get;}
        public float Y {get;}
        public float Z {get;}

        public Quaternion(Vector3 axis, float angle)
        {
            Vector3 rotateVector = Normal(axis);
            float Sin = (float)Math.Sin(angle / 2); 
            W = (float)Math.Cos(angle / 2);
            X = rotateVector.X * Sin;
            Y = rotateVector.Y * Sin;
            Z = rotateVector.Z * Sin;

            Vector3 Normal(Vector3 v)
            {
                float length = (float)Math.Sqrt(Math.Pow(v.X, 2) + Math.Pow(v.Y, 2) + Math.Pow(v.Z, 2));
                return new Vector3(axis.X / length, axis.Y / length, axis.Z / length); 
            }
        }
    }    
}