using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitExamplesA
{
    public class Card : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<Card> { }

        public Card()
        {
            var treeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI Toolkit/Card.uxml");
            var container = treeAsset.Instantiate();
            hierarchy.Add(container);

            var card = container.Q<VisualElement>("Root");
            card.AddManipulator(new Clickable(() => Debug.Log("Click")));
        }
    }
}
