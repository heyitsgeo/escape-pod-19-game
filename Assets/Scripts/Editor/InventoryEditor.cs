namespace Assets.Scripts.Editor
{
    using UnityEngine;
    using UnityEditor;
    using Assets.Scripts.Controllers;

    [CustomEditor(typeof(InventoryController))]
    public class InventoryEditor : Editor
    {
        private bool[] showItemSlots = new bool[InventoryController.NumItemSlots];
        private SerializedProperty itemImagesProperty;
        private SerializedProperty itemsProperty;


        private const string inventoryPropItemImagesName = "ItemImages";
        private const string inventoryPropItemsName = "Items";


        private void OnEnable()
        {
            // Cache the SerializedProperties.
            itemImagesProperty = serializedObject.FindProperty(inventoryPropItemImagesName);
            itemsProperty = serializedObject.FindProperty(inventoryPropItemsName);
        }


        public override void OnInspectorGUI()
        {
            // Pull all the information from the target into the serializedObject.
            serializedObject.Update();

            // Display GUI for each Item slot.
            for (int i = 0; i < InventoryController.NumItemSlots; i++)
            {
                ItemSlotGUI(i);
            }

            // Push all the information from the serializedObject back into the target.
            serializedObject.ApplyModifiedProperties();
        }


        private void ItemSlotGUI(int index)
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUI.indentLevel++;

            // Display a foldout to determine whether the GUI should be shown or not.
            showItemSlots[index] = EditorGUILayout.Foldout(showItemSlots[index], "Item slot " + index);

            // If the foldout is open then display default GUI for the specific elements in each array.
            if (showItemSlots[index])
            {
                EditorGUILayout.PropertyField(itemImagesProperty.GetArrayElementAtIndex(index));
                EditorGUILayout.PropertyField(itemsProperty.GetArrayElementAtIndex(index));
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }
    }
}
