


namespace Assets.Scripts.Interactions.Reactions.DelayedReactions
{
    using Assets.Scripts.Controllers;
    using Assets.Scripts.Interactions.Abstracts;
    using Assets.Scripts.Models;

    public class PickedUpItemReaction : DelayedReaction
    {
        public ItemModel _item;               // The item asset to be added to the Inventory.

        private InventoryController _inventoryController;    // Reference to the Inventory component.


        protected override void SpecificInit()
        {
            _inventoryController = FindObjectOfType<InventoryController>();
        }


        protected override void ImmediateReaction()
        {
            _inventoryController.AddItem(_item);
        }
    }
}
