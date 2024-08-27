using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDictionary : MonoBehaviour
{
    public Dictionary<string, float> dictionary = new Dictionary<string, float>();
    public Dictionary<string, string> person = new Dictionary<string, string>();
    public Dictionary<string, List<string>> menu = new Dictionary<string, List<string>>();
    // Start is called before the first frame update
    void Start()
    {
        // food dictionary 
        dictionary.Add("Banana", 1.2f);
        dictionary.Add("Apple", 2f);
        dictionary.Add("Orange", 2.1f);
        foreach (KeyValuePair<string, float> pair in dictionary)
        {
            print(pair);
        }
        
        //people dictionary
        person.Add("A", "male");
        person.Add("B", "female");
        person.Add("C", "male");
        foreach (var pair in person)
        {
            print(pair);
        }
        
        //Dishes Dictionary
        //menu.Add("Rice Dishes", ["fried rice", "piapple rice"]);
        menu.Add("Rice Dishes",new List<string>{"fried rice","piapple rice"});
        menu.Add("Noodle Dishes",new List<string> {"fried noodle", "bee hoon"});
        menu.Add("Pasta Dishes", new List<string> {"prawn pasta", "beef pasta"});
        foreach (var pair in menu)
        {
            print(pair);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
