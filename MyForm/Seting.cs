﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MyForm
{
    class Seting
    {
        public static int ScreemWidth = System.Windows.Forms.SystemInformation.WorkingArea.Width;
        public static int ScreemHeight = System.Windows.Forms.SystemInformation.WorkingArea.Height;


        public const Int32 AW_HOR_POSITIVE = 0x00000001; // 从左到右打开窗口
        public const Int32 AW_HOR_NEGATIVE = 0x00000002; // 从右到左打开窗口
        public const Int32 AW_VER_POSITIVE = 0x00000004; // 从上到下打开窗口
        public const Int32 AW_VER_NEGATIVE = 0x00000008; // 从下到上打开窗口
        public const Int32 AW_CENTER = 0x00000010; //若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。
        public const Int32 AW_HIDE = 0x00010000; //隐藏窗口，缺省则显示窗口。
        public const Int32 AW_ACTIVATE = 0x00020000; //激活窗口。在使用了AW_HIDE标志后不要使用这个标志。
        public const Int32 AW_SLIDE = 0x00040000; //使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。
        public const Int32 AW_BLEND = 0x00080000; //使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool AnimateWindow(
          IntPtr hwnd, // handle to window
          int dwTime, // duration of animation
          int dwFlags // animation type
          );

        /**/
        /// <summary>
        /// 页面居中
        /// </summary>
        public static void SetMid(Form form)
        {
            // Center the Form on the user's screen everytime it requires a Layout.
            form.SetBounds((Screen.GetBounds(form).Width / 2) - (form.Width / 2),
                (Screen.GetBounds(form).Height / 2) - (form.Height / 2),
                form.Width, form.Height, BoundsSpecified.Location);
        }

        

        public static void SetTopform(Form form)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - (form.Size.Width)) / 2;
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - form.Size.Height) / 2;
            form.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            form.Location = (Point)new Size(x, 10);         //窗体的起始位置为(x,y)
        }
        public static void SetBottomform(Form form)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - (form.Size.Width)) / 2;
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - form.Size.Height) / 2;
            form.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            form.Location = (Point)new Size(x, 10);         //窗体的起始位置为(x,y)
        }

        public static void Formleftgout (Form form)
        {
          
            AnimateWindow(form.Handle, 1000, AW_HOR_POSITIVE);
          
        }
        public static void FormSlowLightingout(Form form)
        {
            AnimateWindow(form.Handle, 1000, AW_BLEND);
        }

        public static void Formtopout(Form form)
        {
            AnimateWindow(form.Handle, 1000, AW_VER_POSITIVE);
           
        }
        public static void Formbouttomout(Form form)
        {
            AnimateWindow(form.Handle, 1000, AW_VER_NEGATIVE);

        }
        public static void Formout(Form form,Int32 behave,int time)
        {
            AnimateWindow(form.Handle, time,behave);

        }




    }




}
