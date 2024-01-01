//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//using UnityEngine.EventSystems;
//using SimpleCraft.UI;
//using UnityEngine.UI;

//namespace SimpleCraft.Core
//{
//    /// <summary>
//    /// Handles the player inputs, camera focus and crafting
//    /// Author: Raul Souza
//    /// </summary>
//    [RequireComponent(typeof(Inventory))]
//    public class Player : MonoBehaviour
//    {
//        //UI elements
//        [SerializeField]
//        private ActionText _actionText;
//        [SerializeField]
//        private CraftUI _craftCostUI;
//        [SerializeField]
//        private GameObject _pauseMenu;

//        [Tooltip("The Transform used to position the items to be crafted.")]
//        [SerializeField]
//        private Transform _raycaster;
//        [SerializeField]
//        private ToolHandler _toolHandler;
//        [SerializeField]
//        private Button bu;//re
//        public Button[] _bot;//re
//        public static bool __hit = false;
//        private LayerMask _focusLayers;
//        private LayerMask _craftLayers;
//        private GameObject _itemObj;
//        private CraftableItem _currCraftItem;
//        private string _currItem = "";
//        private Inventory.Type _currType;
//        private int _craftTypeIdx = 0;
//        private int _itemIdx = 0;
//        private bool _craftingMode = false;
//        [SerializeField]
//        private Transform _cam;
//        private Vector3 _camf;
//        private GameObject _interactionObj;
//        public InventoryUI _inventoryUI;
//        [SerializeField]
//        public List<string> inventoy_obj;
//        public List<int> inventoy_count;

//        private Inventory _inventory;
//        public Inventory Inventory
//        {
//            get { return _inventory; }
//            set { _inventory = value; }
//        }

//        private bool _showingMenu = false;

//        [SerializeField]
//        private QuickMessage _quickMessage;
//        public QuickMessage QuickMessage
//        {
//            get { return _quickMessage; }
//            set { _quickMessage = value; }
//        }
//        [SerializeField]
//        public GameObject wood;
//        public inventoy_list _inventoy_List;
//        public GameObject _hit;

//        /// <summary>
//        /// The type of the interaction if some object that the player
//        /// is looking at
//        /// </summary>
//        private enum Interaction
//        {
//            GrabTool, GrabItem, OpenContainer, None
//        }
//        private Interaction _interaction;

//        /// <summary>
//        /// Check where the floor is on a navmesh to craft a item
//        /// </summary>
//        UnityEngine.AI.NavMeshHit _hitTerrain;
//        //RaycastHit _hit;


//        void Start()
//        {
//            _inventory = this.GetComponent<Inventory>();

//            _inventoryUI = this.GetComponent<InventoryUI>();
//            if (_cam == null)
//            {
//                _cam = Camera.main.transform;

//            }



//            if (Manager.GetCraftableitemsLength(0) >= 1)
//            {
//                _itemIdx = 0;
//                _itemObj = null;
//            }

//            _focusLayers = LayerMask.GetMask("Default", "CraftableItem");
//            _craftLayers = LayerMask.GetMask("Default");

//            Time.timeScale = 1.0f;

//            Cursor.visible = false;

//            _pauseMenu.SetActive(_showingMenu);
//        }

//        async void Update()
//        {
//            //Ray ray = new Ray(transform.position, transform.forward * 10);

//            if (
//            KeyDown(KeyCode.Space))
//            {
//                RaycastHit _hit;


//                //if(Physics.Raycast(ray,out _hit))
//                //            {
//                //	if(_hit.transform.gameObject.tag == "item")
//                //                {
//                //		Item item = _hit.transform.gameObject.GetComponent<Item>();
//                //		Debug.Log(item.ItemName);
//                //                }
//                //            }
//            }

//            if (Input.GetMouseButtonDown(0))
//            {

//                if (_hit.transform.gameObject.tag == "Item")
//                {
//                    _inventoy_List = new inventoy_list();
//                    Item item = _hit.transform.gameObject.GetComponent<Item>();
//                    Debug.Log(item.ItemName);
//                    _inventoy_List.add_i(item.ItemName);
//                }

