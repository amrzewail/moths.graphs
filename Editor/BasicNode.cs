using System;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Moths.Graphs.Editor
{
    [System.Serializable]
    public abstract class BasicNode : Node
    {
        public static Vector3 lastSelectedPosition { get; private set; }

        public string GUID;

        public bool entryPoint { get; set; } = false;

        public Vector3 position;

        public abstract void GeneratePorts();

        public override void OnSelected()
        {
            base.OnSelected();
            lastSelectedPosition = position;
        }

        public override void OnUnselected()
        {
            base.OnUnselected();

            position = base.GetPosition().position;
        }

        public virtual BasicPort CreatePort(string name, Orientation orientation, Direction direction, Port.Capacity capacity, Type type)
        {
            var port = BasicPort.Create<Edge>(orientation, direction, capacity, type);
            port.portName = name;
            return port;
        }
    }
}