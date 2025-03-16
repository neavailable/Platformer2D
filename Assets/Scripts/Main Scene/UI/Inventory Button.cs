using UnityEngine;


namespace MainScene.UI
{
    public class InventoryButton : OpenButton
    {
        [SerializeField] private GameObject _shopButton;


        public override void Open()
        {
            base.Open();
            
            _shopButton.SetActive(!ShouldOpen);
            Time.timeScale = ShouldOpen ? 0f : 1f;
        }
    }
}