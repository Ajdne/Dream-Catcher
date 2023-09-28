using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Achievement : MonoBehaviour
{
    [SerializeField] int Threshold;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] GameObject Toggle;
    [Header("TotalSheep = 1 \n " +
            "MostSheep = 2\n" +
            "TotalDreams = 3\n" +
            "TotalDreamTime = 4\n " +
            "LongestDream = 5\n" +
            "ObstaclesHit = 6")]
    [SerializeField] int AchievementType;

    GameManager GM;
    void Start()
    {
        GM = GameManager.Instance;
        switch (AchievementType)
        {
            case 1:
                Description.text = "Collect " + Threshold.ToString() + " Sheep!";
                if (Threshold < GM.TotalSheep)
                {
                    Toggle.SetActive(true);
                    Description.fontStyle = FontStyles.Strikethrough;
                    Name.fontStyle = FontStyles.Strikethrough;
                }
                break;
            case 2:
                Description.text = "Collect " + Threshold.ToString() + " Sheep in One Run!";
                if (Threshold < GM.MostSheepCollected)
                {
                    Toggle.SetActive(true);
                    Description.fontStyle = FontStyles.Strikethrough;
                    Name.fontStyle = FontStyles.Strikethrough;
                }
                break;
            case 3:
                Description.text = "Dream " + Threshold.ToString() + " Times!";
                if (Threshold < GM.TotalDreams)
                {
                    Toggle.SetActive(true);
                    Description.fontStyle = FontStyles.Strikethrough;
                    Name.fontStyle = FontStyles.Strikethrough;
                }
                break;
            case 4:
                Description.text = "Dream " + Threshold.ToString() + " hours in total!";
                if (Threshold < (GM.TotalDreamTime / 360))
                {
                    Toggle.SetActive(true);
                    Description.fontStyle = FontStyles.Strikethrough;
                    Name.fontStyle = FontStyles.Strikethrough;
                }
                break;
            case 5:
                Description.text = "Dream for " + Threshold.ToString() + " minutes!";
                if (Threshold < (GM.LongestDream / 60))
                {
                    Toggle.SetActive(true);
                    Description.fontStyle = FontStyles.Strikethrough;
                    Name.fontStyle = FontStyles.Strikethrough;
                }
                break;
            case 6:
                Description.text = "Hit " + Threshold.ToString() + " obstacles!";
                if (Threshold < GM.ObstaclesHit)
                {
                    Toggle.SetActive(true);
                    Description.fontStyle = FontStyles.Strikethrough;
                    Name.fontStyle = FontStyles.Strikethrough;
                }
                break;
        }
    }
}
