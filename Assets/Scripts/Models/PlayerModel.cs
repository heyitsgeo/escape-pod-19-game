namespace Assets.Scripts.Models
{
    using System;
    using UnityEngine;

    [Serializable]
    public class PlayerModel
    {
        [SerializeField]
        private int _playerSpeed;
        public int PlayerSpeed
        {
            get { return _playerSpeed; }
            set { _playerSpeed = value; }
        }

        [SerializeField]
        private bool _facingUp;
        public bool FacingUp
        {
            get { return _facingUp; }
            set { _facingUp = value; }
        }

        [SerializeField]
        private bool _facingRight;
        public bool FacingRight
        {
            get { return _facingRight; }
            set { _facingRight = value; }
        } 
    }
}

