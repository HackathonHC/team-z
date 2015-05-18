using UnityEngine;
using System.Collections;

public class RayH : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    RaycastHit[] hits;
    hits = Physics.RaycastAll(transform.parent.position, Vector3.left, 14.0F);
    var val = Mathf.Lerp (transform.localScale.x, hits.Length, 0.1f);
    transform.localScale = new Vector3(val, 1, 1);
    transform.localPosition = new Vector3 (val / 2, 1, 1);

    if(hits.Length > 11) {
      Kill ();
    }
	}

  void Kill(){

    Vector3 startPos = transform.parent.position;
    Vector3 endPos = transform.parent.position + Vector3.left * 14;

    Vector3 center = Vector3.Lerp(startPos, endPos, 0.5f);
    Vector3 cut = (endPos - startPos).normalized;
    Vector3 fwd = (center).normalized;
    Vector3 normal = Vector3.Cross(fwd, cut).normalized;

    #if HARDCORE
    GameObject goCutPlane = new GameObject("CutPlane", typeof(BoxCollider), typeof(Rigidbody), typeof(SplitterSingleCut));
    #else
    GameObject goCutPlane = new GameObject("CutPlane", typeof(BoxCollider), typeof(Rigidbody), typeof(SimpleDestroy));
    #endif

    goCutPlane.GetComponent<Collider>().isTrigger = true;
    Rigidbody bodyCutPlane = goCutPlane.GetComponent<Rigidbody>();
    bodyCutPlane.useGravity = false;
    bodyCutPlane.isKinematic = true;

    Transform transformCutPlane = goCutPlane.transform;
    transformCutPlane.position = center;
    transformCutPlane.localScale = new Vector3(14f, 2f, 0.1f);
    transformCutPlane.rotation = transform.rotation;
    transformCutPlane.up = normal;
  }
}
