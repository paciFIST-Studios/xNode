﻿using System.Reflection;
using System.Linq;
using System;

namespace UNEC {
    /// <summary> Contains reflection-related info </summary>
    public static class NodeEditorReflection {
    
        public static Type[] nodeTypes { get { return _nodeTypes != null ? _nodeTypes : _nodeTypes = GetNodeTypes(); } }
        public static Type[] _nodeTypes;

        public static Type[] GetNodeTypes() {
            //Get all classes deriving from Node via reflection
            Type derivedType = typeof(Node);
            Assembly assembly = Assembly.GetAssembly(derivedType);
            return assembly.GetTypes().Where(t => 
                t != derivedType &&
                derivedType.IsAssignableFrom(t)
                ).ToArray();
        }
    }
}