namespace Assets.Scripts.Controllers
{
    using Assets.Scripts.Interactions.Abstracts;
    using UnityEngine;

    public class ReactionController : MonoBehaviour
    {
        public Reaction[] reactions = new Reaction[0];

        private void Start()
        {
            for (int i = 0; i < reactions.Length; i++)
            {
                DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

                if (delayedReaction)
                    delayedReaction.Init();
                else
                    reactions[i].Init();
            }
        }


        public void React()
        {
            for (int i = 0; i < reactions.Length; i++)
            {
                DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

                if (delayedReaction)
                    delayedReaction.React(this);
                else
                    reactions[i].React(this);
            }
        }
    }
}
