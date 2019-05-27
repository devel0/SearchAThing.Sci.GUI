﻿#region SearchAThing.Sci.GUI, Copyright(C) 2016 Lorenzo Delana, License under MIT
/*
* The MIT License(MIT)
* Copyright(c) 2016 Lorenzo Delana, https://searchathing.com
*
* Permission is hereby granted, free of charge, to any person obtaining a
* copy of this software and associated documentation files (the "Software"),
* to deal in the Software without restriction, including without limitation
* the rights to use, copy, modify, merge, publish, distribute, sublicense,
* and/or sell copies of the Software, and to permit persons to whom the
* Software is furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
* FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
* DEALINGS IN THE SOFTWARE.
*/
#endregion

using System.Windows;
using System.Windows.Controls;
using static System.FormattableString;

namespace OLDSearchAThing.Sci.GUI
{

    public class SciTextBlock : TextBlock
    {

        public SciTextBlock()
        {
            TextAlignment = TextAlignment.Right;
        }

        public bool DisplayMU { get; set; } = true;

        #region Value [dppc]
        public static readonly DependencyProperty ValueProperty =
          DependencyProperty.Register("Value", typeof(Measure), typeof(SciTextBlock),
              new FrameworkPropertyMetadata(null, OnValueChanged));

        public Measure Value
        {
            get
            {
                return (Measure)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        static void OnValueChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var obj = (SciTextBlock)source;

            if (obj.Value != null)
            {
                if (obj.DisplayMU)
                    obj.Text = obj.Value.ToString();
                else
                    obj.Text = Invariant($"{obj.Value.Value}");
            }
            else
                obj.Text = "";
        }
        #endregion

    }

}
