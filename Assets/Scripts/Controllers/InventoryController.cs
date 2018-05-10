namespace Assets.Scripts.Controllers
{
    using Assets.Scripts.Models;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class InventoryController : MonoBehaviour
    {
        public Image[] ItemImages = new Image[NumItemSlots];
        public ItemModel[] Items = new ItemModel[NumItemSlots];

        public const int NumItemSlots = 5;

        public void AddItem(ItemModel itemToAdd)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                var item = Items[i];

                if (item == null)
                {
                    item = itemToAdd;
                    ItemImages[i].sprite = itemToAdd.sprite;
                    ItemImages[i].enabled = true;
                    return;
                }
            }
        }

        public void RemoveItem(ItemModel itemToRemove)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                var item = Items[i];

                if (item == itemToRemove)
                {
                    Items[i] = null;
                    item.sprite = null;
                    ItemImages[i].sprite = null;
                    ItemImages[i].enabled = false;
                    return;
                }
            }
        }
    }
}
