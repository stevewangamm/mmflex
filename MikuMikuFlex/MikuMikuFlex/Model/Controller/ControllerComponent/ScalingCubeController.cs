﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMF.Model.Shape.Overlay;
using SlimDX;

namespace MMF.Model.Controller.ControllerComponent
{
    class ScalingCubeController:OverlayCubeShape
    {
        public event EventHandler<ScalingChangedEventArgs> OnScalingChanged = delegate { }; 

        private DragControlManager dragController;

        public ScalingCubeController(RenderContext context,ILockableController parent, Vector4 color, Vector4 overlayColor) : base(context, color, overlayColor)
        {
            this.dragController=new DragControlManager(parent);
        }

        public override void HitTestResult(bool result, bool mouseState, Point mousePosition)
        {
            base.HitTestResult(this.dragController.checkNeedHighlight(result), mouseState, mousePosition);
            this.dragController.checkBegin(result, mouseState, mousePosition);
            if(this.dragController.IsDragging)
            {
                OnScalingChanged(this,new ScalingChangedEventArgs(this.dragController.Delta.X/10f));
            }
            this.dragController.checkEnd(result,mouseState,mousePosition);
        }

        public class ScalingChangedEventArgs:EventArgs
        {
            private float delta;

            public float Delta
            {
                get { return this.delta; }
            }

            public ScalingChangedEventArgs(float delta)
            {
                this.delta = delta;
            }
        }
    }
}
