using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
public class t2s : MonoBehaviour {

	public AudioSource _audio;

	public InputField inputText;




	// Use this for initialization
	void Start () {
		_audio = gameObject.GetComponent<AudioSource> ();
		//StartCoroutine (DownloadTheAudio());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator DownloadTheAudio(){
		string url = "http://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q=" + inputText.text + "&tl=En-gb";
		WWW www = new WWW (url);
		yield return www;

		_audio.clip = www.GetAudioClip (false, true, AudioType.MPEG);
		File.WriteAllBytes("Assets/audio.mp3", www.bytes);
		//StartCoroutine (SaveAudio ());
		//_audio.Play();
	}

	IEnumerator RunSh(){
        ProcessStartInfo proc = new ProcessStartInfo();
        proc.FileName = "/usr/local/bin/ffmpeg";
        proc.WorkingDirectory = "Assets/";
        proc.Arguments = "-y -i audio.mp3 audio.wav";
		proc.UseShellExecute = true;
        Process.Start(proc);

        yield return new WaitForSeconds(1);

        ProcessStartInfo proc1 = new ProcessStartInfo();
        proc1.FileName = "/bin/sh";
        proc1.WorkingDirectory = "Assets/";
        proc1.Arguments = "command.sh";
		proc1.UseShellExecute = true;
        Process.Start(proc1);
	}
	 
	public void ButtonCLick(){
		StartCoroutine (DownloadTheAudio());
	}
	public void ButtonCLick_sh(){
		StartCoroutine(RunSh());
	}


}
