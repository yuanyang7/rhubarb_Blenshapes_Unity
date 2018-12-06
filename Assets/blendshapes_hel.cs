using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class blendshapes_hel : MonoBehaviour {
    public float jawOpen = 0.0F;
    public float mouthFunnel = 0.0F;
    public float mouthPucker = 0.0F;
    
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public GameObject model;
    public GameObject camera;
    public string path = "Assets/output.txt";
    
    private SkinnedMeshRenderer skinMeshRenderer;
    private int i = 0;
    private float timeCount = 0.0f;

    private StreamReader inp_stm;
    
    private List<float> timesList = new List<float>();
    private List<List<int>> valuesList= new List<List<int>>();

	// Use this for initialization
    
    void AddValuesList(int index, int a, int b, int c){
        valuesList[index].Add(a);
        valuesList[index].Add(b);
        valuesList[index].Add(c);
    }
    
    void ReadString()
    {
        inp_stm.Close( );  
    }

	void Start () {
        inp_stm = new StreamReader(path);
    		skinMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        

	}
	// Update is called once per frame
	void Update () {

       if(!inp_stm.EndOfStream)
       {
            string inp_ln = inp_stm.ReadLine( );
            string[] splitArray =  inp_ln.Split('\t');
            
           	if(timesList.Count >= 1 && (float.Parse(splitArray[0]) -  timesList[timesList.Count - 1]) > 0.5){

		            timesList.Add(float.Parse(splitArray[0]) - 0.3f);	
                    valuesList.Add(valuesList[valuesList.Count - 1]);
           	}
           	
           	
            timesList.Add(float.Parse(splitArray[0]));
            valuesList.Add(new List<int>());

            if(splitArray[1] == "A"){
                AddValuesList(valuesList.Count - 1, 0, 0, 100);
            }
           else if(splitArray[1] == "B"){
                AddValuesList(valuesList.Count - 1, 0, 0, 0);
           }
           else if(splitArray[1] == "C"){
                AddValuesList(valuesList.Count - 1, 30, 0, 0);
           }           
           else if(splitArray[1] == "D"){
                AddValuesList(valuesList.Count - 1, 80, 0, 0);
           }            
           else if(splitArray[1] == "E"){
                AddValuesList(valuesList.Count - 1, 60, 30, 0);
           }
           else if(splitArray[1] == "F"){
                AddValuesList(valuesList.Count - 1, 0, 50, 0);
           }
       }
          
        timeCount += Time.deltaTime;
        if(timeCount > timesList[i])
        {
            i = i + 1;
            
            if(i >= timesList.Count && i >2)
            {
                i = 0;
                timeCount = 0.0f;
                MonoBehaviour[] scriptComponents = model.GetComponents<MonoBehaviour>();    
                Debug.Log(scriptComponents[0]);
                scriptComponents[0].enabled = false;

            }
            
        }
        //Debug.Log(i +"," + valuesList[i - 1][0] );
        if(valuesList.Count >= 2)
        {
        	skinMeshRenderer.SetBlendShapeWeight(0, valuesList[i - 1][0] + (valuesList[i][0] - valuesList[i - 1][0]) / ((timesList[i] - timesList[i - 1]) / (timeCount - timesList[i - 1])));
        	//E, round 19
        	skinMeshRenderer.SetBlendShapeWeight(6, valuesList[i - 1][1] + (valuesList[i][1] - valuesList[i - 1][1]) / ((timesList[i] - timesList[i - 1]) / (timeCount - timesList[i - 1])));
        	//F, puckered mouth 20
        	skinMeshRenderer.SetBlendShapeWeight(5, valuesList[i - 1][2] + (valuesList[i][2] - valuesList[i - 1][2]) / ((timesList[i] - timesList[i - 1]) / (timeCount - timesList[i - 1])));
        }

        /*
        0,0,0
        10,0,0
        30,0,0
        70,0,0
        chin lower raise - g
        */
        /*
            skinMeshRenderer.SetBlendShapeWeight(17, jawOpen);
            skinMeshRenderer.SetBlendShapeWeight(38, mouthFunnel);
            skinMeshRenderer.SetBlendShapeWeight(37, mouthPucker);
        */
	}
}
