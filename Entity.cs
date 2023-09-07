namespace OrthoGraph
{
    public abstract class Entity
    {
       
        protected Vector3[] _verties;
        protected Vector3 _center;
        protected char _texture;

        public Entity(Vector3 position, float size, char texture)
        {
        }

        public void Rotate(Vector3 axis, float angle)
        {
            // Нужно привести координаты к началу координат, повернуть и вернуть обратно
            Matrix rotation = new Matrix(new Quaternion(axis, angle));
            for (int i = 0; i < _verties.Length; i++)
            {
                _verties[i] -= _center;
                _verties[i] = (rotation * _verties[i]).ToVector3(); 
                _verties[i] += _center;
            }
        }

        public abstract void Draw(GraphicsContext context);
    }    
}