//            }

//            //Debug.Log(_hit);
//            //インタラクション
//            //Debug.Log();
//            if (Input.GetKeyDown(KeyCode.Escape) && !_inventoryUI.IsActive())
//                ShowPauseMenu();

//            if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Tab)) && !_showingMenu)
//                _inventoryUI.Toogle();

//            if (_showingMenu || _inventoryUI.IsActive())
//                return;

//            //Enter the Crafting Mode
//            if (Input.GetKeyDown(KeyCode.B))
//            {
//                _craftingMode = !_craftingMode;
//                if (_itemObj == null)
//                    _itemObj = Manager.GetCraftableItem(_craftTypeIdx, _itemIdx);
//                if (_itemObj != null)
//                {
//                    _itemObj.SetActive(_craftingMode);
//                    //_actionText.Text = "";
//                    _craftCostUI.gameObject.SetActive(_craftingMode);
//                    _currCraftItem = _itemObj.GetComponent<CraftableItem>();
//                    _craftCostUI.DrawCostView(_currCraftItem, _inventory);
//                    _craftCostUI.setTypeText(_craftTypeIdx);
//                }
//            }

//            if (Input.GetKeyDown(KeyCode.G))
//            {
//                if (_toolHandler.CurrentTool != null)
//                {
//                    _currItem = _toolHandler.CurrentTool.ItemName;
//                    Drop();
//                    _currItem = "";
//                }
//            }
//            if (Input.GetKeyDown(KeyCode.Z))
//            {
//                _inventoryUI.Draw(_inventory);

//            }

//            //Debug.Log(("_hit") + (__hit));
//            //Debug.Log(_craftingMode);
//            if (_craftingMode)
//            {
//                OnCraftingMode();
//            }
//            else
//            {
//                //Debug.Log("a");
//                if (Input.GetMouseButtonDown(0) && _toolHandler.CurrentTool != null)
//                    _toolHandler.Attack();

//                //Perform some action when E is pressed
//                //Debug.Log(_interactionObj);
//                if (Input.GetMouseButtonDown(0) && _interactionObj != null)
//                {

//                    //Debug.Log("1  " + (_hit.transform.gameObject.tag == "Resource") + (_hit.transform.gameObject.tag) + "2  " + (_interaction == Interaction.GrabTool));
//                    //持つやtu
//                    if (_interaction == Interaction.GrabTool && _hit.transform.gameObject.tag == "Resource")
//                    {
//                        Debug.Log("b");
//                        _inventoryUI.Draw(_inventory);
//                        Debug.Log("a");
//                        Resource resource_ = _hit.transform.gameObject.GetComponent<Resource>();
//                        resource_.Item = GetComponent<Item>();
//                        string _name = resource_.Item._itemName;
//                        float amo = resource_.Amount;
//                        Debug.Log("equ");
//                        Equip(_name, amo);


//                    }

//                    bool a = false;
//                    if (_interaction == Interaction.GrabTool && _hit.transform.gameObject.tag == "Resource" && a)
//                    {
//                        inventoy_list instance = new inventoy_list();
//                        instance.add_r(_hit.transform.gameObject);
//                        Debug.Log("itme re");
//                        Resource resource_ = _hit.transform.gameObject.GetComponent<Resource>();
//                        Item item = _interactionObj.GetComponent<Item>();
//                        __hit = true;
//                        float amountTaken = _inventory.Add(resource_.name, resource_.Amount, this);
//                        Debug.Log(amountTaken);

