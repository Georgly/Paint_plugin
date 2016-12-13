using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oop.Tasks.Paint.Interface;
using System.Windows.Forms;
using System.Drawing;

namespace SamplePlugin
{
    [PluginForLoad(true)]
    public class RectanglePlugin : IToolPaintPlugin
    {
        // контекст плагина, через который можно получить
        // контекст приложения IPaintApplicationContext
        private IPaintPluginContext pluginContext = null;
        // панель свойств плагина
        private uControl optionsControl = null;
        // курсор для данного плагина
        //private Cursor cursor = null;
        // пиктограмма плагина
        //private Image icon = null;
        private int startX = 0;
        private int startY = 0;
        private bool shift = false;
        private Pen pen;
        private Brush brush;
        private bool draw = false;
        Rectangle rect;
        Image graphics;


        // свойство, описывающее контекст приложения
        // (для удобства работы)
        private IPaintApplicationContext ApplicationContext
        {
            get
            {
                if (pluginContext == null)
                    return null;
                else
                    return pluginContext.ApplicationContext;
            }
        }

        // инициализация плагина, вызывается при загрузке
        public void AfterCreate(IPaintPluginContext pluginContext)
        {
            // сохранение переданного контекста плагина
            this.pluginContext = pluginContext;

            // создание панели свойств плагина
            // (пользовательского элемента управления)
            optionsControl = new uControl(ApplicationContext);

            // загрузка из директории плагина пиктограммы и
            // курсора
            string imageDir = pluginContext.PluginDir;
            if (imageDir != null)
            {
                imageDir += @"\Images\";


            }
        }

        public void BeforeDestroy()
        {
            optionsControl.Dispose();
            optionsControl = null;
        }

        public void Select(bool selection)
        {
            if (selection)
            {
                // при активации плагина показать панель
                // свойств и установить нужный курсор
                ApplicationContext.OptionsControl = optionsControl;
            }
            else
            {
                // при деактивации плагина убрать панель
                // свойств и установить курсор по умолчанию
                ApplicationContext.OptionsControl = null;
            }
        }

        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public string CommandName
        {
            get
            {
                return "Draw Rectangle";
            }
        }
        
        public void MouseDown(MouseEventArgs me, Keys modifierKeys)
        {
            pen = optionsControl.GetPen();
            brush = optionsControl.GetBrush();
            draw = true;
            graphics = /*Graphics.FromImage(*/ApplicationContext.Image/*)*/;
            Graphics screen = Graphics.FromImage(graphics);
            startX = me.X;
            startY = me.Y;
            rect.Location = new Point(startX, startY);
            rect.Size = new Size(1, 1);
            if (brush != null)
            {
                screen.FillRectangle(brush, rect);
            }
            if (pen != null)
            {
                screen.DrawRectangle(pen, rect);
            }
            ApplicationContext.Invalidate();
        }

        public void MouseUp(MouseEventArgs me, Keys modifierKeys)
        {
            draw = false;
            pen.Dispose();
            brush.Dispose();
            graphics.Dispose();
        }

        public void MouseMove(MouseEventArgs me, Keys modifierKeys)
        {
            if (draw)
            {
                if (modifierKeys == Keys.Shift)
                {
                    int side = me.X - startX > me.Y - startY ? me.Y - startY : me.X - startX;
                    rect.Size = new Size(side, side);
                }
                else
                {
                    rect.Size = new Size(me.X - startX, me.Y - startY);
                }
                Graphics screen = Graphics.FromImage(graphics);
                if (brush != null)
                {
                    screen.FillRectangle(brush, rect);
                }
                if (pen != null)
                {
                    screen.DrawRectangle(pen, rect);
                }
                ApplicationContext.Invalidate();
            }
        }

        //public void KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Shift)
        //    {
        //        shift = true;
        //    }
        //}

        //public void KeyPress(object sender, KeyEventArgs e)
        //{
        //    if (e.Shift)
        //    {
        //        shift = true;
        //    }
        //}

        //public void KeyUp(object sender, KeyEventArgs e)
        //{
        //    shift = false;
        //}

        public void Escape()
        {
        }

        public void Enter()
        {
        }

        public void ColorChange()
        {
            // при изменении одного из активных цветов в
            // основном приложении необходимо обновить
            // панель свойств плагина, т.к. при отрисовке
            // примера круга используются эти цвета
            //optionsControl.                InvalidateResult();
        }

        public void ImageChange()
        {
            //optionsControl.InvalidateResult();
        }

        public string ToolName
        {
            get
            {
                return "Rectangle";
            }
        }

        public Image Icon
        {
            get
            {
                return null/*icon*/;
            }
        }
    }
}
