using System;
using System.Collections.Generic;
using AI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
  [RequireComponent(typeof(CanvasGroup))]
  public class CheatMenu : MonoBehaviour
  {
    public TMP_InputField input;

    private bool open = false;
    private CanvasGroup canvasGroup;
    private WaveGod waveGod;
    
    private void Start()
    {
      canvasGroup = GetComponent<CanvasGroup>();
      waveGod = GameObject.FindWithTag("GameController").GetComponent<WaveGod>();
    }

    private void Update()
    {
      if (Input.GetKeyUp(KeyCode.BackQuote))
      {
        open = !open;
        setVisibility();
      }
    }

    public void Event_Submit(string value)
    {
      input.text = string.Empty;
      
      if (!open)
      {
        return;
      }

      open = false;
      setVisibility();

      if (!string.IsNullOrEmpty(value))
      {
        parseCheat(value.ToLower());
      }
    }

    private void setVisibility()
    {
      canvasGroup.alpha = open ? 1 : 0;
      canvasGroup.interactable = open;
      canvasGroup.blocksRaycasts = open;
      
      if (open)
      {
        input.Select();
        input.text = string.Empty;
      }
    }

    private Dictionary<string, Action<string>> _cheats;

    private Dictionary<string, Action<string>> cheats
    {
      get
      {
        if (_cheats == null)
        {
          _cheats = new Dictionary<string, Action<string>>();
          _cheats["wave"] = s => runWaveCheat(s);
          _cheats["autospawn"] = s => toggleAutoSpawn(s);
          _cheats["die"] = s => die(s);
          _cheats["reload"] = s => reload(s);
          _cheats["killall"] = s => killAll(s);
        }
        return _cheats;
      }
    }

    
    private void parseCheat(string value)
    {
      string cheat = value.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)[0];
      string parameters = value.Replace(cheat, "").Trim();

      if (cheats.TryGetValue(cheat, out var action))
      {
        action(parameters);
      }
      else
      {
        string error = $"Unkown cheat {cheat}. Valid cheats:\n";
        foreach (var key in cheats.Keys)
        {
          error += key + "\n";
        }
        
        Debug.LogError(error);
      }
    }

    private void toggleAutoSpawn(string parameters)
    {
      waveGod.AutoSpawn = !waveGod.AutoSpawn;
    }

    private void runWaveCheat(string parameters)
    {
      waveGod.AutoSpawn = false;

      if (int.TryParse(parameters, out var index))
      {
        waveGod.SpawnWave(index);
      }
      else
      {
        waveGod.SpawnWave(parameters);
      }
    }

    private void die(string parameters)
    {
      var player = GameObject.FindWithTag("Player").GetComponent<Health>();
      while (player.CurrentHealth > 0)
      {
        player.TakeDamage();
      }
    }
    
    private void reload(string parameters)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void killAll(string parameters)
    {
      waveGod.AutoSpawn = false;
      
      var healths = FindObjectsOfType<Health>();
      foreach (var health in healths)
      {
        while (health.CurrentHealth > 0)
        {
          health.TakeDamage();
        }
      }
    }
  }
}