using Entitas;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Tester {
    public class ViewRenderSystem : IExecuteSystem, ISetPool{
        Group group;
        SpriteBatch spriteBatch;

        public ViewRenderSystem(SpriteBatch sb, Dictionary<string, Texture2D> content) {
            this.spriteBatch = sb;
        }

        public SpriteBatch SpriteBatch
        {
            set { spriteBatch = value; }
        }

        public void Execute() {
            foreach (var e in group.GetEntities()) {
                var position = e.position;
                var view = e.view;
                spriteBatch.Draw(view.sprite, new Vector2(position.x, position.y));
            }
        }

        public void SetPool(Pool pool) {
            group = pool.GetGroup(Matcher.AllOf(CoreMatcher.Position, CoreMatcher.View));
        }
    }
}
