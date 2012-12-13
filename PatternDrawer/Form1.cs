using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;
using System.Drawing.Drawing2D;

namespace PatternDrawer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //asdf
            //this.panel1.
            this.panel1.Paint += new PaintEventHandler(redraw_panel1);
            
            
        }
        //public Pattern pattern {get: return
        void redraw_panel1(object sender, PaintEventArgs e)
        {
            //Pen myPen = new Pen(Color.Blue,5);
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            SkirtPattern mySkirt = new SkirtPattern() {
                halfWaistSize = 370,
                halfHipsSize = 500,
                waistToHipLength = 190,
                backWaistLength = 420,
                frontLengthFromWaistToFloor = 1020,
                sideLengthFromWaistToFloor = 1040,
                backLengthFromWaistToFloor = 1030,
                skirtLength = 550,
                additionToHalfWaistSize = 5,
                additionToHalfHipsSize = 10
            };
            this.panel1.BackColor = Color.WhiteSmoke;
            draw_grid(e);
            mySkirt.draw(e.Graphics);

        }
        void draw_grid(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.LightGray);
            myPen.Width = 1;
            for (int x = 0; x <= 100; x++)
            {
                e.Graphics.DrawLine(myPen, new Point(x * 50, 0), new Point(x * 50, 10000));
                e.Graphics.DrawLine(myPen, new Point(0, x * 50), new Point(10000, x * 50));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
    public class SkirtPattern : Pattern
    {
        public int halfWaistSize { get; set; }
        public int halfHipsSize { get; set; }
        public int backWaistLength { get; set; }
        public int frontLengthFromWaistToFloor { get; set; }
        public int backLengthFromWaistToFloor { get; set; }
        public int sideLengthFromWaistToFloor { get; set; }
        public int skirtLength { get; set; }
        public int additionToHalfWaistSize { get; set; }
        public int additionToHalfHipsSize { get; set; }
        public int waistToHipLength { get; set; }
        public void makeBasicPatternFigures()
        {
            
            
            int frontSkirtLength = frontLengthFromWaistToFloor - (sideLengthFromWaistToFloor - skirtLength);
            int backSkirtLength = backLengthFromWaistToFloor - (sideLengthFromWaistToFloor - skirtLength);
            Point startPoint = new Point(50, 50);
            Point H = new Point(50, backSkirtLength);            
            Point B = new Point(50, waistToHipLength);
            Point B1 = new Point(50 +halfHipsSize + additionToHalfHipsSize, waistToHipLength);
            Point B2 = new Point(50 + (halfHipsSize + additionToHalfHipsSize) / 2 - 1, waistToHipLength);
            Point B3 = new Point(50 + ((halfHipsSize + additionToHalfHipsSize) / 2 - 1)*4/10, waistToHipLength);
            Point B4 = new Point(50 + halfHipsSize + additionToHalfHipsSize - ((halfHipsSize + additionToHalfHipsSize) / 2 - 1) * 4 / 10, waistToHipLength);
            Point T1 = new Point(B1.X, 50);
            Point T2 = new Point(B2.X, 50);
            Point T3 = new Point(B3.X, 50);
            Point T4 = new Point(B4.X, 50);
            Point H1 = new Point(B1.X, H.Y);
            Point H2 = new Point(B2.X, H.Y);
            this.basicFigures.Add(new Line()
            {
                startPoint = startPoint,
                endPoint = H,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = B,
                endPoint = B1,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = B,
                endPoint = B2,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = B,
                endPoint = B3,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = B1,
                endPoint = T1,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
                
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = H,
                endPoint = H1,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });

            this.basicFigures.Add(new Line()
            {
                startPoint = B1,
                endPoint = H1,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = B2,
                endPoint = H2,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = B2,
                endPoint = T2,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = B3,
                endPoint = T3,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = B4,
                endPoint = T4,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = startPoint,
                endPoint = T1,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = B1,
                endPoint = B4,
                pen = new Pen(Color.Gray, 2),
                penStyle = DashStyle.DashDot
            });

            #region Points
            this.basicFigures.Add(new LPoint()
    {
        position = B4
    });
            this.basicFigures.Add(new LPoint()
            {
                position = B
            });
            this.basicFigures.Add(new LPoint()
            {
                position = startPoint
            });
            this.basicFigures.Add(new LPoint()
            {
                position = B1
            });
            this.basicFigures.Add(new LPoint()
            {
                position = B2
            });
            this.basicFigures.Add(new LPoint()
            {
                position = B3
            });
            this.basicFigures.Add(new LPoint()
            {
                position = H
            });

            this.basicFigures.Add(new LPoint()
            {
                position = H1
            });

            this.basicFigures.Add(new LPoint()
            {
                position = H2
            });

            this.basicFigures.Add(new LPoint()
            {
                position = T1
            });

            this.basicFigures.Add(new LPoint()
            {
                position = T2
            });

            this.basicFigures.Add(new LPoint()
            {
                position = T3
            });

            this.basicFigures.Add(new LPoint()
            {
                position = T4
            }); 
            #endregion

            //foreach (Figure fig in this.figures)
            //{
            //    fig.pen = new Pen(Color.Gray, 4);
            //    fig.pen.DashStyle = DashStyle.DashDot;
            //}
            //Point H = new Point
            //++++++++++++++отмечаем точку Т с прямым углом
            //++++++++++++++вычитаемое = (sideLengthFromWaistToFloor - skirtLength)
            //++++++++++++++frontSkirtLength = frontLengthFromWaistToFloor - вычитаемое
            //++++++++++++++backSkirtLength = backLengthFromWaistToFloor - вычитаемое
            //++++++++++++++вниз от Т строим backSkirtLength - получаем точку Н
            //++++++++++++++hipLine = 0.5 * backWaistLength - 2 
            //or
            //++++++++++++++hipLine = waistToHipLength
            //++++++++++++++От точки Т откладываем hipLine - ставим точку Б
            //++++++++++++++Ширина на линии бедер = ББ1 = halfHipsSize + additionToHalfHipsSize
            //+++++++++++++от точки Б откладываем ББ1
            //+++++++++++++ББ2 = (halfHipsSize + additionToHalfHipsSize)/2 - 1
            //+++++++++++++от точки Б откладываем ББ2
            //+++++++++++++ББ3 = 0,4 * ББ2;
            //Б1Б4 = 0,4 * Б1Б2
            //ББ3 откладываем вправо от Б
            //Б1Б4 откладываем влево от Б1
            //откладываем вверх из Б1, Б2, Б3, Б4 до пересечения с Т получая Т1-Т4
            //откладываем вниз из Б1 и Б2 до пересечения с Н получая Н1 Н2
        }
        public void makeRegularPatterFigures()
        {
            //Now lets create additional points for skirt pattern
            //this.basicFigures.Add("");
            int frontSkirtLength = frontLengthFromWaistToFloor - (sideLengthFromWaistToFloor - skirtLength);
            int backSkirtLength = backLengthFromWaistToFloor - (sideLengthFromWaistToFloor - skirtLength);
            Point startPoint = new Point(50, 50);
            Point B = new Point(50, waistToHipLength);
            Point B1 = new Point(50 + halfHipsSize + additionToHalfHipsSize, waistToHipLength);
            Point B2 = new Point(50 + (halfHipsSize + additionToHalfHipsSize) / 2 - 1, waistToHipLength);
            Point B3 = new Point(50 + ((halfHipsSize + additionToHalfHipsSize) / 2 - 1) * 4 / 10, waistToHipLength);
            Point B4 = new Point(50 + halfHipsSize + additionToHalfHipsSize - ((halfHipsSize + additionToHalfHipsSize) / 2 - 1) * 4 / 10, waistToHipLength);
            Point T1 = new Point(B1.X, 50);
            Point T2 = new Point(B2.X, 50);
            Point T3 = new Point(B3.X, 50);
            Point T4 = new Point(B4.X, 50);
            Point H = new Point(50, backSkirtLength);
            Point H1 = new Point(B1.X, H.Y);
            Point H2 = new Point(B2.X, H.Y);
            Point T20 = new Point(H2.X, startPoint.Y+ H2.Y - skirtLength);
            Point T10 = new Point(H1.X, startPoint.Y + H1.Y - frontSkirtLength);
            //MessageBox.Show(backSkirtLength.ToString() + " --- " + frontSkirtLength.ToString() + " --- " + skirtLength.ToString());
            //MessageBox.Show(T10.ToString() + " " + startPoint.ToString());
            //double tgLeft = (T2.Y - T20.Y) / (T2.X - startPoint.X);
            //MessageBox.Show("(" + T2.Y+ " - " + T20.Y + ")/("+T2.X+" - "+startPoint.X+")");
            //MessageBox.Show(tgLeft.ToString());
            //double catets = 
            double angle = System.Math.Atan((double)(T2.Y - T20.Y) /(T2.X - startPoint.X));//(T2.Y - T20.Y) / (T2.X - startPoint.X));
            //MessageBox.Show(angle.ToString());
            Point T30 = new Point(T3.X, startPoint.X - (int)(Math.Tan(angle)*T3.X));
            //MessageBox.Show(T30.ToString());
            this.basicFigures.Add(new Line()
            {
                startPoint = T3,
                endPoint = T30,
                pen = new Pen(Color.Green, 1)
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = startPoint,
                endPoint = T20,
                pen = new Pen(Color.Green,1)
            });
            this.basicFigures.Add(new Line()
            {
                startPoint = T20,
                endPoint = T10,
                pen = new Pen(Color.Green, 1)                
            });
            this.basicFigures.Add(new LPoint()
            {
                position = T20,
                pen = new Pen(Color.Green,2)
            });
            this.basicFigures.Add(new LPoint()
            {
                position = T10,
                pen = new Pen(Color.Green, 2)
            });
        }
        public override void draw(Graphics gr)
        {
            this.makeBasicPatternFigures();
            this.makeRegularPatterFigures();
            foreach (Figure basicFigure in this.basicFigures)
            {
                basicFigure.draw(gr);
                //MessageBox.Show("111");
            }
            foreach (Figure regularFigure in this.figures)
            {
                MessageBox.Show("Trying to paint: " + regularFigure.ToString());
                regularFigure.draw(gr);
            }
        }
    }
    public class PantsPattern : Pattern
    {
        public override void draw(Graphics gr)
        {
            throw new NotImplementedException();
        }
    }
    public class CoatPattern : Pattern
    {
        public override void draw(Graphics gr)
        {
            throw new NotImplementedException();
        }
    }
    
    public abstract class Pattern
    {
        public List<Figure> figures = new List<Figure>();
        public List<Figure> basicFigures = new List<Figure>();
        public abstract void draw(Graphics gr);
    }
    public abstract class Figure
    {
        private Pen intPen = Pens.Black;
        public Pen pen {
            get{
                return this.intPen;
            }
            set{
                this.intPen = value;                
            }}
        public DashStyle penStyle { get; set; }
        public abstract void draw(Graphics gr);
    }
    public class Line : Figure
    {
        public Point startPoint { get; set; }
        public Point endPoint { get; set; }
        public override void draw(Graphics gr)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(startPoint, endPoint);
            if (this.penStyle != null) {
                pen.DashStyle = penStyle;
            }
            gr.DrawPath(pen, path);
        }
    }
    public class Arc : Figure
    {
        public int angleStart { get; set; }
        public int angleEnd { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public override void draw(Graphics gr)
        {
            //pen.Width = 2;
            Pen myPen = new Pen(Color.Azure, 5);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(x, y, width, height, angleStart, angleEnd);
            gr.DrawPath(myPen, path);
        }
    }
    public class LPoint : Figure
    {
        public Point position { get; set; }
        public override void draw(Graphics gr)
        {
            //Pen myPen = new Pen(Color.Red, 2);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(position.X - 1, position.Y - 1, 2, 2);
            gr.DrawPath(pen, path);
        }
    }
}
