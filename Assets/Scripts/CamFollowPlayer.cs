using UnityEngine;
using System.Collections;

public class CamFollowPlayer : MonoBehaviour
{
	public Vector3 offset;		
	private Transform player;
	
	void Awake (){
		player = GameObject.FindGameObjectWithTag("Cam").transform;
	}
	
	void Update (){
		transform.position = player.position + offset;
	}
}
