using UnityEngine;


namespace Enemy
{
    public class EnemyKilling : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Player.Player>
                    (out Player.Player player))
            {   
                player.Suicide();
            }
        }
    }	
}