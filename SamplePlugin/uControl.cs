using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oop.Tasks.Paint.Interface;
using System.Drawing.Drawing2D;

namespace SamplePlugin
{
    public partial class uControl : UserControl
    {
        private IPaintApplicationContext applicationContext = null;
        //private ListBox brushStyleListBox = new ListBox();

        public uControl(IPaintApplicationContext applicationContext)
        {
            // объект IPaintApplicationContext передается
            // плагином при создании элемента управления;
            // необходим для получения "активных" цветов
            this.applicationContext = applicationContext;
            InitializeComponent();
            //brushStyleListBox = new ListBox();
            brushStyleListBox.Items.Add("No Fill");
            brushStyleListBox.Items.Add("Fill With Border");
            brushStyleListBox.Items.Add("Fill without Border");
            brushStyleListBox.SelectedIndex = 0;
        }

        internal Pen GetPen()
        {
            if (applicationContext == null)
                return null;

            Pen result = null;
            switch (brushStyleListBox.SelectedIndex)
            {
                case 2:
                    {
                        return result;
                        //break;
                    }
                case 1:
                case 0:
                    {
                        result = new Pen(applicationContext.ForegroundColor, 1);
                        return result;
                        //break;
                    }
                default:
                    break;
            }
            return result;
        }

        internal Brush GetBrush()
        {
            if (applicationContext == null)
                return null;

            Brush result = null;
            //int index = brushStyleListBox.SelectedIndex;
            //if (index == 0)
            //    result = new SolidBrush(ApplicationContext.BackgroundColor);
            //else
            //{
            //    //HatchStyle brushStyle =
            //    //               brushStyleValues[index - 1];
            //    //result =
            //    //    new HatchBrush(brushStyle,
            //    //        applicationContext.ForegroundColor,
            //    //        applicationContext.BackgroundColor);
            //}
            switch (brushStyleListBox.SelectedIndex)
            {
                case 0:
                    {
                        return result;
                        //break;
                    }
                case 1:
                case 2:
                    {
                        result = new SolidBrush(applicationContext.BackgroundColor);
                        return result;
                    }
                default:
                    break;
            }
            return result;
        }

    }
}