using Entitas;
using Microsoft.Xna.Framework;

namespace Tester{
    class UpdateBoundingBoxSystem : IExecuteSystem, ISetPool {
        Group group;

        public void Execute() {
            foreach(var e in group.GetEntities()) {
                var position = e.position;
                var width = e.view.sprite.Width;
                var height = e.view.sprite.Height;
                var boundingBox = e.boundingBox;

                int x = (int)position.x;
                int y = (int)position.y;

                boundingBox.box = new Rectangle(x, y, width, height);
                e.ReplaceBoundingBox(boundingBox.box);

            }
        }

        public void SetPool(Pool pool) {
            group = pool.GetGroup(Matcher.AllOf(CoreMatcher.BoundingBox, CoreMatcher.Position, CoreMatcher.View));
        }
    }
}
