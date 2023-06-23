using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WeatherAPI : MonoBehaviour
{
    public string apiKey = "51b4da4c515478f4f5de608451806962";
    public string[] cityNames = { "Pretoria", "City2", "City3" }; // Add the capital city names of each province in South Africa

    public Text cityNameText;
    public Text temperatureText;
    public Text descriptionText;

    private void IEnumerator Start()
    {
        foreach (string city in cityNames)
        {
            StartCoroutine(GetWeatherData(city));
        }
    }

    IEnumerator GetWeatherData(string city)
    {
        string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + ",za&units=metric&appid=" + "51b4da4c515478f4f5de608451806962";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(webRequest.downloadHandler.text);
                DisplayWeatherData(weatherData);
            }
        }
    }

    void DisplayWeatherData(WeatherData weatherData)
    {
        cityNameText.text = weatherData.name;
        temperatureText.text = weatherData.main.temp.ToString() + "°C";
        descriptionText.text = weatherData.weather[0].description;
    }
}

[System.Serializable]
public class WeatherData
{
    public string name;
    public MainData main;
    public Weather[] weather;
}

[System.Serializable]
public class MainData
{
    public float temp;
}

[System.Serializable]
public class Weather
{
    public string description;
}
