using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class INPUTMOVE : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isDragging = false;
    private Vector2 offset;
    [System.Serializable]
    public class ButtonPositionData
    {
        public string buttonName;
        public float positionX;
        public float positionY;
    }

    public List<Button> buttons;

    private List<ButtonPositionData> buttonPositions;




    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        offset = eventData.position - (Vector2)transform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            transform.position = eventData.position - offset;
        }
    }




    public void SaveButtonPositions()
    {
        buttonPositions = new List<ButtonPositionData>();

        foreach (Button button in buttons)
        {
            ButtonPositionData positionData = new ButtonPositionData();
            positionData.buttonName = button.name;
            positionData.positionX = button.transform.position.x;
            positionData.positionY = button.transform.position.y;

            buttonPositions.Add(positionData);
        }

        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/button_positions.dat";
        FileStream file = File.Create(savePath);
        formatter.Serialize(file, buttonPositions);
        file.Close();

        Debug.Log("Positions des boutons sauvegardées !");
    }

    // Méthode pour charger les positions des boutons
    public void LoadButtonPositions()
    {
        string savePath = Application.persistentDataPath + "/button_positions.dat";

        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            buttonPositions = (List<ButtonPositionData>)formatter.Deserialize(file);
            file.Close();

            foreach (Button button in buttons)
            {
                ButtonPositionData positionData = buttonPositions.Find(data => data.buttonName == button.name);

                if (positionData != null)
                {
                    Vector2 position = new Vector2(positionData.positionX, positionData.positionY);
                    button.transform.position = position;
                }
            }

            Debug.Log("Positions des boutons chargées !");
        }
        else
        {
            Debug.Log("Aucun fichier de sauvegarde des positions des boutons trouvé !");
        }
    }




}
