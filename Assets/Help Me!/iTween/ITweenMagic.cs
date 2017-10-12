using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ITweenMagic : MonoBehaviour {

	// Use this for initialization

	//Space
	public enum MovementType
	{
		WorldSpace,
		UISpace
	};

	[Tooltip("Space in which tween will take place")]
	public MovementType ITweenSpace;

	//Ease Types

	public enum eastype
	{
		linear,
		spring,
		easeInQuad,
		easeOutQuad,
		easeInOutQuad,
		easeInCubic,
		easeOutCubic,
		easeInOutCubic,
		easeInQuart,
		easeOutQuart,
		easeInOutQuart,
		easeInQuint,
		easeOutQuint,
		easeInOutQuint,
		easeInSine,
		easeOutSine,
		easeInOutSine,
		easeInExpo,
		easeOutExpo,
		easeInOutExpo,
		easeInCirc,
		easeOutCirc,
		easeInOutCirc,
		easeInBounce,
		easeOutBounce,
		easeInOutBounce,
		easeInBack,
		easeOutBack,
		easeInOutBack,
		easeInElastic,
		easeOutElastic,
		easeInOutElastic,
	};

	[Tooltip("tweeen easeType Movement")]
	public eastype EaseTypeMovement;
	[Tooltip("tweeen easeType Rotation")]
	public eastype EaseTypeRotation;
	[Tooltip("tweeen easeType Scale")]
	public eastype EaseTypeScale;

	//Time 
	[Tooltip("Time(sec) for Tween ")]
	public float timeMovement=1;
	[Tooltip("Time(sec) for Tween ")]
	public float timeRotation=1;
	[Tooltip("Time(sec) for Tween ")]
	public float timeScale=1;

	//Delay Time
	[Tooltip("Delay Time(sec) for Tween to start ")]
	public float delayMovement;
	[Tooltip("Delay Time(sec) for Tween to start ")]
	public float delayRotation;
	[Tooltip("Delay Time(sec) for Tween to start ")]
	public float delayScale;


	//Loop types 
	public enum LoopType
	{
		none,
		pingpong,
		loop
	};
	public LoopType LoopTypeMovement;
	public LoopType LoopTypeRotation;
	public LoopType LoopTypeScale;

	//Tween Type
	public bool Movement;
	public bool Rotation;
	public bool Scale;

	//For World
	public Vector3 initialPosition3D;
	public Vector3 targetPosition3D;

	//For UI
	public Vector2 initialPosition2D;
	public Vector2 targetPosition2D;


	public Vector3 initialRotation;
	public Vector3 targetRotation;


	public Vector3 initialScale;
	public Vector3 targetScale;

	// Use this for initialization
	void OnEnable() {


		if (ITweenSpace.Equals (MovementType.WorldSpace) || ITweenSpace.Equals(MovementType.UISpace) ) {

			//Movement
			if(Movement){		

					if(ITweenSpace.Equals(MovementType.UISpace))
					{						
						PlayForwardUIMovement();
					}				
					else
					{
						GetComponent<Transform>().localPosition = initialPosition3D;				
						iTween.ValueTo(this.gameObject, iTween.Hash("delay",delayMovement,"from", GetComponent<Transform>().localPosition,"to", targetPosition3D,"time", timeMovement,"looptype",LoopTypeMovement.ToString(),"onupdate", "MoveObject","easetype",EaseTypeMovement.ToString()));
					}

			}	

			//Rotation
			if (Rotation) {
				GetComponent<Transform>().localEulerAngles = initialRotation;
				iTween.ValueTo (this.gameObject, iTween.Hash ("delay", delayRotation, "from", GetComponent<Transform> ().localEulerAngles, "to", targetRotation, "time", timeRotation, "looptype", LoopTypeRotation.ToString (), "onupdate", "RotateObject", "easetype", EaseTypeRotation.ToString ()));

			}

			//Scale
			if(Scale){
				GetComponent<Transform>().localScale = initialScale;
				iTween.ValueTo(this.gameObject, iTween.Hash("delay",delayScale,"from", GetComponent<Transform>().localScale,"to", targetScale,"time", timeScale,"looptype",LoopTypeScale.ToString(),"onupdate", "ScaleObject","easetype",EaseTypeScale.ToString()));

			}		
		}

		Destroy(gameObject);

	}


	//2D OnUpdate EventListners
	public void MoveGuiElement(Vector2 position){GetComponent<RectTransform>().anchoredPosition = position;}


	//3D Event Listners
	public void MoveObject(Vector3 position){GetComponent<Transform>().localPosition = position;}
	public void RotateObject(Vector3 rotation){GetComponent<Transform>().localEulerAngles = rotation;}
	public void ScaleObject(Vector3 scale){GetComponent<Transform>().localScale = scale;}



	public void PlayForwardUIMovement()
	{
		GetComponent<RectTransform>().anchoredPosition = initialPosition2D;
		iTween.ValueTo(this.gameObject, iTween.Hash("delay",delayMovement,"from", GetComponent<RectTransform>().anchoredPosition,"to", targetPosition2D,"time", timeMovement,"looptype",LoopTypeMovement.ToString(),"onupdate", "MoveGuiElement","easetype",EaseTypeMovement.ToString()));
	}

	public void PlayReverseUIMovement()
	{
		GetComponent<RectTransform>().anchoredPosition = targetPosition2D;
		iTween.ValueTo(this.gameObject, iTween.Hash("delay",delayMovement,"from", GetComponent<RectTransform>().anchoredPosition,"to", initialPosition2D,"time", timeMovement,"looptype",LoopTypeMovement.ToString(),"onupdate", "MoveGuiElement","easetype",EaseTypeMovement.ToString()));
	}

}



