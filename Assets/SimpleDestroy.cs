using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
public class SimpleDestroy : MonoBehaviour
{
  protected Transform _transform;

  protected virtual void Awake ()
  {
    _transform = GetComponent<Transform> ();
    GetComponent<Collider> ().isTrigger = true;
  }

  private void OnTriggerEnter (Collider other)
  {
    var neck = false;
    MonoBehaviour[] components = other.GetComponents<MonoBehaviour> ();
    foreach (MonoBehaviour component in components) {
      Breakable splitable = component as Breakable;
      if (splitable != null) {
        neck = true;
        Destroy (component.gameObject);
      }
    }
    if(neck) {
      Destroy (gameObject);
    }
  }
}

