namespace Assets.Scripts.Models
{
    using UnityEngine;

    [CreateAssetMenu]
    public class ItemModel
    {
        [SerializeField]
        private Sprite _itemSprite;
        public Sprite ItemSprite
        {
            get { return _itemSprite; }
            set { _itemSprite = value; }
        }
    }
}
