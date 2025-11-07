using UnityEngine;
using UnityEngine.UI;

namespace Rhythm
{
    public class NoteBase : MonoBehaviour
    {
        [SerializeField] private GameObject outLine;
        [SerializeField] private float duration;

        protected virtual void Action()
        {

        }
    }
}

