using UnityEngine;
using System.Collections;

public class emitter : MonoBehaviour
{
  [SerializeField] private bool Controller;
  [SerializeField] private GameObject[] minos;
  private System.Random r;
  private int remain = 100;
  private int cur_remain = 120;
  private GameObject target;

  void Start ()
  {
    Application.targetFrameRate = 60;
    r = new System.Random (Main.Seed);
  }
	
  IEnumerator C() {
    while (true) {

      float[] c = { 1f, 0.5f, 0.75f };
      RenderSettings.ambientLight = new Color (c [Random.Range (0, 2)], c [Random.Range (0, 2)], c [Random.Range (0, 2)]);
      yield return new WaitForSeconds (1f);
    }
  }
  // Update is called once per frame
  void Update ()
  {

    if (remain-- == 0) {
      remain = Mathf.Max(35,cur_remain--);
      Spawn ();
    }

    if (target != null) {
      if(!Controller && Input.GetKey(KeyCode.A)) {
        target.rigidbody.AddForce (Vector3.left*30);
      }
      if(!Controller && Input.GetKey(KeyCode.D)) {
        target.rigidbody.AddForce (Vector3.right*30);
      }
      if(Controller && Input.GetKey(KeyCode.LeftArrow)) {
        target.rigidbody.AddForce (Vector3.left*30);
      }
      if(Controller && Input.GetKey(KeyCode.RightArrow)) {
        target.rigidbody.AddForce (Vector3.right*30);
      }
    }
	
  }

  void Spawn ()
  {
    target = Instantiate (minos [r.Next (0, minos.Length)]) as GameObject;
    target.transform.localScale = Vector3.one;
    target.name = "Block";
    target.AddComponent<Rigidbody> ();
    target.transform.parent = this.gameObject.transform;
    target.rigidbody.mass = 5;
    target.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;//|RigidbodyConstraints.FreezeRotationY;
    target.transform.localPosition = new Vector3 (r.Next (4, 6), 0, 0);
  }
}
