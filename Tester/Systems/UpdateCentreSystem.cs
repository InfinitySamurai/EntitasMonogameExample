using Entitas;
using System;
using System.Collections.Generic;

namespace Tester {
    public class UpdateCentreSystem : IReactiveSystem{

        public void Execute(List<Entity> entities) {
            foreach(var e in entities) {
                var centre = e.centre;
                var position = e.position;
                var view = e.view;

                centre.x = position.x + 0.5f * view.sprite.Width;
                centre.y = position.y + 0.5f * view.sprite.Height;
                e.ReplaceCentre(centre.x, centre.y);
            }
        }

        public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.Position, CoreMatcher.Centre, CoreMatcher.View).OnEntityAdded(); } }
    }
}
