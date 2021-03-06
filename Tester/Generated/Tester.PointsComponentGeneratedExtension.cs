//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

namespace Entitas {

    public partial class Entity {

        public Tester.PointsComponent points { get { return (Tester.PointsComponent)GetComponent(CoreComponentIds.Points); } }
        public bool hasPoints { get { return HasComponent(CoreComponentIds.Points); } }

        public Entity AddPoints(int newPoints) {
            var component = CreateComponent<Tester.PointsComponent>(CoreComponentIds.Points);
            component.points = newPoints;
            return AddComponent(CoreComponentIds.Points, component);
        }

        public Entity ReplacePoints(int newPoints) {
            var component = CreateComponent<Tester.PointsComponent>(CoreComponentIds.Points);
            component.points = newPoints;
            ReplaceComponent(CoreComponentIds.Points, component);
            return this;
        }

        public Entity RemovePoints() {
            return RemoveComponent(CoreComponentIds.Points);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherPoints;

        public static IMatcher Points {
            get {
                if(_matcherPoints == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Points);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherPoints = matcher;
                }

                return _matcherPoints;
            }
        }
    }
