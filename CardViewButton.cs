using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace XamarinApp.Ios
{
    [Register("CardViewButton"), DesignTimeVisible(true)]
    public class CardViewButton : UIButton
    {
        private UIColor backgroundColorHighlight;
        private UIColor backgroundColorNormal;
        private float cornerRadius;
        private bool highlighted;
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

        [Export("BackgroundColorHightlight"), Browsable(true)]
        public UIColor BackgroundColorHighlight
        {
            get { return backgroundColorHighlight; }
            set
            {
                backgroundColorHighlight = value;
                SetNeedsDisplay();
            }
        }

        [Export("BackgroundColorNormal"), Browsable(true)]
        public UIColor BackgroundColorNormal
        {
            get { return backgroundColorNormal; }
            set
            {
                backgroundColorNormal = value;
                SetNeedsDisplay();
            }
        }

        public override bool Highlighted
        {
            get { return highlighted; }
            set
            {
                highlighted = value;
                if (highlighted)
                    BackgroundColor = BackgroundColorHighlight;
                else
                    BackgroundColor = BackgroundColorNormal;
            }
        }


        public CardViewButton()
        {
            Initialize();
        }

        public CardViewButton(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        protected CardViewButton(NSObjectFlag t) : base(t)
        {
            Initialize();
        }

        protected internal CardViewButton(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        public CardViewButton(CGRect frame) : base(frame)
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
            BackgroundColorNormal = UIColor.White;
            BackgroundColorHighlight = UIColor.FromRGB(241, 241, 241);
            CornerRadius = 2;
            ShadowOffsetHeight = 3;
            ShadowOffsetWidth = 0;
            ShadowOpacity = 0.5f;
            BackgroundColor = backgroundColorNormal;
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
