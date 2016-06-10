using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace XamarinApp.Ios
{
    [Register("CardView"), DesignTimeVisible(true)]
    public class CardView : UIView
    {
        private float cornerRadius;
        private UIColor shadowColor;
        private int shadowOffsetHeight;
        private int shadowOffsetWidth;
        private float shadowOpacity;

        [Export("shadowOpacity"), Browsable(true)]
        public float ShadowOpacity
        {
            get { return shadowOpacity; }
            set
            {
                shadowOpacity = value;
                SetNeedsDisplay();
            }
        }

        [Export("shadowOffsetWidth"), Browsable(true)]
        public int ShadowOffsetWidth
        {
            get { return shadowOffsetWidth; }
            set
            {
                shadowOffsetWidth = value;
                SetNeedsDisplay();
            }
        }

        [Export("shadowOffsetHeight"), Browsable(true)]
        public int ShadowOffsetHeight
        {
            get { return shadowOffsetHeight; }
            set
            {
                shadowOffsetHeight = value;
                SetNeedsDisplay();
            }
        }

        [Export("CornerRadius"), Browsable(true)]
        public float CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                SetNeedsDisplay();
            }
        }

        [Export("ShadowColor"), Browsable(true)]
        public UIColor ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                SetNeedsDisplay();
            }
        }

        public CardView()
        {
            Initialize();
        }

        public CardView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        protected CardView(NSObjectFlag t) : base(t)
        {
            Initialize();
        }

        protected internal CardView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        public CardView(CGRect frame) : base(frame)
        {
            Initialize();
        }


        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            Initialize();
        }

        private void Initialize()
        {
            ShadowColor = UIColor.Black;
            CornerRadius = 2;
            ShadowOffsetHeight = 3;
            ShadowOffsetWidth = 0;
            ShadowOpacity = 0.5f;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            Layer.CornerRadius = CornerRadius;
            UIBezierPath bezierPath = UIBezierPath.FromRoundedRect(Bounds, CornerRadius);
            Layer.MasksToBounds = false;
            Layer.ShadowColor = ShadowColor.CGColor;
            Layer.ShadowOffset = new CGSize(shadowOffsetWidth, shadowOffsetHeight);
            Layer.ShadowOpacity = shadowOpacity;
            Layer.ShadowPath = bezierPath.CGPath;
        }
    }
}
