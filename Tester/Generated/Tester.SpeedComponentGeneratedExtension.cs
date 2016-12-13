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

        public Tester.SpeedComponent speed { get { return (Tester.SpeedComponent)GetComponent(CoreComponentIds.Speed); } }
        public bool hasSpeed { get { return HasComponent(CoreComponentIds.Speed); } }

        public Entity AddSpeed(float newSpeed) {
            var component = CreateComponent<Tester.SpeedComponent>(CoreComponentIds.Speed);
            component.speed = newSpeed;
            return AddComponent(CoreComponentIds.Speed, component);
        }

        public Entity ReplaceSpeed(float newSpeed) {
            var component = CreateComponent<Tester.SpeedComponent>(CoreComponentIds.Speed);
            component.speed = newSpeed;
            ReplaceComponent(CoreComponentIds.Speed, component);
            return this;
        }

        public Entity RemoveSpeed() {
            return RemoveComponent(CoreComponentIds.Speed);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherSpeed;

        public static IMatcher Speed {
            get {
                if(_matcherSpeed == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Speed);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherSpeed = matcher;
                }

                return _matcherSpeed;
            }
        }
    }
