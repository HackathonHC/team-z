using UnityEngine;
using System.Collections;

public class Mino : MonoBehaviour
{
  float[] c = { 1f, 0.5f, 0.75f };
  // Use this for initialization
  void Start ()
  {
    foreach (var r in GetComponentsInChildren<MeshRenderer>()) {
      if (Random.Range (0f, 1f) > 0.0f) {
        r.gameObject.AddComponent<Breakable>();
        r.material.color = new Color(c[Random.Range(0,2)],c[Random.Range(0,2)],c[Random.Range(0,2)]);
      }
    }
  }

  void FixedUpdate() {
    gameObject.rigidbody.velocity = new Vector3 (gameObject.rigidbody.velocity.x, gameObject.rigidbody.velocity.y, 0);

  }
  // Update is called once per frame
  void Update ()
  {
    if(transform.childCount > 20) {
      Destroy (gameObject);
    }
    if(transform.position.y < -100) {
      Destroy (gameObject);      
    }
    if(transform.position.y > 1) {
      Application.LoadLevel (transform.parent.name);
    }
  }
}
