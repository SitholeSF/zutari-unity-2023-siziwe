using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class WeatherAPI : MonoBehaviour
{
    public Text cityNameText;
    public Text temperatureText;
    public Text descriptionText;

    private string apiKey = "51b4da4c515478f4f5de608451806962";
    private List<string> capitalCities = new List<string> { "Johannesburg", "Cape Town", "Pretoria", "Durban", "Bloemfontein", "Nelspruit", "Kimberley", "Mahikeng", "Polokwane" };
    private Dictionary<string, WeatherData> weatherDataMap = new Dictionary<string, WeatherData>();

    private void Start()
    {
        StartCoroutine(GetWeatherDataForCities());
    }

    private IEnumerator GetWeatherDataForCities()
    {
        foreach (string city in capitalCities)
        {
            yield return StartCoroutine(GetWeatherData(city));
        }

        // Display weather data in the desired order
        foreach (string city in capitalCities)
        {
            WeatherData weatherData = weatherDataMap[city];
            UpdateWeatherUI(weatherData);
            //yield return new WaitForSeconds(0.5f); // Optional delay between displaying each city's weather data
        }
    }

    private IEnumerator GetWeatherData(string city)
    {
        string url = $"http://api.openweathermap.org/data/2.5/weather?q={city},za&units=metric&appid={apiKey}";

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Weather API request failed: " + request.error);
        }
        else
        {
            WeatherData weatherData = JsonUtility.FromJson<WeatherData>(request.downloadHandler.text);
            weatherDataMap.Add(city, weatherData);
        }
    }

    private void UpdateWeatherUI(WeatherData weatherData)
    {
        cityNameText.text += "\n" + weatherData.name;
        temperatureText.text += "\n" + weatherData.main.temp.ToString("0") + "°C";
        descriptionText.text += "\n" + weatherData.weather[0].description;
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



