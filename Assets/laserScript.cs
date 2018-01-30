using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	public Transform startPoint;
	public Transform endPoint;
	LineRenderer laserLine;
    public Transform pointer;
    //Висит на endPoint
    private ParticleSystem particle;
	// Use this for initialization
	void Start () {
        var heading = startPoint.position - endPoint.position;
		laserLine = GetComponentInChildren<LineRenderer> ();
		laserLine.SetWidth (.2f, .2f);
	}
	
	// Update is called once per frame
	void Update () {
        endPoint.LookAt(startPoint);
        //var heading = startPoint.position - endPoint.position;
        //pointer.position -= heading * Time.deltaTime;
        //Debug.Log("Heading "+heading);
		laserLine.SetPosition (0, startPoint.position);
		laserLine.SetPosition (1, endPoint.position);

	}
}
