using UnityEngine;
using System.Collections;

public class ActorTip : MonoBehaviour 
{
	public void Show()
	{
		iTween.MoveTo(this.gameObject, iTween.Hash("position", this.gameObject.transform.localPosition + new Vector3(0, 20, 0), "time", 1f, "oncomplete", "OnMoveCompleted", "oncompletetarget", this.gameObject, "islocal",true));
	}
	
	private void OnMoveCompleted()
	{
		Destroy(this.gameObject);
	}
}
