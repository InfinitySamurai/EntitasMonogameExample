using Entitas;
using System.Collections.Generic;

namespace Tester{
    public class HandleCollisionSystem : IReactiveSystem, ISetPool{

        Pool pool;

        public void Execute(List<Entity> entities) {
            foreach(var e in entities) {
                var eSelf = e.collide.self;
                var eOther = e.collide.other;

                eSelf.RemoveCollide();
                pool.CreateEntity().AddPoints(1);
            }
        }

        public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.Collide).OnEntityAdded(); } }

        void ISetPool.SetPool(Pool pool){
            this.pool = pool;
        }
    }
}
