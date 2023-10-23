using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitExamplesC
{
    public class Card : VisualElement
    {
        private Label m_characterName;
        private Label m_description;
        private VisualElement m_thumbnail;

        public new class UxmlFactory : UxmlFactory<Card, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            public UxmlAssetAttributeDescription<CardDefinition> _card = new() { name = "card-definition" };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                if (_card.TryGetValueFromBag(bag, cc, out CardDefinition value))
                {
                    var card = ve as Card;
                    card.m_characterName.text = value.characterName;
                    card.m_description.text = value.description;
                    card.m_thumbnail.style.backgroundImage = value.thumbnail;
                }
            }
        }

        public Card()
        {
            var treeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI Toolkit/Card.uxml");
            var container = treeAsset.Instantiate();
            hierarchy.Add(container);

            m_characterName = container.Q<Label>("Name");
            m_description = container.Q<Label>("Description");
            m_thumbnail = container.Q<VisualElement>("Thumbnail");

            var card = container.Q<VisualElement>("Root");
            card.AddManipulator(new Clickable(()=>Debug.Log("Click")));
        }
    }
}

