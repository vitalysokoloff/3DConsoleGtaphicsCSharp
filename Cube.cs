namespace OrthoGraph
{
    public class Cube : Entity
    {
        public Cube(Vector3 position, float size, char texture) : base (position, size, texture)
        {
            _texture = texture;
            _verties = new Vector3[8];
            _verties[0] = new Vector3(position.X, position.Y, position.Z);
            _verties[1] = new Vector3(position.X + size, position.Y,  position.Z);
            _verties[2] = new Vector3(position.X + size, position.Y + size,  position.Z);
            _verties[3] = new Vector3(position.X, position.Y + size,  position.Z);
            _verties[4] = new Vector3(position.X, position.Y, position.Z + size);
            _verties[5] = new Vector3(position.X + size, position.Y,  position.Z + size);
            _verties[6] = new Vector3(position.X + size, position.Y + size,  position.Z + size);
            _verties[7] = new Vector3(position.X, position.Y + size,  position.Z + size);
            _center = new Vector3(position.X + size / 2 , position.Y + size / 2, position.Z + size / 2);
        }

        public override void Draw(GraphicsContext context)
        {
            context.DrawLine(_texture, _verties[0], _verties[1]);
            context.DrawLine(_texture, _verties[1], _verties[2]);
            context.DrawLine(_texture, _verties[2], _verties[3]);
            context.DrawLine(_texture, _verties[3], _verties[0]);
            context.DrawLine(_texture, _verties[4], _verties[5]);
            context.DrawLine(_texture, _verties[5], _verties[6]);
            context.DrawLine(_texture, _verties[6], _verties[7]);
            context.DrawLine(_texture, _verties[7], _verties[4]);
            context.DrawLine(_texture, _verties[0], _verties[4]);
            context.DrawLine(_texture, _verties[4], _verties[7]);
            context.DrawLine(_texture, _verties[7], _verties[3]);
            context.DrawLine(_texture, _verties[3], _verties[0]);
            context.DrawLine(_texture, _verties[1], _verties[5]);
            context.DrawLine(_texture, _verties[5], _verties[6]);
            context.DrawLine(_texture, _verties[6], _verties[2]);
            context.DrawLine(_texture, _verties[2], _verties[1]);
        }
    }
}