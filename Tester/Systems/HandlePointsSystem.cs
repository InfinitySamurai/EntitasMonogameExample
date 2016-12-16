using Entitas;
using System.Collections.Generic;
using System;

namespace Tester {
    public class HandlePointsSystem : IReactiveSystem, ISetPool{

        Group group;

        public void Execute(List<Entity> entities) {
            var eScore = group.GetEntities()[0];
            var score = eScore.score.score;
            foreach(Entity e in entities) {
                score += e.points.points;
                e.RemovePoints();
            }
            eScore.ReplaceScore(score);
            Console.WriteLine(eScore.score.score);
        }

        public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.Points).OnEntityAdded(); } }

        void ISetPool.SetPool(Pool pool) {
            group = pool.GetGroup(Matcher.AllOf(CoreMatcher.Score));
        }

    }
}