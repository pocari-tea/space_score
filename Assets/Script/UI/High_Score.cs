using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class High_Score : MonoBehaviour
{
    [SerializeField] private Text Object;
    private int High_Score_UI = 0;
    private SqliteConnection con;

    public static string GetConStr()
    {
        string strCon = "";
        if (Application.platform == RuntimePlatform.Android)
        {
            strCon = "URI=file:" + Application.persistentDataPath + "/AA_local.db";
        }
        else
        {
            strCon = "URI=file:" + Application.dataPath + "/AA_local.db";
        }
        return strCon;
    }

    private void Start()
    {
        #region 데이터베이스 연결 및 질의

        con = new SqliteConnection(GetConStr());
        con.Open();

        //FirstSettingDatabase();

        string stm = "SELECT HighScore FROM SinglePlay";

        var cmd = new SqliteCommand(stm, con);

        cmd.Parameters.AddWithValue("@HighScore", Object.text);

        SqliteDataReader rdr = cmd.ExecuteReader();

        if (rdr.IsDBNull(0))
        {
            Debug.Log("Inserted");
            insertDatabase();
            Object.text = Convert.ToString(5);
            return;
        }

        while (rdr.Read())
        {
            Debug.Log("Score Reading Complete!");
            Object.text = Convert.ToString(rdr.GetValue(0)) + "점";
            High_Score_UI = Convert.ToInt32(rdr.GetValue(0));
        }
        #endregion

    }

    public void FirstSettingDatabase()
    {
        string stm = "SELECT HighScore FROM SinglePlay";
        var cmd = new SqliteCommand(stm, con);
        cmd.Parameters.AddWithValue("@HighScore", Object.text);

        SqliteDataReader rdr = cmd.ExecuteReader();

        if (!rdr.HasRows) {
            string stm2 = "INSERT INTO SinglePlay VALUES(@HighScore)";

            var cmd2 = new SqliteCommand(stm2, con);

            cmd2.Parameters.AddWithValue("@HighScore", High_Score_UI);

            cmd2.ExecuteNonQuery();
        }
    }

    public void insertDatabase()
    {
        string stm = "INSERT INTO SinglePlay VALUES(@HighScore)";

        var cmd = new SqliteCommand(stm, con);

        cmd.Parameters.AddWithValue("@HighScore", Object.text);

        cmd.ExecuteNonQuery();
    }

    public void updateDatabase()
    {
        string stm = "UPDATE SinglePlay SET HighScore=@HighScore";

        var cmd = new SqliteCommand(stm, con);

        cmd.Parameters.AddWithValue("@HighScore", High_Score_UI);

        cmd.ExecuteNonQuery();
    }

    void Update()
    {
        Score score = GameObject.Find("GameManager").GetComponent<Score>();

        if (score.Score_UI > High_Score_UI)
        {
            Debug.Log("HighScore Updated!");
            High_Score_UI = score.Score_UI;
            updateDatabase();
        }
    }
}