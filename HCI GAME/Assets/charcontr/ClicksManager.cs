 using UnityEngine;
 using UnityEngine.SceneManagement;
 
 public class ClicksManager : MonoBehaviour
 {
     // Drag & Drop the objects with the `ClickTarget` component
     [SerializeField]
     private ClickTarget[] targets;
     
 
     // Each target will have an index (based on its position in the previous array)
     // This variable will indicate which target must be clicked
     private int expectedTargetIndex;
             
    public Material correctMaterial;

    public Material activeMaterial;

    public Material wrongMaterial;

    private Renderer myRenderer;


 
     // Called when the scene starts
     private void Start()
     {
         expectedTargetIndex = 0;
         
         
 
         // For each target, call a function when they are clicked
         for ( int i = 0 ; i < targets.Length ; i++ )
         {
             // You have to declare a temporary index to prevent the "closure problem"
             int closureIndex = i;
 
             targets[closureIndex].OnTargetClickedEvent += ( target ) => OnTargetClicked( target, closureIndex );
         }
     }
 
     // Function called when a target is clicked
     private void OnTargetClicked( ClickTarget target, int index)
     
     {
         myRenderer = target.GetComponent<Renderer>();
         

         myRenderer.material = activeMaterial;
         if ( index == expectedTargetIndex )
         {
             myRenderer.material= correctMaterial;
             expectedTargetIndex++;
             if ( expectedTargetIndex == targets.Length )
             {
                 target.transform.position += new Vector3 (0, 45, 0);
             }
         }
         else
         {
             myRenderer.material = wrongMaterial;;
             expectedTargetIndex = 0;
            
 
         }
     }
 }