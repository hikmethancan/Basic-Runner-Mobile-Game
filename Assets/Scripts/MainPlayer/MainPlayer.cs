using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : Singleton<MainPlayer>
{
   private CollectiblesCatcher collectiblesCatcher;
   private MovementController movementController;
   private MainPlayerAnimationController mainPlayerAnimationController;
   private MainPlayerFillBarControl mainPlayerFillBarControl;
   private StackController stackController;

   
   public StackController StackController
   {
      get
      {
         if (stackController == null)
         {
            return stackController = GetComponent<StackController>();
         }
        
         return stackController;
      }
   }

   public CollectiblesCatcher CollectiblesCatcher
   {
      get
      {
         if (collectiblesCatcher == null)
         {
            collectiblesCatcher = GetComponent<CollectiblesCatcher>();
         }

         return collectiblesCatcher;
      }
   }

   public MovementController MovementController
   {
      get
      {
         if (movementController == null)
         {
            movementController = GetComponent<MovementController>();
         }

         return movementController;
      }
   }

   public MainPlayerAnimationController MainPlayerAnimationController
   {
      get
      {
         if (mainPlayerAnimationController == null)
         {
            mainPlayerAnimationController = GetComponent<MainPlayerAnimationController>();
         }

         return mainPlayerAnimationController;
      }
   }

   public MainPlayerFillBarControl MainPlayerFillBarControl
   {
      get
      {
         if (mainPlayerFillBarControl == null)
         {
            mainPlayerFillBarControl = GetComponentInChildren<MainPlayerFillBarControl>();
         }

         return mainPlayerFillBarControl;
      }
   }
   
   
}
