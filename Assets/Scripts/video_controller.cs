using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class video_controller : MonoBehaviour
{
	private VideoPlayer videoPlayer;
	private RawImage rawImage;
	private int currentClipIndex;
	
	public Text text_PlayOrPause;
	public Button button_PlayOrPause;
	public Button button_Pre;
	public Button button_Next;
	public VideoClip[] videoClips;
	
    //public GameObject Canvas_Movie;
	
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer=this.GetComponent<VideoPlayer>();
		rawImage=this.GetComponent<RawImage>();
		currentClipIndex=0;
		button_PlayOrPause.onClick.AddListener(OnPlayOrPauseVideo);
		button_Pre.onClick.AddListener(OnPreVideo);
		button_Next.onClick.AddListener(OnNextVideo);
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.texture==null){
			return;
		}
		rawImage.texture=videoPlayer.texture;
    }
	
	private void OnPlayOrPauseVideo(){
			if (videoPlayer.isPlaying==true){
				videoPlayer.Pause();
				text_PlayOrPause.text="播放";
				//Debug.Log("2322");
			}
			else {
				videoPlayer.Play();
				//Debug.Log("111");
				text_PlayOrPause.text="暫停";
			}
		
	}
	
	private void OnPreVideo(){
		currentClipIndex -=1;
		if (currentClipIndex<0){
			currentClipIndex=videoClips.Length-1;
		}
		videoPlayer.clip=videoClips[currentClipIndex];
		text_PlayOrPause.text="暫停";
	}
	
	private void OnNextVideo(){
		currentClipIndex +=1;
		currentClipIndex = currentClipIndex % videoClips.Length;
		videoPlayer.clip=videoClips[currentClipIndex];
		text_PlayOrPause.text="暫停";
	}
}
