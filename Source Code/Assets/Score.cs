using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using UnityEngine;



public static class Scores {

	private static string fileName = "/scores.json";

	public static bool SubmitScore(string trackName, string time, string name){

		if (CheckScore (trackName, time, name))
			return true;
		else
			return false;
	}

	public static void GetScores(string trackName){
		TrackScores track = Load (trackName);
	}

	private static bool CheckScore(string trackName, string time, string name){

		TrackScores track = Load (trackName);

		int tPos = 420;//arbitrary value

		float playerTime = Int32.Parse (time.Replace (":", ""));
		for (int i = 0; i < track.times.Length; i++) {
			if (playerTime < Int32.Parse (track.times[i].Replace (":", "")))
				tPos = i;
		}

		if (tPos < 10){
			track.times [tPos] = time;
			track.names [tPos] = name;
			Save (track);

			return true;
		}

		return false;
	}

	private static void Save(TrackScores track){

		TrackScores[] curList = Load();

		for (int i = 0; i < curList.Length; i++) {
			if (curList[i].track == track.track){
				curList[i].times = track.times;
				curList[i].names = track.names;
			}
		}
		string jsonString = JsonUtility.ToJson (curList);

		File.Create (Application.persistentDataPath + fileName);
		File.WriteAllText (Application.persistentDataPath + fileName, jsonString);
	}

	//return one track score
	private static TrackScores Load(string trackName){
		
		if (File.Exists (Application.persistentDataPath + fileName)) {

			if (System.IO.File.Exists (Application.persistentDataPath + fileName)) {
				string unparsedJson = System.IO.File.ReadAllText (Application.persistentDataPath + fileName);

				TrackData data = JsonUtility.FromJson<TrackData> (unparsedJson);

				for (int i = 0; i < data.trackList.Count; i++) {
					if (data.trackList [i].track == trackName)
						return data.trackList [i];
				}
			}
			return null;
		}
		return null;
	}
		
	//return all track scores
	private static TrackScores[] Load(){
		
		if (File.Exists (Application.persistentDataPath + fileName)) {
			
			if (System.IO.File.Exists (Application.persistentDataPath + fileName)) {
				string unparsedJson = System.IO.File.ReadAllText (Application.persistentDataPath + fileName);

				TrackData list = JsonUtility.FromJson<TrackData> (unparsedJson);
				return list.trackList.ToArray();
			}
			return null;
		}
		return null;
	}
}

[Serializable]
public class TrackScores{
	private int scoreSize = 5;

	public string track;
	public string[] names = new string[5];
	public string[] times = new string[5];
}

[Serializable]
public class TrackData{
	public List<TrackScores> trackList;
}
