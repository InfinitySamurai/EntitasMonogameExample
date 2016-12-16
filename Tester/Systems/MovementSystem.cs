using Entitas;
using System;
using System.Collections.Generic;

namespace Tester {
    public class MovementSystem : IReactiveSystem{

        public void Execute(List<Entity> entities)
        {
            foreach(Entity e in entities) {
                var velocity = e.velocity;
                var position = e.position;

                e.ReplacePosition(position.x + velocity.x, position.y + velocity.y);
            }
        }

        public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.Position, CoreMatcher.Velocity).OnEntityAdded(); } }
    }
}
