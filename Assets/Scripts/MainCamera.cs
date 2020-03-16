using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MainCamera : MonoBehaviour
{
    public GameObject[] MapConnector_top_left;
    public GameObject[] MapConnector_top_mid;
    public GameObject[] MapConnector_top_right;
    public GameObject[] MapConnector_bot_left;
    public GameObject[] MapConnector_bot_mid;
    public GameObject[] MapConnector_bot_right;
    public GameObject[] MapConnector_right_mid;
    public GameObject[] MapConnector_left_mid;
    public Hashtable blocksToConnectorsMap;
    public GameObject player;
    private string currentMapConnectorOpposite;
    private string currentMapConnectorSecondDimension;
    public virtual void Start()
    {
        this.blocksToConnectorsMap["MapConnector_top_left"] = this.MapConnector_top_left;
        this.blocksToConnectorsMap["MapConnector_top_mid"] = this.MapConnector_top_mid;
        this.blocksToConnectorsMap["MapConnector_top_right"] = this.MapConnector_top_right;
        this.blocksToConnectorsMap["MapConnector_bot_left"] = this.MapConnector_bot_left;
        this.blocksToConnectorsMap["MapConnector_bot_mid"] = this.MapConnector_bot_mid;
        this.blocksToConnectorsMap["MapConnector_bot_right"] = this.MapConnector_bot_right;
        this.blocksToConnectorsMap["MapConnector_right_mid"] = this.MapConnector_right_mid;
        this.blocksToConnectorsMap["MapConnector_left_mid"] = this.MapConnector_left_mid;
    }

    public virtual void Update()
    {
    }

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "MapConnector")
        {
            if (coll.name.IndexOf(("MapConnector_" + this.currentMapConnectorOpposite) + "_") < 0)
            {
                Debug.Log("Triggered: " + coll.name);
                Debug.Log("Index of opposite: " + coll.name.IndexOf(("MapConnector_" + this.currentMapConnectorOpposite) + "_"));
                Hashtable blockToAddOffset = this.getNewBlockOffset(coll.name);
                Vector3 blockToAddPostion = (Vector3) blockToAddOffset["blockPosition"];
                GameObject blockToAdd = this.getBlockWithMatchingConnector(coll.name);
                GameObject newBlock = UnityEngine.Object.Instantiate(blockToAdd, coll.gameObject.transform.position + blockToAddPostion, coll.gameObject.transform.rotation);
            }
            // Destroy collider so it doesn't trigger again
            UnityEngine.Object.Destroy(coll.gameObject);
        }
    }

    public virtual Hashtable getNewBlockOffset(string connectorName)
    {
        Vector3 blockPosition = default(Vector3);
        Hashtable resultHash = new Hashtable();
        string[] nameArray = null;
        nameArray = connectorName.Split(new char[] {"_"[0]});
        switch (nameArray[1])
        {
            case "bot":
                blockPosition = new Vector3(0f, -10f);
                resultHash.Add("opposite", "top");
                break;
            case "top":
                blockPosition = new Vector3(0f, 10f);
                resultHash.Add("opposite", "bot");
                break;
            case "left":
                blockPosition = new Vector3(-10f, 0f);
                resultHash.Add("opposite", "right");
                break;
            case "right":
                blockPosition = new Vector3(10f, 0f);
                resultHash.Add("opposite", "left");
                break;
        }
        resultHash.Add("blockPosition", blockPosition);
        this.currentMapConnectorSecondDimension = nameArray[2];
        this.currentMapConnectorOpposite = (string) resultHash["opposite"];
        Debug.Log("Current Opposite: " + this.currentMapConnectorOpposite);
        return resultHash;
    }

    public virtual GameObject getBlockWithMatchingConnector(string connectorName)
    {
        Debug.Log("getBlockWithMatchingConnector: " + connectorName);
        GameObject[] thisConnectorOptions = (GameObject[]) this.blocksToConnectorsMap[connectorName];
        Debug.Log("thisConnectorOptions.length: " + thisConnectorOptions.Length);
        return thisConnectorOptions[Random.Range(0, thisConnectorOptions.Length - 1)];
    }

    public MainCamera()
    {
        this.blocksToConnectorsMap = new Hashtable();
        this.currentMapConnectorOpposite = "none";
        this.currentMapConnectorSecondDimension = "none";
    }

}