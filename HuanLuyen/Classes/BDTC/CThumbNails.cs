using DBiGraphicObjs.DBiGraphicObjects;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace HuanLuyen
{
    public class CThumbNails : CollectionBase
    {
        public delegate void SelectedIndexChangedEventHandler(MouseEventArgs e);
        public delegate void ChonEventHandler(int index);
        private CThumbNails.SelectedIndexChangedEventHandler SelectedIndexChangedEvent;
        private CThumbNails.ChonEventHandler ChonEvent;
        [AccessedThroughProperty("m_PicBox")]
        private PictureBox _m_PicBox;
        private int currentTopLeftItem = 0;
        private int m_SelectedIndex = 0;
        private string m_GenericImage;
        private int x = 0;
        private int y = 0;
        private int h = 0;
        private int w = 0;
        private int rowsPerPage = 0;
        private int colsPerPage = 0;
        public event CThumbNails.SelectedIndexChangedEventHandler SelectedIndexChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.SelectedIndexChangedEvent = (CThumbNails.SelectedIndexChangedEventHandler)Delegate.Combine(this.SelectedIndexChangedEvent, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.SelectedIndexChangedEvent = (CThumbNails.SelectedIndexChangedEventHandler)Delegate.Remove(this.SelectedIndexChangedEvent, value);
            }
        }
        public event CThumbNails.ChonEventHandler Chon
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.ChonEvent = (CThumbNails.ChonEventHandler)Delegate.Combine(this.ChonEvent, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.ChonEvent = (CThumbNails.ChonEventHandler)Delegate.Remove(this.ChonEvent, value);
            }
        }
        protected virtual PictureBox m_PicBox
        {
            get
            {
                return this._m_PicBox;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                PaintEventHandler value2 = new PaintEventHandler(this.m_PicBox_Paint);
                EventHandler value3 = new EventHandler(this.m_PicBox_DoubleClick);
                MouseEventHandler value4 = new MouseEventHandler(this.m_PicBox_MouseUp);
                EventHandler value5 = new EventHandler(this.m_PicBox_Resize);
                if (this._m_PicBox != null)
                {
                    this._m_PicBox.Paint -= value2;
                    this._m_PicBox.DoubleClick -= value3;
                    this._m_PicBox.MouseUp -= value4;
                    this._m_PicBox.Resize -= value5;
                }
                this._m_PicBox = value;
                if (this._m_PicBox != null)
                {
                    this._m_PicBox.Paint += value2;
                    this._m_PicBox.DoubleClick += value3;
                    this._m_PicBox.MouseUp += value4;
                    this._m_PicBox.Resize += value5;
                }
            }
        }
        public int HorizontalSpacing
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
                this.CalculateRowsAndColumns();
            }
        }
        public int VerticalSpacing
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
                this.CalculateRowsAndColumns();
            }
        }
        public int ImageHeight
        {
            get
            {
                return this.h;
            }
            set
            {
                this.h = value;
                this.CalculateRowsAndColumns();
            }
        }
        public int ImageWidth
        {
            get
            {
                return this.w;
            }
            set
            {
                this.w = value;
                this.CalculateRowsAndColumns();
            }
        }
        public int SelectedIndex
        {
            get
            {
                return this.m_SelectedIndex;
            }
            set
            {
                IList list = this.List;
                checked
                {
                    if (list != null)
                    {
                        int num = this.currentTopLeftItem;
                        int selectedIndex = this.m_SelectedIndex;
                        if (value < 0)
                        {
                            if (selectedIndex != value)
                            {
                                this.m_SelectedIndex = value;
                                this.m_PicBox.Invalidate();
                            }
                        }
                        else if (value >= 0 & value < list.Count)
                        {
                            if (value - this.currentTopLeftItem >= this.rowsPerPage * this.colsPerPage)
                            {
                                do
                                {
                                    this.currentTopLeftItem += this.rowsPerPage * this.colsPerPage;
                                }
                                while (value - this.currentTopLeftItem >= this.rowsPerPage * this.colsPerPage);
                            }
                            else if (value - this.currentTopLeftItem < 0)
                            {
                                do
                                {
                                    this.currentTopLeftItem -= this.rowsPerPage * this.colsPerPage;
                                }
                                while (value - this.currentTopLeftItem < 0);
                            }
                            if (this.currentTopLeftItem < 0)
                            {
                                this.currentTopLeftItem = 0;
                            }
                            if (selectedIndex != value)
                            {
                                this.m_SelectedIndex = value;
                                if (num != this.currentTopLeftItem)
                                {
                                    this.m_PicBox.Invalidate();
                                }
                                else
                                {
                                    this.RefreshItem(selectedIndex);
                                    this.RefreshItem(value);
                                }
                            }
                        }
                    }
                }
            }
        }
        public CThumbNail this[int index]
        {
            get
            {
                return (CThumbNail)this.List[index];
            }
        }
        public void Add(CThumbNail aThumbNail)
        {
            this.List.Add(aThumbNail);
        }
        public int GetCount()
        {
            return this.List.Count;
        }
        public void InsertAt(int index, CThumbNail aThumbNail)
        {
            if (index > this.Count | index < 0)
            {
                MessageBox.Show("Index not valid!");
            }
            else if (index == this.Count)
            {
                this.List.Add(aThumbNail);
            }
            else
            {
                this.List.Insert(index, aThumbNail);
            }
        }
        public void Remove(int index)
        {
            if (index > checked(this.Count - 1) | index < 0)
            {
                MessageBox.Show("Index not valid!");
            }
            else
            {
                this.List.RemoveAt(index);
            }
        }
        public void Remove(CThumbNail aThumbNail)
        {
            this.List.Remove(aThumbNail);
        }
        public CThumbNail GetItemByID(int pId)
        {
            foreach (CThumbNail cThumbNail in this.List)
            {
                if (cThumbNail.ID == pId)
                {
                    return cThumbNail;
                }
            }

            return null;
        }
        public int MoveItem(int pItemId, int pDestItemID)
        {
            int num = -1;
            CThumbNail itemByID = this.GetItemByID(pItemId);
            this.Remove(itemByID);
            checked
            {
                foreach (CThumbNail cThumbNail in this.List)
                {
                    num++;
                    if (cThumbNail.ID == pDestItemID)
                    {
                        this.InsertAt(num, itemByID);
                        return num;
                    }
                }

                return -1;
            }
        }
        public int GetMaxID()
        {
            int num = 0;
            foreach (CThumbNail cThumbNail in this.List)
            {
                if (cThumbNail.ID > num)
                {
                    num = cThumbNail.ID;
                }
            }

            return num;
        }
        private void m_PicBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            IList list = this.List;
            checked
            {
                if (list != null && list.Count > 0)
                {
                    int count = list.Count;
                    int num = this.currentTopLeftItem;
                    int arg_41_0 = 0;
                    int num2 = this.rowsPerPage - 1;
                    for (int i = arg_41_0; i <= num2; i++)
                    {
                        int arg_4F_0 = 0;
                        int num3 = this.colsPerPage - 1;
                        for (int j = arg_4F_0; j <= num3; j++)
                        {
                            if (num < count)
                            {
                                this.DrawOneItem(num, i, j, graphics);
                                num++;
                            }
                        }
                    }
                    Font font = new Font("Webdings", 20f, FontStyle.Regular, GraphicsUnit.Pixel);
                    SolidBrush solidBrush = new SolidBrush(this.m_PicBox.ForeColor);
                    if (num <= count - 1)
                    {
                        graphics.DrawString("6", font, solidBrush, 0f, (float)(this.m_PicBox.Height - 24));
                    }
                    if (this.currentTopLeftItem > 0)
                    {
                        graphics.DrawString("5", font, solidBrush, 0f, 0f);
                    }
                    font.Dispose();
                    solidBrush.Dispose();
                }
            }
        }
        private void DrawOneItem(int index, int row, int col, Graphics gr)
        {
            Font font = this.m_PicBox.Font;
            SolidBrush solidBrush = new SolidBrush(this.m_PicBox.ForeColor);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.FormatFlags = StringFormatFlags.LineLimit;
            CThumbNail cThumbNail = (CThumbNail)this.List[index];
            string symbols = cThumbNail.Symbols;
            CGraphicObjs cGraphicObjs = CGraphicObjs.Str2Objects(symbols, 0, 0, modHuanLuyen.cDecSepa, modHuanLuyen.cGrpSepa);
            Size size = cGraphicObjs.GetSize();
            checked
            {
                int num = 0;
                int num2 = 0;
                if (size.Height > this.h)
                {
                    num = this.h;
                    num2 = (int)Math.Round(unchecked((double)this.h / (double)size.Height * (double)size.Width));
                }
                else
                {
                    num = size.Height;
                    num2 = size.Width;
                }
                if (num2 > this.w)
                {
                    num = (int)Math.Round(unchecked((double)this.w / (double)num2 * (double)num));
                    num2 = this.w;
                }
                Rectangle rect = new Rectangle(2 * this.x + col * (2 * this.x + this.w), 1 * this.y + row * (2 * this.y + this.h), this.w, this.h);
                gr.FillRectangle(new SolidBrush(Color.LightGray), rect);
                Rectangle imageRect = new Rectangle(2 * this.x + col * (2 * this.x + this.w) + (this.w - num2) / 2, 1 * this.y + row * (2 * this.y + this.h) + (this.h - num) / 2, num2, num);
                this.DrawThumbNail(gr, cGraphicObjs, imageRect);
                Pen pen = null;
                if (index == this.m_SelectedIndex)
                {
                    pen = new Pen(Color.Yellow);
                    pen.Width = 4f;
                    gr.DrawRectangle(pen, rect);
                }
                if (pen != null)
                {
                    pen.Dispose();
                }
                int num3 = this.y * 2;
                string arg_24A_1 = cThumbNail.Value;
                Font arg_24A_2 = font;
                Brush arg_24A_3 = solidBrush;
                RectangleF layoutRectangle = new RectangleF((float)(this.x + col * (2 * this.x + this.w)), (float)(2 + 1 * this.y + this.h + row * (2 * this.y + this.h)), (float)(this.w + 2 * this.x), (float)num3);
                gr.DrawString(arg_24A_1, arg_24A_2, arg_24A_3, layoutRectangle, stringFormat);
            }
        }
        private void DrawThumbNail(Graphics g, CGraphicObjs mObjs, Rectangle imageRect)
        {
            float num = (float)mObjs.GetSize().Width;
            float num2 = 0;
            if (num > 0f)
            {
                num2 = (float)imageRect.Width / num;
            }
            else
            {
                num2 = 1f;
            }
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform((float)imageRect.X, (float)imageRect.Y);
            g.ScaleTransform(num2, num2);
            foreach (GraphicObject graphicObject in mObjs)
            {
                if (graphicObject.GetObjType() != OBJECTTYPE.Text)
                {
                    graphicObject.Draw(g);
                }
            }

            g.EndContainer(container);
        }
        public void CalculateRowsAndColumns()
        {
            checked
            {
                int num = this.m_PicBox.Height - 24;
                int num2 = (num - this.y) / (2 * this.y + this.h);
                int num3 = this.m_PicBox.Width / (2 * this.x + this.w);
                if (num2 != this.rowsPerPage || num3 != this.colsPerPage)
                {
                    this.rowsPerPage = num2;
                    this.colsPerPage = num3;
                }
            }
        }
        private Rectangle GetItemRect(int index)
        {
            checked
            {
                int num = (int)Math.Round(Math.Floor((double)(index - this.currentTopLeftItem) / (double)this.colsPerPage));
                int num2 = (index - this.currentTopLeftItem) % this.colsPerPage;
                Rectangle result = new Rectangle(this.x + num2 * (2 * this.x + this.w), 1 * this.y + num * (2 * this.y + this.h), this.w + 2 * this.x, this.h + this.y * 2);
                return result;
            }
        }
        private void m_PicBox_Resize(object sender, EventArgs e)
        {
            this.CalculateRowsAndColumns();
            this.m_PicBox.Invalidate();
        }
        public CThumbNails(PictureBox pPicBox)
        {
            this.currentTopLeftItem = 0;
            this.m_SelectedIndex = 0;
            this.m_GenericImage = "";
            this.x = 10;
            this.y = 16;
            this.h = 40;
            this.w = 40;
            this.rowsPerPage = 0;
            this.colsPerPage = 0;
            this.m_PicBox = pPicBox;
            this.CalculateRowsAndColumns();
        }
        private int HitTest(Point loc)
        {
            bool flag = false;
            int num = 0;
            checked
            {
                while (num < this.List.Count & !flag)
                {
                    if (this.GetItemRect(num).Contains(loc))
                    {
                        flag = true;
                    }
                    else
                    {
                        num++;
                    }
                }
                if (flag)
                {
                    return num;
                }
                return -1;
            }
        }
        protected void RefreshItem(int index)
        {
            Rectangle itemRect = this.GetItemRect(index);
            itemRect.Inflate(5, 5);
            this.m_PicBox.Invalidate(itemRect);
        }
        private void m_PicBox_MouseUp(object sender, MouseEventArgs e)
        {
            Point loc = new Point(e.X, e.Y);
            int num = this.HitTest(loc);
            if (num > -1)
            {
                this.SelectedIndex = num;
            }
            else
            {
                this.SelectedIndex = -1;
            }
            CThumbNails.SelectedIndexChangedEventHandler selectedIndexChangedEvent = this.SelectedIndexChangedEvent;
            if (selectedIndexChangedEvent != null)
            {
                selectedIndexChangedEvent(e);
            }
        }
        private void m_PicBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_SelectedIndex > -1)
            {
                CThumbNails.ChonEventHandler chonEvent = this.ChonEvent;
                if (chonEvent != null)
                {
                    chonEvent(this.m_SelectedIndex);
                }
            }
        }
    }
}