//                        if (amountTaken == item.Amount)
//                        {
//                            Debug.Log("equip_");
//                            // Itemobjの取得方法を修正
//                            Item Itemobj = resource_.Item;
//                            if (Itemobj != null)
//                            {
//                                Equip(Itemobj._itemName, resource_.Amount);
//                            }
//                            Destroy(_interactionObj);
//                        }
//                        else
//                        {
//                            Debug.Log("equip");
//                            item.Amount -= amountTaken;
//                            resource_.Item = GetComponent<Item>();
//                            Debug.Log("1");
//                            if (resource_.Item != null)
//                            {
//                                Item Itemobj = resource_.Item;
//                                Debug.Log("2");
//                                string itemname_ = Itemobj._itemName;
//                                Debug.Log("eq" + Itemobj + ":" + resource_.Amount);
//                                Equip(itemname_, resource_.Amount);
//                            }
//                            else
//                            {
//                                Debug.LogError("player.cs  " + "Failed to get Item component!");
//                            }
//                        }

//                    }



//                    if (_interaction == Interaction.GrabTool && _hit.transform.gameObject.tag == "Tool")
//                    {
//                        Debug.Log("to");
//                        Tool tool = _interactionObj.GetComponent<Tool>();
//                        _inventory.Add(tool.ItemName, tool.Amount, this);
//                        if (_toolHandler.CurrentTool == null)
//                            _toolHandler.ChangeTool(_interactionObj);
//                        else
//                            Destroy(_interactionObj);
//                        _interactionObj = null;
//                    }
//                    else if (_interaction == Interaction.GrabItem && _hit.transform.gameObject.tag == "Item")
//                    {
//                        Item item = _interactionObj.GetComponent<Item>();
//                        float amountTaken = _inventory.Add(item.ItemName, item.Amount, this);
//                        inventoy_list instance = new inventoy_list();


//                        if (amountTaken == item.Amount) { }
//                        //Destroy(_interactionObj);
//                        else
//                            item.Amount -= amountTaken;
//                    }

//                    else if (_interaction == Interaction.OpenContainer)
//                    {
//                        //get the container inventory
//                        Inventory inventory = _interactionObj.GetComponent<Inventory>();
//                        //draw the player's inventory
//                        _inventoryUI.Draw(_inventory);
//                        //draw the container inventory
//                        _inventoryUI.Draw(inventory);
//                    }
//                }

//                //CheckPlayerFocus();
//            }
//        }

//        public void UseItem()
//        {
//            // Debug.Log("0");
//            Debug.Log(_interactionObj != null);
//            //if it is focusing on a interactable
//            if (_currItem != "" && _interactionObj != null)
//            {
//                // Debug.Log("1");
//                Interactable interactable = _interactionObj.GetComponent<Interactable>();

//                if (interactable)
//                    // Debug.Log("2");
//                    //
//                    if (_interactionObj.GetComponent<Interactable>().UseItem(_currItem))
//                    {
//                        // Debug.Log("3");
//                        //inveを開いている時
//                        if (_inventoryUI.IsActive())
//                            //Debug.Log("4");
//                            _inventoryUI.Toogle();
//                        _quickMessage.ShowMessage(_interactionObj.GetComponent<Interactable>().SuccessMessage);
//                        return;
//                        // Debug.Log("5");
//                    }
//            }
//            _quickMessage.ShowMessage("Can't use that here!");
//            // Debug.Log("6");
//        }
//        public void Equip(string name_, float amount_)
//        {
//            Debug.Log("eq");
//            if (_currItem == "")
//                return;

//            GameObject tool = Manager.getItem(name_, amount_);

//            if (tool.GetComponent<Item>().GetType() == typeof(Tool))
//            {
//                _toolHandler.ChangeTool(tool);
//            }
//            else
//            {
//                Destroy(tool);
//                _quickMessage.ShowMessage("Can't equip this item!");
//            }
//        }






//        /// <summary>
//        /// Checks where the player camera is focusing and
//        /// display a message about it.
//        /// </summary>
//        //void CheckPlayerFocus()
//        //{

//        //	_camf = _cam.forward;

