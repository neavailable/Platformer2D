using UnityEngine;


namespace MainScene.UI
{
    public abstract class OpenButton : MonoBehaviour
    {
        protected bool ShouldOpen { get; private set; }

        [SerializeField] private GameObject _openObject;


        private void Start()
        {
            ShouldOpen = false;
        }

        public virtual void Open()
        {
            ShouldOpen = !ShouldOpen;

            _openObject.SetActive(ShouldOpen);
        }
    }
}
