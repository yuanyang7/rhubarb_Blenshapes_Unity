using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeScript : MonoBehaviour {
    public AudioSource MusicSource;
    public GameObject model;
    public GameObject camera;
    private SkinnedMeshRenderer skinMeshRenderer;
    private float timeCount = 0.0f;



	// Use this for initialization
	void Start () {
		skinMeshRenderer = GetComponent<SkinnedMeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		timeCount += Time.deltaTime;
		int del = 20;
		int current = 0;
		if(timeCount >= 4.5){
			current += del;
			skinMeshRenderer.SetBlendShapeWeight(4, current);
		}
		else if (timeCount >= 5){
			current -= del;
			skinMeshRenderer.SetBlendShapeWeight(4, current);		
		}
		else if (timeCount >= 5.5){
			timeCount = 0.0f;
			skinMeshRenderer.SetBlendShapeWeight(4, 0);
		}
		*/
		
	}
	public void ButtonClick_Blendshape(){
		 MonoBehaviour[] scriptComponents = model.GetComponents<MonoBehaviour>();    
		 MusicSource.clip =  camera.GetComponent<t2s>()._audio.clip;
    	 MusicSource.Play();
		 foreach(MonoBehaviour script in scriptComponents) {

		     script.enabled = true;
		 }
	}
	public void happy(){
		 skinMeshRenderer.SetBlendShapeWeight(8, 50);
		 skinMeshRenderer.SetBlendShapeWeight(2, 0);
	}
	public void angry(){
		 skinMeshRenderer.SetBlendShapeWeight(2, 50);
		 skinMeshRenderer.SetBlendShapeWeight(8, 0);
	}
	public void ok(){
		 skinMeshRenderer.SetBlendShapeWeight(8, 0);
		 skinMeshRenderer.SetBlendShapeWeight(2, 0);
	}
}
