using System.Collections;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class PivotBehaviour : MonoBehaviour, IInputClickHandler, IInputHandler
{
	public GameObject distManager;

	public void OnInputClicked(InputClickedEventData eventData)
	{
		//Debug.Log ("Clicked"+gameObject.name);
		if (distManager != null)
			distManager.GetComponent<CheckDistance> ().GetNewPivot ();
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
