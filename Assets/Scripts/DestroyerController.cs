
using UnityEngine;

public class DestroyerController : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col){
    Destroy(col.gameObject);
   }
}