//        //	Debug.DrawRay(_cam.position, _camf, Color.red, 100);
//        //	//Debug.Log(UnityEngine.Physics.Raycast(_cam.position, _cam.forward, out _hit, 100, _focusLayers.value));
//        //	if (UnityEngine.Physics.Raycast(_cam.position, _camf, out _hit, 10))
//        //	{
//        //		//Debug.Log("hit check");
//        //		//Debug.Log(_hit.transform.gameObject.tag == "Tool");
//        //		Debug.DrawRay(_cam.position, _cam.forward,Color.red,5,true);
//        //		if (_hit.transform.gameObject.tag == "Item")
//        //		{
//        //			//Debug.Log("item");
//        //			Item item = _hit.transform.gameObject.GetComponent<Item>();
//        //			_actionText.Text = "Press (E) to grab " + item.ItemName + " x " + item.Amount;
//        //			_interaction = Interaction.GrabItem;
//        //			_interactionObj = _hit.transform.gameObject;
//        //		}
//        //		else if (_hit.transform.gameObject.tag == "Tool")
//        //		{

//        //			_actionText.Text = "Press (E) to grab " + _hit.transform.gameObject.GetComponent<Tool>().ItemName;
//        //			_interaction = Interaction.GrabTool;
//        //			_interactionObj = _hit.transform.gameObject;
//        //		}
//        //		else if (_hit.transform.gameObject.tag == "Resource")
//        //		{
//        //			//Debug.Log("re");
//        //			Resource resource = _hit.transform.gameObject.GetComponent<Resource>();
//        //			_actionText.Text = "Resource: " + resource.Item.ItemName;
//        //			_interactionObj = _hit.transform.gameObject;
//        //			//Debug.Log("_ac ;  " +_actionText);
//        //			//Debug.Log("re  ;  " + resource);
//        //		}
//        //		else if (_hit.transform.gameObject.tag == "Container")
//        //		{
//        //			_actionText.Text = "Press (E) to open Container";
//        //			_interaction = Interaction.OpenContainer;
//        //			_interactionObj = _hit.transform.gameObject;
//        //		}
//        //		else if (_hit.transform.gameObject.tag == "Interactable")
//        //		{
//        //			_actionText.Text = _hit.transform.gameObject.name;
//        //			_interaction = Interaction.None;
//        //			_interactionObj = _hit.transform.gameObject;
//        //		}
//        //		else if (_hit.transform.gameObject.tag == "open")
//        //		{
//        //			_actionText.Text = "op";
//        //			_interactionObj = _hit.transform.gameObject;
//        //		}
//        //		else
//        //		{
//        //			_interactionObj = null;
//        //			_actionText.Text = "";
//        //		}
//        //	}
//        //	else
//        //	{
//        //		_interactionObj = null;
//        //		_actionText.Text = "";
//        //	}

//        //}

//        void OnCraftingMode()
//        {
//            //if (_currCraftItem == null)
//            //	return;

//            ////use a raycast from above the player
//            ////using the offset distance forward to the player's position 
//            //_raycaster.position = transform.position + transform.forward * _currCraftItem.Offset;
//            //_raycaster.position = new Vector3(_raycaster.position.x, _raycaster.position.y + 5, _raycaster.position.z);

//            ////position the item to be crafted using a ray from the raycaster transform
//            //if (UnityEngine.Physics.Raycast(_raycaster.position, _raycaster.forward, out _hit, 20, _craftLayers.value))
//            //{
//            //	//keep the object away from the player by the offset distance
//            //	if (Vector3.Distance(_hit.point, this.gameObject.transform.position) >= _currCraftItem.Offset)
//            //	{
//            //		if (_currCraftItem.OnlyOnGround)
//            //		{
//            //			//position the item if the raycast hits a valid navmesh point
//            //			if (UnityEngine.AI.NavMesh.SamplePosition(_hit.point, out _hitTerrain, 100.0f, UnityEngine.AI.NavMesh.AllAreas))
//            //				_itemObj.transform.position = new Vector3(_hitTerrain.position.x, _hitTerrain.position.y, _hitTerrain.position.z);
//            //		}
//            //		else //poisiton the item at the raycast hit position
//            //			_itemObj.transform.position = new Vector3(_hit.point.x, _hit.point.y + 0.2f, _hit.point.z);
//            //	}
//            //}


