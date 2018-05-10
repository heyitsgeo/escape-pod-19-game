namespace Assets.Scripts.Controllers
{
    using Assets.Scripts.Interactions.Conditions;
    using UnityEngine;

    public class InteractionController : MonoBehaviour
    {
        public Transform interactionLocation;
        public ConditionCollection[] conditionCollections = new ConditionCollection[0];
    
        public ReactionController defaultReactionController;


        public void Interact()
        {
            for (int i = 0; i < conditionCollections.Length; i++)
            {
                if (conditionCollections[i].CheckAndReact())
                    return;
            }

            defaultReactionController.React();
        }
    }
}
