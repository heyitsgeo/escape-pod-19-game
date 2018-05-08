namespace Assets.Scripts.Models
{
    using System;
    using UnityEngine;

    [Serializable]
    public class LevelModel
    {
        [SerializeField]
        private string _sceneName;
        public string SceneName
        {
            get { return _sceneName; }
            set { _sceneName = value; }
        }
        [SerializeField]
        private string _levelName;
        public string LevelName
        {
            get { return _levelName; }
            set { _levelName = value; }
        }

        [SerializeField]
        private bool _locked;
        public bool Locked
        {
            get { return _locked; }
            set { _locked = value; }
        }
    }
}   
