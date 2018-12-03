using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class blendshapes1 : MonoBehaviour {
    public float jawOpen = 100.0F;
    public float mouthFunnel = 0.0F;
    public float mouthPucker = 0.0F;
    
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public string path = "Assets/output.txt";
    
    private SkinnedMeshRenderer skinMeshRenderer;
    private int i = 0;
    private float timeCount = 0.0f;
    private string[,] array = new string[,]
    {
        {"2.82",	"C"},
        {"3.12",	"F"},
        {"3.58",	"C"},
        {"3.71",	"E"},
        {"3.92",	"F"},
        {"4.27",	"X"},
        {"5.13",	"X"},   
    };
    private float[] times = new float[]
    {
        0.0f, 2.82f, 3.12f, 3.58f, 3.71f, 3.92f, 4.27f,5.13f,10.00f
    };
    private int[,] values = new int[,]
    {
      {0,0,0},
      {0,0,0},
      {60, 0, 0},
      {0, 0, 60},
      {60, 0, 0},
      {0, 100, 0},
      {0, 0, 60},
      {0, 0, 0},
      {0, 0, 0},
      {0, 0, 0},
              {0, 0, 0},
    };
	// Use this for initialization
    void ReadString()
    {
       StreamReader inp_stm = new StreamReader(path);

       while(!inp_stm.EndOfStream)
       {
           string inp_ln = inp_stm.ReadLine( );
          
   }

   inp_stm.Close( );  
    }

	void Start () {
        ReadString();
		skinMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        MusicSource.clip = MusicClip;
        MusicSource.Play();
        

	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(i);
        timeCount += Time.deltaTime;
        if(timeCount >= float.Parse(array[i,0]))
        {
            /*
            if(array[i,1] == "A"){
                skinMeshRenderer.SetBlendShapeWeight(17, 0);
                skinMeshRenderer.SetBlendShapeWeight(19, 0);
                skinMeshRenderer.SetBlendShapeWeight(20, 0);
            }
            if(array[i,1] == "B"){
                skinMeshRenderer.SetBlendShapeWeight(17, 30);
                skinMeshRenderer.SetBlendShapeWeight(19, 0);
                skinMeshRenderer.SetBlendShapeWeight(20, 0);
            }
            if(array[i,1] == "C"){
                skinMeshRenderer.SetBlendShapeWeight(17, 60);
                skinMeshRenderer.SetBlendShapeWeight(19, 0);
                skinMeshRenderer.SetBlendShapeWeight(20, 0);
            }            
            if(array[i,1] == "D"){
                skinMeshRenderer.SetBlendShapeWeight(17, 100);
                skinMeshRenderer.SetBlendShapeWeight(19, 0);
                skinMeshRenderer.SetBlendShapeWeight(20, 0);
            }
            if(array[i,1] == "E"){
                skinMeshRenderer.SetBlendShapeWeight(17, 0);
                skinMeshRenderer.SetBlendShapeWeight(19, 100);
                skinMeshRenderer.SetBlendShapeWeight(20, 0);
            }            
            if(array[i,1] == "F"){
                skinMeshRenderer.SetBlendShapeWeight(17, 0);
                skinMeshRenderer.SetBlendShapeWeight(19, 0);
                skinMeshRenderer.SetBlendShapeWeight(20, 100);
            }
            */
            //i = i + 1;
        }
        /*
            skinMeshRenderer.SetBlendShapeWeight(17, values[i,0] + (values[i+1,0] - values[i,0]) / ((times[i+1] - times[i]) / (timeCount - times[i])));
            //E, round 19
            skinMeshRenderer.SetBlendShapeWeight(39, values[i,1] + (values[i+1,1] - values[i,1]) / ((times[i+1] - times[i]) / (timeCount - times[i])));
            //F, puckered mouth 20
            skinMeshRenderer.SetBlendShapeWeight(38, values[i,2] + (values[i+1,2] - values[i,2]) / ((times[i+1] - times[i]) / (timeCount - times[i])));
          */  
        
            skinMeshRenderer.SetBlendShapeWeight(17, jawOpen);
            skinMeshRenderer.SetBlendShapeWeight(39, mouthFunnel);
            skinMeshRenderer.SetBlendShapeWeight(38, mouthPucker);
        
	}
}
