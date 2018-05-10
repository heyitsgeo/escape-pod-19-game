using Assets.Scripts.Controllers;
using Assets.Scripts.Interactions.Abstracts;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Interactions.Reactions.DelayedReactions
{
    public class LostItemReaction : DelayedReaction
    {
        [SerializeField]
        private ItemModel _item;
        public ItemModel Item
        {
            get { return _item; }
            set { _item = value; }
        }

        private InventoryController _inventoryController;

        protected override void SpecificInit()
        {
            _inventoryController = FindObjectOfType<InventoryController>();
        }

        protected override void ImmediateReaction()
        {
            _inventoryController.RemoveItem(_item);
        }
    }
}
