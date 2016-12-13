using Entitas;

namespace Tester {
    public class MovementSystem : IExecuteSystem, ISetPool{

        Group group;

        public void Execute()
        {
            foreach(Entity e in group.GetEntities()) {
                var velocity = e.velocity;
                var position = e.position;

                e.ReplacePosition(position.x + velocity.x, position.y + velocity.y);
            }
        }

        public void SetPool(Pool pool) {
            group = pool.GetGroup(Matcher.AllOf(CoreMatcher.Position, CoreMatcher.Velocity));
        }
    }
}
