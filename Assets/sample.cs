using UnityEngine;
using System.Collections;

public class sample : MonoBehaviour {

	// Use this for initialization
	void Start () {

    Vector3 startPos = new Vector3(0,0,0);
    Vector3 endPos = new Vector3(10,-10,0);

    Vector3 center = Vector3.Lerp(startPos, endPos, 0.5f);
    Vector3 cut = (endPos - startPos).normalized;
    Vector3 fwd = (center).normalized;
    Vector3 normal = Vector3.Cross(fwd, cut).normalized;

    GameObject goCutPlane = new GameObject("CutPlane", typeof(BoxCollider), typeof(Rigidbody));

    goCutPlane.GetComponent<Collider>().isTrigger = true;
    Rigidbody bodyCutPlane = goCutPlane.GetComponent<Rigidbody>();
    bodyCutPlane.useGravity = false;
    bodyCutPlane.isKinematic = true;

    Transform transformCutPlane = goCutPlane.transform;
    transformCutPlane.position = center;
    transformCutPlane.localScale = new Vector3(10f, .01f, 0.01f);
    transformCutPlane.rotation = transform.rotation;
    transformCutPlane.up = normal;
	}
}
