using UnityEngine;

namespace Rhythm
{
    [CreateAssetMenu(fileName = "NewNoteDefination", menuName = "Timeline/NoteDefination")]
    public class NoteDefination : ScriptableObject
    {
        [System.Serializable]
        public class RythmClipSetting
        {
            public Texture left;
            public Texture center;
            public Texture right;
            public Color color;
        }

        [SerializeField] private GameObject prefab;
        [SerializeField] private RythmClipSetting settings;

        public float preRollTime;

        public RythmClipSetting GetSettings()
        {
            return settings;
        }

        public GameObject GetNotePrefab()
        {
            return prefab;
        }
    }
}




