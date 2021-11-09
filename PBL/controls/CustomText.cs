using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace PBL.controls
{
    [DefaultEvent("_TextChanged")]
    public partial class CustomText : UserControl
    {

        public CustomText()
        {
            InitializeComponent();
        }

        public event EventHandler _TextChanged;

        private Color borderColor = Color.MediumSlateBlue;



        private int borderSize = 2;
        private bool underlined = false;
        private Color borderFocusColor = Color.DimGray;
        private bool isFocused = false;

        private int borderRadius = 0;
        private Color placeHolderColor = Color.DarkGray;
        private string placeHolderText = "";
        private bool isPlaceHolder = false;
        private bool isPassword = false;


        [Category("Advanced")]
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        [Category("Advanced")]
        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }
        [Category("Advanced")]
        public bool Underlined { get => underlined; set { underlined = value; this.Invalidate(); } }
        [Category("Advanced")]
        public bool PasswordChar
        {
            get { return IsPassword; }
            set
            {
                isPassword = value;
                textBox1.UseSystemPasswordChar = value;
            }
        }
        [Category("Advanced")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }
        [Category("Advanced")]
        public override Color BackColor
        {
            get => base.BackColor;
            set { base.BackColor = value; textBox1.BackColor = value; }
        }
        [Category("Advanced")]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set { base.ForeColor = value; textBox1.ForeColor = value; }
        }
        [Category("Advanced")]
        public override Font Font
        {
            get => base.Font;
            set { base.Font = value; textBox1.Font = value; if (this.DesignMode) UpdateControlHeight(); }
        }
        [Category("Advanced")]
        public string Texts
        {
            get { if (IsPlaceHolder) return ""; return textBox1.Text; }
            set { textBox1.Text = value; SetPlaceHolder(); }
        }
        [Category("Advanced")]
        public Color BorderFocusColor { get => borderFocusColor; set => borderFocusColor = value; }

        [Category("Advanced")]
        public int BorderRadius
        {
            get => borderRadius; set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }

            }
        }
        [Category("Advanced")]
        public Color PlaceHolderColor { get => placeHolderColor; set { placeHolderColor = value; if (isPlaceHolder) textBox1.ForeColor = value; } }
        [Category("Advanced")]
        public string PlaceHolderText { get => placeHolderText; set { placeHolderText = value; textBox1.Text = ""; SetPlaceHolder(); } }

        private void SetPlaceHolder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeHolderText != "")
            {
                isPlaceHolder = true;
                textBox1.Text = placeHolderText;
                textBox1.ForeColor = placeHolderColor;
                if (isPassword) textBox1.UseSystemPasswordChar = false;


            }
        }
        private void RemovePlaceHolder()
        {
            if (isPlaceHolder && placeHolderText != "")
            {
                isPlaceHolder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPassword) { textBox1.UseSystemPasswordChar = true; }


            }
        }
        public bool IsPlaceHolder { get => isPlaceHolder; set => isPlaceHolder = value; }
        public bool IsPassword { get => isPassword; set => isPassword = value; }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (borderRadius > 1)
            {
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;
                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(pathBorderSmooth);
                    if (BorderRadius > 15) SetTextBoxRoundedRegion();
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlined)
                    {
                        g.DrawPath(penBorderSmooth, pathBorderSmooth);
                        g.SmoothingMode = SmoothingMode.None;
                        g.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                        g.DrawPath(penBorderSmooth, pathBorderSmooth);
                    g.DrawPath(penBorder, pathBorder);


                }
            }
            else
            {
                using (Pen penBorder = new Pen(BorderColor, BorderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlined)
                        g.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else
                        g.DrawRectangle(penBorder, 0, 0, this.Width - 0.5f, this.Height - 0.5f);

                }
            }



        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathTxt);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height - 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }


        private void textBox1_Click_(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null) _TextChanged.Invoke(sender, e);
        }

        private void textBox1_MouseEnter_1(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave_1(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            isFocused = true;

            this.Invalidate();
            RemovePlaceHolder();
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            isFocused = false;
            SetPlaceHolder();
            this.Invalidate();
        }
    }
}
