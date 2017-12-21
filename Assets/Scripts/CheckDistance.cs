using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

[RequireComponent(typeof(LineRenderer))]
public class CheckDistance : MonoBehaviour, IInputClickHandler, IInputHandler {

	public GameObject pivotPrefab;
	public Material lineMat;
	public CubeManager mgr;
	public LayerMask checkLayer;

	private GameObject currPivot;
	private GameObject mainCam;
	private Vector3 lastPoint;
	private Vector3 currPoint;
	private float distance;

	private List<GameObject> pivotDropped;
	private int currInd;
	private LineRenderer line;

	void Start()
	{
		mainCam = GameObject.FindWithTag ("MainCamera");
		pivotDropped = new List<GameObject> ();
		currInd = 0;
		line = GetComponent<LineRenderer> ();
		line.material = lineMat;
		GetPivot ();
	}

	void Update()
	{
		if (currPivot != null && mgr.measure) {
			RaycastHit hit;
			//int layerMask = 1 << LayerMask.NameToLayer ("Pivot");
			if (Physics.Raycast (mainCam.transform.position, mainCam.transform.forward, out hit, Mathf.Infinity, checkLayer)) {
				currPivot.transform.position = currPoint = hit.point;

				if (currInd > 1) {
					line.SetPosition (currInd-1, hit.point);
					distance = (lastPoint - currPoint).magnitude;
					currPivot.transform.GetChild (0).GetComponent<TextMesh> ().text = distance.ToString () + "UU\n" + currPivot.transform.position.ToString () + "\n<b><color=red>P" + currInd.ToString () + "</color></b>";
				} else
					currPivot.transform.GetChild (0).GetComponent<TextMesh> ().text = currPivot.transform.position.ToString () + "\n<b><color=red>P" + currInd.ToString () + "</color></b>";
					
			}
		}

		#if UNITY_EDITOR
		if (Input.GetKeyUp (KeyCode.P)) {
			GetNewPivot();
		}
		#endif
	}

	public void GetNewPivot()
	{
		pivotDropped.Add (currPivot.gameObject);
		lastPoint = currPivot.transform.position;
		line.SetPosition (currInd - 1, lastPoint);
		currPivot = null;
		GetPivot ();
	}

	void GetPivot()
	{
		currPivot = GameObject.Instantiate (pivotPrefab) as GameObject;
		currPivot.GetComponent<PivotBehaviour> ().distManager = this.gameObject;
		currInd++;
		if (currInd > 1) {
			line.positionCount = currInd;
		}
	}

	public void OnInputClicked(InputClickedEventData eventData)
	{
		if (mgr.measure) {
			Debug.Log ("Clicked");
			GetNewPivot ();
		}
		//GetComponent<Renderer> ().material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
	}
	public void OnInputDown(InputEventData eventData)
	{
		//Debug.Log ("Click Down");
	}
	public void OnInputUp(InputEventData eventData)
	{ 
		//Debug.Log ("Click Up");
	}
}
