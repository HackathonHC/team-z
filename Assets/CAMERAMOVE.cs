using UnityEngine;
using System.Collections;

public class CAMERAMOVE : MonoBehaviour {
  private Vector3 l;
	// Use this for initialization
	void Start () {
    l = transform.position;
    StartCoroutine (s());
	
	}
	
  IEnumerator s(){
    while(true){
      yield return new WaitForSeconds (3);
    }
  }

  void Update(){
    #if HARDCORE
    transform.position = l + new Vector3(Mathf.Sin (Time.frameCount / 20f)*20,Mathf.Cos (Time.frameCount / 25f)*20, 0);
    transform.LookAt (new Vector3(11, -11, 0));
    #else

    #endif
  }
}
