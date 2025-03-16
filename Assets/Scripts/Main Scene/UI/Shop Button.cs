using UnityEngine;


namespace MainScene.UI
{
    public class ShopButton : OpenButton
    {
        [SerializeField] private GameObject _inventoryButton;


        public override void Open()
        {
            base.Open();
            
            _inventoryButton.SetActive(!ShouldOpen);
            Time.timeScale = ShouldOpen ? 0f : 1f;
        }
    }	
}