//            //if (_currCraftItem != null)
//            //{
//            //	//if it is a valid place
//            //	//if (!_currCraftItem.CanBuild())
//            //	//	_actionText.Text = "Can't build there!";
//            //    	 if (!HaveResources(_currCraftItem))
//            //		//_actionText.Text = "Lack of the required resources!";
//            //	else
//            //		//_actionText.Text = "";
//            //}

//            bool changeType = false;

//            //Previous Category
//            //go back to zero after the end
//            if (Input.GetKeyDown(KeyCode.Q))
//            {
//                if (_craftTypeIdx > 0)
//                    _craftTypeIdx -= 1;
//                else
//                    _craftTypeIdx = Manager.GetCraftableTypeLength() - 1;
//                _itemIdx = 0;
//                changeType = true;
//            }

//            //Next Category
//            //go back to zero after the end
//            if (Input.GetKeyDown(KeyCode.R))
//            {
//                if (_craftTypeIdx < Manager.GetCraftableTypeLength() - 1)
//                    _craftTypeIdx += 1;
//                else
//                    _craftTypeIdx = 0;
//                _itemIdx = 0;
//                changeType = true;
//            }

//            //change the category labels
//            if (changeType)
//                _craftCostUI.setTypeText(_craftTypeIdx);

//            //Change the current craftableItem
//            if (Input.GetAxis("Mouse ScrollWheel") != 0 || changeType)
//            {
//                if (Input.GetAxis("Mouse ScrollWheel") > 0)
//                {
//                    if (_itemIdx < Manager.GetCraftableitemsLength(_craftTypeIdx) - 1)
//                        _itemIdx += 1;
//                    else
//                        _itemIdx = 0;
//                }
//                else if (Input.GetAxis("Mouse ScrollWheel") < 0)
//                {
//                    if (_itemIdx > 0)
//                        _itemIdx -= 1;
//                    else
//                        _itemIdx = Manager.GetCraftableitemsLength(_craftTypeIdx) - 1;
//                }

//                //Destroy the previous and instiante the next item
//                _itemObj.SetActive(false);
//                Destroy(_itemObj);
//                _itemObj = null;
//                _itemObj = Manager.GetCraftableItem(_craftTypeIdx, _itemIdx);
//                _itemObj.SetActive(true);

//                _currCraftItem = _itemObj.GetComponent<CraftableItem>();

//                //update the cost view
//                _craftCostUI.DrawCostView(_currCraftItem, _inventory);

//                if (_currCraftItem.HasRigidBody && _itemObj.GetComponent<Rigidbody>() != null)
//                    _itemObj.GetComponent<Rigidbody>().detectCollisions = false;
//            }

//            //Rotate item on mouse click
//            if (Input.GetMouseButton(1))
//            {
//                _itemObj.transform.Rotate(0, 30 * Time.deltaTime, 0);
//            }
//            else if (Input.GetMouseButton(0))
//            {
//                _itemObj.transform.Rotate(0, -30 * Time.deltaTime, 0);
//            }

//            //try to place the item 
//            if (Input.GetKeyDown(KeyCode.E))
//            {
//                //if (this.HaveResources(_currCraftItem) && _currCraftItem.CanBuild())
//                //{
//                //	TakeResources(_currCraftItem);
//                //	GameObject g = Instantiate(_itemObj);

//                //	if (Manager.CheckObjective(_itemObj))
//                //		_quickMessage.ShowMessage("Objective Completed", 5);

//                //	if (_currCraftItem.HasRigidBody && g.GetComponent<Rigidbody>() != null)
//                //		g.GetComponent<Rigidbody>().detectCollisions = true;

//                //	g.GetComponent<CraftableItem>().IsActive = true;
//                //}
//            }
//        }

//        public void Drop()
//        {
//            if (_currItem == "")
//                return;

//            if (_currType != Inventory.Type.Inventory)
//                return;

//            if (_tool
//            ler.CurrentTool != null)
//            {

//                if (_currItem == _toolHandler.CurrentTool.ItemName && _inventory.Items[_currItem] == 1)
//                {
//                    Destroy(_toolHandler.ToolObject);
//                    _toolHandler.CurrentTool = null;
//                }
//            }

