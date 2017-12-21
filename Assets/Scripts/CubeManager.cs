using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CubeManager : MonoBehaviour, IInputClickHandler, IInputHandler
{
	public bool measure = false;
	private TextMesh txt;

	void Start()
	{
		measure = false;
		txt = transform.GetChild(0).GetComponent<TextMesh> ();
	}

	public void OnInputClicked(InputClickedEventData eventData)
	{
		Debug.Log ("Clicked");
		measure = !measure;
		txt.text = "Measure: " + measure.ToString ();
		//GetComponent<Renderer> ().material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
	}
	public void OnInputDown(InputEventData eventData)
	{
		Debug.Log ("Click Down");
	}
	public void OnInputUp(InputEventData eventData)
	{ 
		Debug.Log ("Click Up");
	}
}