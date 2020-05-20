using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{
    ClassController classController;

    // Use this for initialization
    void Start()
    {
        classController = GetComponent<ClassController>();
        
        if (MenuDataHolder.isExperiment)
        {
            if (MenuDataHolder.isPresentation)
            {
                switch (MenuDataHolder.LevelOfMisbehavior)
                {
                    case 1:
                        LoadScenario("few_ins_moni");
                        break;
                    case 3:
                        LoadScenario("many_ins_moni");
                        break;
                    default:
                        LoadScenario("automatedPresentationNone");
                        break;
                }
            }
            else
            {
                switch (MenuDataHolder.LevelOfMisbehavior)
                {
                    case 1:
                        LoadScenario("few_moni_ins");
                        break;
                    case 3:
                        LoadScenario("many_moni_ins");
                        break;
                    default:
                        LoadScenario("automatedSuperviceNone");
                        break;
                }
            }
        }
        else
        {
            if (MenuDataHolder.isPresentation)
            {
                switch (MenuDataHolder.LevelOfMisbehavior)
                {
                    case 1:
                        LoadScenario("automatedPresentationLow");
                        break;
                    case 2:
                        LoadScenario("automatedPresentationMedium");
                        break;
                    case 3:
                        LoadScenario("automatedPresentationHigh");
                        break;
                    default:
                        LoadScenario("automatedPresentationNone");
                        break;
                }
            }
            else
            {
                switch (MenuDataHolder.LevelOfMisbehavior)
                {
                    case 1:
                        LoadScenario("automatedSuperviceLow");
                        break;
                    case 2:
                        LoadScenario("automatedSuperviceMedium");
                        break;
                    case 3:
                        LoadScenario("automatedSuperviceHigh");
                        break;
                    default:
                        LoadScenario("automatedSuperviceNone");
                        break;
                }
            }
        }
    }

    public void LoadScenario(string path)
    {
        ParseScenario(Resources.Load<TextAsset>(path));
    }

    public void ParseScenario(TextAsset csv)
    {
        string[] data = csv.text.Split(new char[] { '\n' });

        foreach (string line in data)
        {
            string[] row = line.Split(new char[] { ',' });
            StartCoroutine(TriggerDisruption(row));
        }
    }

    void DisruptAll(string disruption)
    {
        // TODO more elegantly? I.e. use list/array of components?
        foreach (GameObject student in GameObject.FindGameObjectsWithTag("Student"))
        {
            student.GetComponent<DisruptanceController>().DisruptClass(disruption);
        }
    }

    IEnumerator TriggerDisruption(string[] dataRow)
    {
        int timeInS = 0;
        int.TryParse(dataRow[1], out timeInS);

        yield return new WaitForSeconds(timeInS);
        if (dataRow[2] == "all")
        {
            DisruptAll(dataRow[3]);
        }
        else
        {
            classController.PlaceDict[dataRow[2]]
                .GetComponent<DisruptanceController>().DisruptClass(dataRow[3]);
        }
    }
}
