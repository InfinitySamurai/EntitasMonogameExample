using Entitas;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Tester{
    class UpdateBoundingBoxSystem : IReactiveSystem {

        public void Execute(List<Entity> entities) {
            foreach(var e in entities) {
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

        public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.Position, CoreMatcher.View, CoreMatcher.BoundingBox).OnEntityAdded(); } }
    }
}
