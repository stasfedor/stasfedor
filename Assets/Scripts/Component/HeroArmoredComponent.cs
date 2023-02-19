using UnityEngine;
using PlayerScripts;

namespace Components
{
    public class HeroArmoredComponent : MonoBehaviour
    {
        public void ArmHero(GameObject go)
        {
            var hero = go.GetComponent<PlayerAnimationScript>();
            if (hero != null)
            {
                if (!hero._isArmed)
                {
                    hero.ArmHero();
                    Destroy(gameObject);
                }
            }
        }
    }

 
}