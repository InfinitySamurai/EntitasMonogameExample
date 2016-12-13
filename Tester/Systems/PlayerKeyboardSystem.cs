using Entitas;
using Microsoft.Xna.Framework.Input;
using System;

namespace Tester {
    public class PlayerKeyboardSystem : IExecuteSystem, ISetPool{
        Group group;

        public void Execute() {
            foreach (var e in group.GetEntities()) {
                
                var playerControlled = e.isPlayerController;
                var velocity = e.velocity;
                float speed = e.speed.speed;
                //velocity.x

                if(!playerControlled) {
                    continue;
                }

                var state = Keyboard.GetState();
                var left = state.IsKeyDown(Keys.Left);
                var right = state.IsKeyDown(Keys.Right);
                var up = state.IsKeyDown(Keys.Up);
                var down = state.IsKeyDown(Keys.Down);
                if(left) {
                    velocity.x = -speed;
                }
                else if(right) {
                    velocity.x = speed;
                }
                else {

                    velocity.x = 0;
                }

                if(up) {
                    velocity.y = -speed;
                }
                else if(down) {
                    velocity.y = speed;
                }
                else {
                    velocity.y = 0;
                }
                e.ReplaceVelocity(velocity.x, velocity.y);
            }
        }

        public void SetPool(Pool pool) {
            group = pool.GetGroup(Matcher.AllOf(CoreMatcher.Velocity, CoreMatcher.PlayerController, CoreMatcher.Speed));
        }
    }
}
