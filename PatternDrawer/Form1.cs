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

namespace PatternDrawer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //asdf
            this.panel1.Paint += new PaintEventHandler(redraw_panel1);
            
        }

        void redraw_panel1(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
            Pen myPen = new Pen(Color.Blue,5);
            e.Graphics.DrawLine(myPen, new Point(0, 0), new Point(1000, 10000));
            draw_grid(e);
            //Figure myFigure = new Figure();
            //myFigure.type = "coat";
            //myFigure.setup();
            //MessageBox.Show(myFigure.getBaseName());
        }
        void draw_grid(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Black);
            for (int x = 0; x <= 100; x++)
            {
                e.Graphics.DrawLine(myPen, new Point(x * 100, 0), new Point(x * 100, 10000));
                e.Graphics.DrawLine(myPen, new Point(0, x * 100), new Point(10000, x * 100));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
    public class BasicPattern
    {
        public string bName = "base class";
        //private Dictionary<string, Action<int>> primitiveMap = new Dictionary<string, Action<int>>();
        //private void BasicPattern()
        //{
        //    //this.primitiveMap.Add("arc", 
        //}
        private void drawPrimitive(PaintEventArgs e,List<Point> Points)
        {
            //myPanel.DrawToBitmap();
        }
    }
    public class SkirtPattern : BasicPattern
    {
        //private Dictionary<String, String> myList;
    }
    public class PantsPattern : BasicPattern
    {
    }
    public class CoatPattern : BasicPattern
    {
        public string bName = "this is not a base class!";
    }
    public class Figure
    {
        public string type { get; set; }
        public Dictionary<string, string> parameters = new Dictionary<string, string>();
        dynamic figType { get; set; }
        public void setup()
        {
            //dynamic figType;
            switch (type)
            {
                case "skirt":
                    this.figType = new SkirtPattern();
                    break;
                case "coat":
                    this.figType = new CoatPattern();
                    break;
                case "pants":
                    this.figType = new PantsPattern();
                    break;
                default:
                    break;
            }
        }
        public string getBaseName()
        {
            return this.figType.bName;
        }
    }
}
