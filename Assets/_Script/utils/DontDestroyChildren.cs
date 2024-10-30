using UnityEngine;
public class DontDestroyChildren : MonoBehaviour
{
   private void Awake() {
      var go = FindObjectOfType<DontDestroyChildren>();
      if(go != this) 
      {
         Destroy(gameObject);
      }
      DontDestroyOnLoad(this.gameObject);
   }
}
