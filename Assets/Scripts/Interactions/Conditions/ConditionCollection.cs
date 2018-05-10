namespace Assets.Scripts.Interactions.Conditions
{
    using Assets.Scripts.Controllers;
    using UnityEngine;

    public class ConditionCollection
    {
        public string description;
        public Condition[] requiredConditions = new Condition[0];
        public ReactionController reactionController;

        public bool CheckAndReact()
        {
            for (int i = 0; i < requiredConditions.Length; i++)
            {
                if (!AllConditions.CheckCondition(requiredConditions[i]))
                    return false;
            }

            if (reactionController)
                reactionController.React();

            return true;
        }
    }
}