//            float amount = _inventoryUI.GetAmount();

//            if (_inventory.DropItem(_currItem, amount))
//            {
//                if (!_inventory.Items.ContainsKey(_currItem))
//                    _currItem = "";
//                if (_inventoryUI.IsActive())
//                    _inventoryUI.Draw(_inventory);
//            }
//            else
//                _quickMessage.ShowMessage("Can't drop it here!");
//        }

//        /// <summary>
//        /// Check if there are enough resources on the inventory in order
//        /// to craft the item.
//        /// </summary>
//        /// <returns><c>true</c>, if resources was hased, <c>false</c> otherwise.</returns>
//        /// <param name="building">Building.</param>
//        bool HaveResources(CraftableItem craftableItem)
//        {
//            foreach (CraftableItem.Cost cost in craftableItem.BuildingCost)
//            {
//                if (!_inventory.Items.ContainsKey(cost.item))
//                    return false;
//                if (_inventory.Items[cost.item] < cost.amount)
//                    return false;
//            }
//            return true;
//        }

//        /// <summary>
//        /// Takes the item's cost resources out of the inventory.
//        /// </summary>
//        /// <param name="building">Building.</param>
//        void TakeResources(CraftableItem craftableItem)
//        {
//            foreach (CraftableItem.Cost buildingCost in craftableItem.BuildingCost)
//            {
//                _inventory.Add(buildingCost.item, -buildingCost.amount, this);
//            }
//            _craftCostUI.DrawCostView(craftableItem, _inventory);
//        }

//        void SetMenu()
//        {
//            _showingMenu = !_showingMenu;
//            Cursor.visible = _showingMenu;
//            if (_showingMenu)
//                Time.timeScale = 0.0f;
//            else
//                Time.timeScale = 1.0f;
//        }

//        public void ShowPauseMenu()
//        {
//            SetMenu();
//            _pauseMenu.SetActive(_showingMenu);
//        }

//        //When an item is selected from the inventory
//        public void SelectItem(string name, Inventory.Type type)
//        {
//            Item item = Manager.GetInventoryItem(name);
//            _currItem = name;
//            _currType = type;
//            _inventoryUI.SelectItem(item);
//        }

//        /// <summary>
//        /// Take or give some item
//        /// from the player to another inventory
//        /// used for containers
//        /// </summary>
//        /// <param name="taking"></param>
//        public void TransferItem(bool taking)
//        {

//            if (_currItem == "")
//            {
//                return;
//            }

//            Inventory otherInventory = _interactionObj.GetComponent<Inventory>();

//            float amount = _inventoryUI.GetAmount();

//            if (taking)
//            {
//                if (_currType == Inventory.Type.Inventory)
//                    return;

//                if (amount > otherInventory.Items[_currItem])
//                    amount = otherInventory.Items[_currItem];

//                if (_inventory.TryAdd(_currItem, amount))
//                    otherInventory.TryAdd(_currItem, -amount);

//                if (!otherInventory.Items.ContainsKey(_currItem))
//                    _currItem = "";
//            }
//            else
//            {
//                if (_currType != Inventory.Type.Inventory)
//                    return;

//                if (amount > _inventory.Items[_currItem])
//                    amount = _inventory.Items[_currItem];

//                //Drop the Tool if it is being held
//                if (_toolHandler.CurrentTool != null)
//                    if (_toolHandler.CurrentTool.ItemName == _currItem)
//                        if (amount > _inventory.Items[_currItem] - 1)
//                        {
//                            Destroy(_toolHandler.ToolObject);
//                            _toolHandler.CurrentTool = null;
//                        }

//                if (otherInventory.TryAdd(_currItem, amount))
//                    _inventory.TryAdd(_currItem, -amount);

//                if (!_inventory.Items.ContainsKey(_currItem))
//                    _currItem = "";
//            }

//            _inventoryUI.Draw(_inventory);
//            _inventoryUI.Draw(otherInventory);
//        }
//    }
//}