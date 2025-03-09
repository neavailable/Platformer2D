using UnityEngine;


namespace Egg
{
    public class EggCollecting : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {                
            if (other.TryGetComponent<Player.Player>(out Player.Player _))
            {
                Suicide();
            }
        }

        private void Suicide()
        {
            Destroy(gameObject);
        }
    }	
}