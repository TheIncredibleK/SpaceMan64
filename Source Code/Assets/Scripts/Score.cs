using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using UnityEngine;

public static class Scores {

	private static string fileName = "/scores.json";
	private static string tempFileName = "/tempscore.txt";

    //insert into then save
    public static bool SubmitScore(string trackName, string time, string name)
    {

        TrackScores track = Load(trackName);
        //Debug.Log(track.track);
        //Debug.Log(track.names[0]);
        //Debug.Log(track.times[0]);
        //Debug.Log(Application.persistentDataPath);
        //Debug.Log(trackName+ time+ name);
        //for new ones
        if (track == null)
        {
            track = new TrackScores();
            track.track = trackName;
            track.times[0] = time;
            track.names[0] = name;
            Save(track);

            return true;
        }
        else
        {
            int tPos = 420;//arbitrary value

            float playerTime = Int32.Parse(time.Replace(":", ""));


            for (int i = 0; i < track.times.Length; i++)
            {
                //Debug.Log(track.times[i]);
                if (track.times[i] == "" || track.times[i] == null)
                {
                    tPos = i;
                    break;
                }
                    
                else if (playerTime < Int32.Parse(track.times[i].Replace(":", "")))
                {
                    tPos = i;
                    break;
                }
            }
            //Debug.Log(tPos);
            if (tPos < 5)
            {
                //Debug.Log("Issa Save");
                for (int i = track.times.Length-1; i > tPos; i--)
                {
                    track.times[i] = track.times[i - 1];
                    track.names[i] = track.names[i - 1];
                }
                //Debug.Log("Issa Save 2");
                track.times[tPos] = time;
                track.names[tPos] = name;
                //Debug.Log("Saving");
                Save(track);

                return true;
            }
        }
        return false;
    }

    //returns scores for one track
    public static TrackScores GetScores(string trackName){
		TrackScores track = Load (trackName);
        return track;   
	}
	//checks if score is high
	public static bool CheckScore(string trackName, string time){

		TrackScores track = Load (trackName);

        float playerTime = Int32.Parse(time.Replace(":", ""));


        for (int i = 0; i < track.times.Length; i++) {
			if (playerTime < Int32.Parse (track.times [i].Replace (":", "")))
				return true;
			if (track.times [i] == "" || track.times [i] == null)
				return true;
		}

		return false;
	}
	//save temp score
	public static bool SaveTemp(string score, string track, bool winner){
		
		File.Create (Application.persistentDataPath + tempFileName).Dispose();
		File.WriteAllText (Application.persistentDataPath + tempFileName, score + "," + track + "," + winner.ToString());
		return true;
	}
	//return temp score
	public static string LoadTemp(){
		return System.IO.File.ReadAllText (Application.persistentDataPath + tempFileName);
	}

	private static void Save(TrackScores track){
        //Debug.Log(track.names[0]);

		TrackScores[] curList = Load();

        if (curList == null || curList.Length == 0)
        {
            curList = new TrackScores[1];
            curList[0] = new TrackScores();
            curList[0].track = track.track;
            curList[0].times[0] = track.times[0];
            curList[0].names[0] = track.names[0];
            //Debug.Log(curList[0].track);
            //Debug.Log(curList[0].times[0]);
            //Debug.Log(curList[0].names[0]);
        }
        else
        {
            //Debug.Log("its trying to save here");
            for (int i = 0; i < curList.Length; i++)
            {
                if (curList[i].track == track.track)
                {
                    curList[i].times = track.times;
                    curList[i].names = track.names;
                }
            }
        }
        //Debug.Log(curList[0].track);
        //Debug.Log(curList[0].times[0]);
        //Debug.Log(curList[0].names[0]);
        TrackScoresWrapper wrapper = new TrackScoresWrapper();
        wrapper.objects = curList;
        string jsonString = JsonUtility.ToJson(wrapper);

        //Debug.Log("Almost there, " + jsonString);

		File.Create (Application.persistentDataPath + fileName).Dispose();
		File.WriteAllText (Application.persistentDataPath + fileName, jsonString);
	}

	//return one track score
	private static TrackScores Load(string trackName){

		if (System.IO.File.Exists (Application.persistentDataPath + fileName)) {
			string unparsedJson = System.IO.File.ReadAllText (Application.persistentDataPath + fileName);

            TrackScoresWrapper list = JsonUtility.FromJson<TrackScoresWrapper>(unparsedJson);

            for (int i = 0; i < list.objects.Length; i++) {
				if (list.objects [i].track == trackName)
					return list.objects[i];
			}
		}
        else
        {
            File.Create(Application.persistentDataPath + fileName).Dispose();
            return null;
        }
        return null;
	}

	//return all track scores
	private static TrackScores[] Load(){
		if (System.IO.File.Exists (Application.persistentDataPath + fileName)) {
			string unparsedJson = System.IO.File.ReadAllText (Application.persistentDataPath + fileName);

			TrackScoresWrapper list = JsonUtility.FromJson<TrackScoresWrapper>(unparsedJson);
			return list.objects;
		}else
        {
            File.Create(Application.persistentDataPath + fileName).Dispose();
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

[Serializable]
public struct TrackScoresWrapper { public TrackScores[] objects; }
