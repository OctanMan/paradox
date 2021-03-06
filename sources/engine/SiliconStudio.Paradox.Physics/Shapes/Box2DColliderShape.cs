﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System.Diagnostics;

using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;

namespace SiliconStudio.Paradox.Physics
{
    public class Box2DColliderShape : ColliderShape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Box2DColliderShape"/> class.
        /// </summary>
        /// <param name="halfExtents">The half extents.</param>
        public Box2DColliderShape(Vector2 halfExtents)
        {
            Type = ColliderShapeTypes.Box;
            Is2D = true;

            HalfExtent = halfExtents;

            InternalShape = new BulletSharp.Box2DShape(halfExtents) { LocalScaling = new Vector3(1, 1, 0) };

            if (!PhysicsEngine.Singleton.CreateDebugPrimitives) return;
            DebugPrimitive = GeometricPrimitive.Cube.New(PhysicsEngine.Singleton.DebugGraphicsDevice);
            DebugPrimitiveScaling = Matrix.Scaling(new Vector3(halfExtents.X * 2, halfExtents.Y * 2, 0.05f) * 1.01f);
        }

        /// <summary>
        /// Gets the half extent.
        /// </summary>
        /// <value>
        /// The half extent.
        /// </value>
        public Vector2 HalfExtent { get; private set; }
    }
}
