// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {
  private Vector3 startingPosition;
	CardboardHead mainCam;
	GameObject cubo;
	public float JumpSpeed = 10.0f;
	bool isFalling = false;
	public float JumpStrength = 0.3f;
	public float JumpDecay = 0.01f;
	public bool Jumped = false; 
	public float steps = 8.0f;

  void Start() {
    	startingPosition = transform.localPosition;
		mainCam = Camera.main.GetComponent<StereoController>().Head;
    SetGazedAt(false);
  }

  public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
		if (gazedAt)TeleportRandomly();
  }

  public void Reset() {
    //transform.localPosition = startingPosition;
		Application.LoadLevel("menuSceneCB");
  }

  public void ToggleVRMode() {
    Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
  }

  public void TeleportRandomly() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Vector3 tempVariable;

		switch(GetComponent<Collider>().tag){
		case "Cube1":
			tempVariable = new Vector3(player.rigidbody.velocity.x, 
			                           player.rigidbody.velocity.y + JumpSpeed,
			                           player.rigidbody.velocity.z); 
			player.rigidbody.velocity = tempVariable;
			isFalling = true;
			break;
		case "Cube2":
			tempVariable = new Vector3( player.rigidbody.velocity.x - steps,
			                           player.rigidbody.velocity.y,
			                           player.rigidbody.velocity.z);
			player.rigidbody.velocity =tempVariable;
			break;
		case "Cube3":
				tempVariable = new Vector3( player.rigidbody.velocity.x + steps,
				                           player.rigidbody.velocity.y,
				                           player.rigidbody.velocity.z);
			player.rigidbody.velocity =tempVariable;
			break;
		default:
			
			tempVariable = new Vector3( player.rigidbody.velocity.x,
			                           player.rigidbody.velocity.y,
			                           player.rigidbody.velocity.z);
			player.rigidbody.velocity =tempVariable;
			break;
		}
		/*if(GetComponent<Collider>().tag == "Cube1" && isFalling == false){
			Debug.Log("Salta");

			tempVariable = new Vector3(player.rigidbody.velocity.x, 
			                                   player.rigidbody.velocity.y + JumpSpeed,
			                                   player.rigidbody.velocity.z); 
			player.rigidbody.velocity = tempVariable;
			isFalling = true;
		}else{
			if(GetComponent<Collider>().tag == "Cube3"){
				tempVariable = new Vector3( player.rigidbody.velocity.x + steps,
				                           player.rigidbody.velocity.y,
				                           player.rigidbody.velocity.z);
				

			}
			if(GetComponent<Collider>().tag == "Cube2"){
				tempVariable = new Vector3( player.rigidbody.velocity.x - steps,
				                           player.rigidbody.velocity.y,
				                           player.rigidbody.velocity.z);
				

			}
		}*/
		//player.rigidbody.velocity =tempVariable;
		OnCollisionStay();
  }
	public void OnCollisionStay(){
		isFalling = false;
	}
  public void jump(){
		Vector3 fall = GameObject.FindGameObjectWithTag("Player").rigidbody.velocity;
		fall.y = JumpSpeed;
		//Vector3 fall = rigidbody.velocity;
		//fall.y = JumpSpeed;
		isFalling = true;
	}


}
