using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class TestMicro : MonoBehaviour
{
    // Start is called before the first frame update
	private bool micConnected=false;
	private int minFreq, maxFreq;
	public AudioClip RecordedClip;
	public AudioSource audioSource;
	public Text Infotxt;
	public Text Adress;
	private string fileName;
	private byte[] data;
	
	public GameObject Record;
	
	
    void Start()
    {
        if (Microphone.devices.Length <= 0)
        {
            Infotxt.text="沒有麥克風連線";
        }
        else
        {
            Infotxt.text="設備名稱為:"+Microphone.devices[0].ToString()+"請點擊Start開始錄音";
			micConnected = true;
            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

            if (minFreq == 0 && minFreq == 0)
            {
                maxFreq = 44100;

            }

        }
    }
	
	public void Begin(){
		if (micConnected){
			if (!Microphone.IsRecording(null)){
				RecordedClip=Microphone.Start(null, false, 60, maxFreq);
				Infotxt.text="開始錄音";
			}
			else {
				Infotxt.text="正在錄音中，請勿重複點擊Start";
			}
		}
		else {
			Infotxt.text="請確認麥克風設備是否已連接";
		}
	}
	
	public void Stop(){
		data=GetRealAudio(ref RecordedClip);
		Microphone.End(null);
		Infotxt.text="錄音結束";
	}
	
	public void Player(){
		if (!Microphone.IsRecording(null)){
			audioSource.clip=RecordedClip;
			audioSource.Play();
			Infotxt.text="正在播放錄音";
		}
		else {
			Infotxt.text="正在錄音中，請先停止錄音";
		}
	}
	
	public void Save(){
		if (!Microphone.IsRecording(null)){
			fileName=DateTime.Now.ToString("yyyyMMddHHmmssffff");
			if (!fileName.ToLower().EndsWith(".wav")){
				fileName +=".wav";
			}
			string path = Path.Combine(Application.streamingAssetsPath, fileName); //persistentDataPath streamingAssetsPath
			print(path);
			using (FileStream fs=CreateEmpty(path)){
				fs.Write(data, 0, data.Length);
				WriteHeader(fs, RecordedClip);
			}
		}
		else {
			Infotxt.text="正在錄音中，請先停止錄音";
		}
	}
	
	public static byte[] GetRealAudio(ref AudioClip recordedClip){
		int position=Microphone.GetPosition(null);
		if (position<=0||position>recordedClip.samples){
			position = recordedClip.samples;
		}
		float[] soundata=new float[position * recordedClip.channels];
		recordedClip.GetData(soundata, 0);
		recordedClip=AudioClip.Create(recordedClip.name, position, recordedClip.channels, recordedClip.frequency, false);
		recordedClip.SetData(soundata, 0);
		int rescaleFactor=32767;
		byte[] outData = new byte[soundata.Length*2];
		for (int i=0;i<soundata.Length; i++){
			short temshort=(short)(soundata[i]*rescaleFactor);
			byte[] temdata= BitConverter.GetBytes(temshort);
			outData[i*2]=temdata[0];
			outData[i*2+1]=temdata[1];
		}
		Debug.Log("position="+position+" outData.leng="+outData.Length);
		return outData;
	}
	
	public static void WriteHeader(FileStream stream, AudioClip clip)
    {
        var hz = clip.frequency;
        var channels = clip.channels;
        var samples = clip.samples;
 
        stream.Seek(0, SeekOrigin.Begin);
 
        Byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
        stream.Write(riff, 0, 4);
 
        Byte[] chunkSize = BitConverter.GetBytes(stream.Length - 8);
        stream.Write(chunkSize, 0, 4);
 
        Byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
        stream.Write(wave, 0, 4);
 
        Byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
        stream.Write(fmt, 0, 4);
 
        Byte[] subChunk1 = BitConverter.GetBytes(16);
        stream.Write(subChunk1, 0, 4);
 
        //UInt16 one = 1;
 
        Byte[] audioFormat = BitConverter.GetBytes(1);
        stream.Write(audioFormat, 0, 2);
 
        Byte[] numChannels = BitConverter.GetBytes(channels);
        stream.Write(numChannels, 0, 2);
 
        Byte[] sampleRate = BitConverter.GetBytes(hz);
        stream.Write(sampleRate, 0, 4);
 
        Byte[] byteRate = BitConverter.GetBytes(hz * channels * 2);
        stream.Write(byteRate, 0, 4);
 
        UInt16 blockAlign = (ushort)(channels * 2);
        stream.Write(BitConverter.GetBytes(blockAlign), 0, 2);
 
        UInt16 bps = 16;
        Byte[] bitsPerSample = BitConverter.GetBytes(bps);
        stream.Write(bitsPerSample, 0, 2);
 
        Byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
        stream.Write(datastring, 0, 4);
 
        Byte[] subChunk2 = BitConverter.GetBytes(samples * channels * 2);
        stream.Write(subChunk2, 0, 4);
    }
	
	private FileStream CreateEmpty(string filepath)
    {
        FileStream fileStream = new FileStream(filepath, FileMode.Create);
        byte emptyByte = new byte();
 
        for (int i = 0; i < 44; i++) //為wav文件頭留出空间
        {
            fileStream.WriteByte(emptyByte);
        }
 
        return fileStream;
    }
	
	public void Click()
    {
        if (!Record.activeInHierarchy)
        {
            Record.SetActive(true);
        }
        else {
            Record.SetActive(false);
        }

        
    }
	
	public void Exit()
    {
        
        Record.SetActive(false);
        
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
