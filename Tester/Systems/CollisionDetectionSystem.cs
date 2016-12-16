using System;
using Entitas;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Tester {
    public class CollisionDetectionSystem : IReactiveSystem{

        public void Execute(List<Entity> entities) {
            int i,j;
            int length = entities.Count;
            for(i = 0; i < length; i++) {
                var e1 = entities[i];
                for (j = i+1; j < length; j++) {
                    var e2 = entities[j];
                    
                    if (!e1.Equals(e2)) {
                        Rectangle collisionBox = Rectangle.Intersect(e1.boundingBox.box, e2.boundingBox.box);
                        if(!collisionBox.IsEmpty) {
                            e1.AddCollide(e1, e2, collisionBox);
                        }
                    }
                }
            }
        }

        public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.BoundingBox).OnEntityAdded();
    }
}
    }
}
