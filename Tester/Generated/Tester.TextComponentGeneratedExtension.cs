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

        public Tester.TextComponent text { get { return (Tester.TextComponent)GetComponent(CoreComponentIds.Text); } }
        public bool hasText { get { return HasComponent(CoreComponentIds.Text); } }

        public Entity AddText(string newText) {
            var component = CreateComponent<Tester.TextComponent>(CoreComponentIds.Text);
            component.text = newText;
            return AddComponent(CoreComponentIds.Text, component);
        }

        public Entity ReplaceText(string newText) {
            var component = CreateComponent<Tester.TextComponent>(CoreComponentIds.Text);
            component.text = newText;
            ReplaceComponent(CoreComponentIds.Text, component);
            return this;
        }

        public Entity RemoveText() {
            return RemoveComponent(CoreComponentIds.Text);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherText;

        public static IMatcher Text {
            get {
                if(_matcherText == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Text);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherText = matcher;
                }

                return _matcherText;
            }
        }
    }
