using System;
using Entitas;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tester {
    public class DrawScoreSystem : IExecuteSystem, ISetPool{
        Group group;
        SpriteBatch spriteBatch;

        public DrawScoreSystem(SpriteBatch sb) {
            spriteBatch = sb;
        }

        public void Execute() {
            foreach(Entity e in group.GetEntities()) {
                var text = e.text.text;
                var font = e.font.font;
                var score = e.score.score;
                var position = e.position;
                var pos = new Vector2(position.x, position.y);
                string display = text + score;

                spriteBatch.DrawString(font, display, pos, Color.White);
            }
        }

        public void SetPool(Pool pool) {
            group = pool.GetGroup(Matcher.AllOf(CoreMatcher.Text, CoreMatcher.Font, CoreMatcher.Score, CoreMatcher.Position));
        }
    }
}
