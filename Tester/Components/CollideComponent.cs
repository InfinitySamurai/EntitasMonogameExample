using Entitas;
using Microsoft.Xna.Framework;

namespace Tester {
    [Core]
    public class CollideComponent : IComponent{
        public Entity self;
        public Entity other;
        public Rectangle collisionBox;
    }
}
