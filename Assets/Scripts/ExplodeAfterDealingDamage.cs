using UnityEngine;

namespace DefaultNamespace
{
  public class ExplodeAfterDealingDamage : MonoBehaviour
  {
    public GameObject explosion = null;

    public void Event_Explode()
    {
      if (explosion != null)
      {
        var obj = Instantiate(explosion);
        obj.transform.position = this.transform.position;
        obj.transform.rotation = this.transform.rotation;
      }

      Destroy(this.gameObject);
    }

  }
}