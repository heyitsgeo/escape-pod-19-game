namespace Assets.Scripts.Controllers
{
    using Assets.Scripts.Models;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class InventoryController : MonoBehaviour
    {
        public Image[] ItemImages = new Image[NumItemSlots];
        public ItemModel[] Items = new ItemModel[NumItemSlots];

        public const int NumItemSlots = 4;

        public void AddItem(ItemModel itemToAdd)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                var item = Items[i];

                if (item == null)
                {
                    item = itemToAdd;
                    return;
                }
            }
        }
    }
}
