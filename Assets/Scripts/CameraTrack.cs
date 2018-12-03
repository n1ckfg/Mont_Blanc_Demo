using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour {

    public Transform root;
    public float speed = 0.01f;
    public string nodeName = "Aipano-Mont-Blanc";

    private List<Transform> points = new List<Transform>();
    private int counter = 0;
    private float nextDistance = 0.01f;

	void Start() {
        Transform[] children = root.GetComponentsInChildren<Transform>();
        for (int i=0; i<children.Length; i++) {
            if (children[i].name.StartsWith(nodeName)) {
                points.Add(children[i]);
            }
        }

        transform.position = points[0].position;
        //transform.rotation = points[0].rotation;
    }

    void Update() {
        transform.position = Vector3.Lerp(transform.position, points[counter].position, speed);
        //transform.rotation = Quaternion.Lerp(transform.rotation, points[counter].rotation, speed);

        if (Vector3.Distance(transform.position, points[counter].position) < nextDistance) {
            counter++;
            if (counter >= points.Count - 1) counter = 0;
        }
    }

}
