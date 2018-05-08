namespace Assets.Scripts.Models
{
    using System;

    [Serializable]
    public class PlayerModel
    {
        public int PlayerSpeed { get; set; }
        public bool FacingUp { get; set; }
        public bool FacingRight { get; set; } 
    }
}

