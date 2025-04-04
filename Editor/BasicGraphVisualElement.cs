using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Moths.Graphs.Editor
{
    public class BasicGraphVisualElement : VisualElement
    {
        protected BasicGraphView _graphView;

        private List<Button> _toolbarButtons;


        public BasicGraphVisualElement()
        {
            ConstructGraphView();
            GenerateToolbar();

            VisualElementExtensions.StretchToParentSize(this);
        }

        protected virtual void OnDisable()
        {
            this.Remove(_graphView);
        }

        private void ConstructGraphView()
        {
            _graphView = new BasicGraphView
            {
                name = "Basic Graph"
            };
            this.Add(_graphView);
        }

        private void GenerateToolbar()
        {
            if (_toolbarButtons == null) return;

            var toolbar = new Toolbar();
            foreach (Button b in _toolbarButtons)
            {
                toolbar.Add(b);
            }
            this.Add(toolbar);
        }

        protected void AddToolbarButton(Button b)
        {
            if (_toolbarButtons == null) _toolbarButtons = new List<Button>();
            _toolbarButtons.Add(b);
        }
    }
}