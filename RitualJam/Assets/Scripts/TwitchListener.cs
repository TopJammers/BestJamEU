using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System;
using System.Collections.Generic;

public class TwitchListener : MonoBehaviour {

    TcpClient tcpClient;
    private StreamReader inputStream;
    private StreamWriter outputStream;

    public enum commandList { UP, DOWN, LEFT, RIGHT,STOP }
    private Dictionary<commandList, int> commandCount;
    string ip="irc.twitch.tv";
    int port=6667;
    string userName="unfairRitualBot";
    string password= "oauth:tsy7x8mia7ttxrz4blkk4wpw15z8pz";
    string channel= "unfairritual";
    string command = "";
    public bool listening = true;

    private string[] separator;

	// Use this for initialization
	void Start () {
        connect();
        joinRoom(channel);
        separator = new string[] { "PRIVMSG #" + channel + " :" };
        commandCount = new Dictionary<commandList, int>();
        foreach (commandList val in Enum.GetValues(typeof(commandList)))
        {
            commandCount.Add(val, 0);
        }

        //InvokeRepeating("getCommand", 0,2);

        StartCoroutine("listener");
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void connect()
    {

        tcpClient = new TcpClient(ip, port);
        inputStream=new StreamReader(tcpClient.GetStream());
        outputStream = new StreamWriter(tcpClient.GetStream());

        Debug.Log("Connecting...");

        outputStream.WriteLine("PASS " + password);
        outputStream.WriteLine("NICK " + userName);
        outputStream.WriteLine("USER " + userName + " 8 * :" +userName);
        outputStream.Flush();

        Debug.Log("Connected!");

    }

    public void joinRoom(string channel)
    {
        outputStream.WriteLine("JOIN #" + channel);
        outputStream.Flush();
        Debug.Log("Joined Channel: " + channel + "!!");
    }

    public string readMessage()
    {
        string message = "";

        string input = inputStream.ReadLine();
        
        string[] messages = input.Split(separator, StringSplitOptions.None);
        if (messages.Length > 1)
        {
            message = messages[1];

            foreach (commandList val in Enum.GetValues(typeof(commandList)))
            {
                if(message.ToUpper().Equals(val.ToString()))
                {
                    commandCount[val] = commandCount[val] + 1;
                }
            }
            Debug.Log("Reading message: " + message);
        }
        
        return message;

    }

    IEnumerator listener()
    {
        while(listening)
        {
            if (tcpClient.Available > 0)
            {
                readMessage();
            }
            yield return null;
        }
        
    }

    public string getCommand()
    {
        int max = 0;
        Dictionary<commandList, int> actual = new Dictionary<commandList, int>(commandCount);
        foreach(KeyValuePair<commandList, int> entry in actual)
        {
            if (entry.Value>max)
            {
                command = entry.Key.ToString();
                max = entry.Value;
            }
            commandCount[entry.Key] = 0;
        }
        Debug.Log(command);
        return command;
    }





}
