namespace OrthoGraph
{
    public class Matrix
    {
        protected float[,] _data {get; private set;} = new float[1,1];

        public Matrix(float[,] data)
        {
            _data = data;
        }
        public Matrix(Vector3 v)
        {
            _data = new float[,] {{v.X, v.Y, v.Z}};
        }

        public Matrix(Quaternion q)
        {
            _data = new float[,] {
                {(1 - 2 * q.Y * q.Y - 2 * q.Z * q.Z), (2 * q.X * q.Y + 2 * q.Z * q.W), (2 * q.X * q.Z - 2 * q.Y * q.W)},
                {(2 * q.X * q.Y - 2 * q.Z * q.W), (1 - 2 * q.X * q.X - 2 * q.Z * q.Z), (2 * q.Y * q.Z + 2 * q.X * q.W)},
                {(2 * q.X * q.Z + 2 * q.Y * q.W), (2 * q.Y * q.Z - 2 * q.X * q.W), (1 - 2 * q.X * q.X - 2 * q.Y * q.Y)}
            };
        }

        public Vector3 ToVector3()
        {
            Vector3 resualt = new Vector3();
            if (_data.GetLength(0) > 0 && _data.GetLength(1) > 2)
            {
                resualt = new Vector3(_data[0,0], _data[0,1], _data[0, 2]);
            }
                return resualt;
        }

        public static Matrix operator * (Matrix a, Vector3 b)
        {
            if (a._data.GetLength(0) > 2)
                return new Matrix(new float[,] {{a._data[0,0] * b.X + a._data[0,1] * b.Y + a._data[0,2] * b.Z,
                                            a._data[1,0] * b.X + a._data[1,1] * b.Y + a._data[1,2] * b.Z,
                                            a._data[2,0] * b.X + a._data[2,1] * b.Y + a._data[2,2] * b.Z
                                            }});
            else
                return new Matrix(b);
        }         
    }
}