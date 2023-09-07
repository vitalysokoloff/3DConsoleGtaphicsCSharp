namespace OrthoGraph
{
    public class Square : Entity
    {
        public Square(Vector3 position, float size, char texture) : base (position, size, texture)
        {
            _texture = texture;
            _verties = new Vector3[4];
            _verties[0] = new Vector3(position.X, position.Y, position.Z);
            _verties[1] = new Vector3(position.X + size, position.Y,  position.Z);
            _verties[2] = new Vector3(position.X + size, position.Y + size,  position.Z);
            _verties[3] = new Vector3(position.X, position.Y + size,  position.Z);
            _center = new Vector3(position.X + size / 2 , position.Y + size / 2, 0);
        }

        public override void Draw(GraphicsContext context)
        {
            for (int i = 0; i < _verties.Length - 1; i++)
                context.DrawLine(_texture, _verties[i], _verties[i + 1]);
            context.DrawLine(_texture, _verties[_verties.Length - 1], _verties[0]);
        }
    }
}