﻿// Uncomment this whole file.

using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
   [HideInInspector]
   public Vector3[] vertices { get; private set; }

   private HMatrix2D transformMatrix = new HMatrix2D();
   HMatrix2D toOriginMatrix = new HMatrix2D();
   HMatrix2D fromOriginMatrix = new HMatrix2D();
   HMatrix2D rotateMatrix = new HMatrix2D();

   private MeshManager meshManager;
   HVector2D pos = new HVector2D();

   void Start()
   {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);
        Translate(1,1);
        Rotate(-45);
   }


   void Translate(float x, float y)
   {
        //creates a transform matrix to reference and multiply position by
        transformMatrix.setIdentity();
        transformMatrix.setTranslationMat(x,y);
        Transform();

        pos = transformMatrix * pos;
   }

   void Rotate(float angle)
   {
        //moves the object to origin, rotatates it and moves it back the same distance it took to move to origin
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();

        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);

        rotateMatrix.setRotationMat(angle);

        transformMatrix.setIdentity();

        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        Transform();
   }

   private void Transform()
   {
        //updates vertices to move accordingly to the new change in position/rotation
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
           HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
           vert = transformMatrix * vert;
           vertices[i].x = vert.x;
           vertices[i].y = vert.y;
        }

        meshManager.clonedMesh.vertices = vertices;
   }
}
