using Entitas;

namespace Tester {
    public class UpdateCentreSystem : IExecuteSystem, ISetPool{

        Group group;

        public void Execute() {
            foreach(var e in group.GetEntities()) {
                var centre = e.centre;
                var position = e.centre;
                var view = e.view;

                centre.x = position.x + 0.5f * view.sprite.Width;
                centre.y = position.y + 0.5f * view.sprite.Height;

                e.ReplaceCentre(centre.x, centre.y);
            }
        }

        public void SetPool(Pool pool) {
            group = pool.GetGroup(Matcher.AllOf(CoreMatcher.Position, CoreMatcher.Centre, CoreMatcher.View));
        }
    }
}
