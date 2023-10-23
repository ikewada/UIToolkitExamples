using UnityEngine;
 
namespace UIToolkitExamplesC
{
    [CreateAssetMenu(fileName = "CardDefinition", menuName = "CardDefinition", order = 0)]
    public class CardDefinition : ScriptableObject
    {
        public string characterName;
        public string description;
        public Texture2D thumbnail;
    }
}
