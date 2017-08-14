using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjectiveList : MonoBehaviour {

    public Text objList;
    public Text objListTitle;
    private int compNum = 0;
    private int objNum = 0;
    List<Objective> objectives = new List<Objective>();

    void Update()
    {
        objList.text = "";

        Objective[] objArray = objectives.ToArray();

        for (int i=0; i < objectives.Count; i++)
        {
            Objective test = objectives[i];

            if(!test.completed)
                objList.text += (i+1)+ "." + objArray[i].objective + "\n";
            else
                objList.text += (i + 1) + ".<b><color=green>" + objArray[i].objective + "</color></b>\n";
        }

        if(objArray.Length > 0)
        {
            objListTitle.text = "OBJECTIVES (" + compNum + "/"+objNum+")";
        }
    }

	public void CreateObjective(string shortName, string objText)
    {
        objectives.Add(new Objective(shortName, objText, false));
        objectives.Sort();

        objNum++;
    }

    public void CompleteObjective(string objName)
    {
        Objective selected = objectives.Find(x => x.identifier.Contains(objName));
        selected.completed = true;

        compNum++;
    }

    public void RemoveObjective(string objName)
    {
        objectives.Remove(objectives.Find(x => x.identifier.Contains(objName)));
    }
}
