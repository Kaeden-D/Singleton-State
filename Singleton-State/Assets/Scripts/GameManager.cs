using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chapter.Singleton
{

    public class GameManager : Singleton<GameManager>
    {

        //Create variables to keep start and end times
        private DateTime _sessionStartTime; 
        private DateTime _sessionEndTime;

        private void Start()
        {

            //TODO

            _sessionStartTime = DateTime.Now; //Set start time

            Debug.Log("Game session start @: " + DateTime.Now);

        }

        private void OnApplicationQuit()
        {

            _sessionEndTime = DateTime.Now; //Set end time

            TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime); //find difference between times

            Debug.Log("Game session ended @: " + DateTime.Now);
            Debug.Log("Game session lasted: " + timeDifference);

        }

        private void OnGUI()
        {

            GUILayout.BeginArea(new Rect(100, 0, 80, 40));
            if(GUILayout.Button("Next Scene"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            GUILayout.EndArea();

        }

    }

}