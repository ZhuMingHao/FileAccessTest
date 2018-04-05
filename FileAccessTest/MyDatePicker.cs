using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FileAccessTest
{
    public class MyDatePicker : DatePicker
    {
        private TextBlock DayTextBlock => (TextBlock)GetTemplateChild("DayTextBlock");
        private TextBlock MonthTextBlock => (TextBlock)GetTemplateChild("MonthTextBlock");
        private TextBlock YearTextBlock => (TextBlock)GetTemplateChild("YearTextBlock");

        public MyDatePicker()
        {
            this.DateChanged += MyDatePicker_DateChanged;

        }

        public void ClearDatePicker()
        {
            DayTextBlock.Text = "";
            YearTextBlock.Text = "";
            MonthTextBlock.Text = "";

        }

        private void MyDatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            SetValue(MyDatePicker.NullableDateProperty, e.NewDate.DateTime);
        }
        protected override Size MeasureOverride(Size availableSize)
        {

            if (GetValue(MyDatePicker.NullableDateProperty) == null)
            {
                ClearDatePicker();
            }
            return base.MeasureOverride(availableSize);
        }

        public DateTime? NullableDate
        {
            get { return (DateTime)GetValue(NullableDateProperty); }
            set { SetValue(NullableDateProperty, value); }
        }

        public static readonly DependencyProperty NullableDateProperty =
            DependencyProperty.Register("NullableDate", typeof(DateTime), typeof(MyDatePicker), new PropertyMetadata(default(DateTime), NullableDateCallBack));

        private static void NullableDateCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dp = d as DatePicker;
            if (e.NewValue == null)
            {

            }
            else
            {
                dp.Date = (DateTime)e.NewValue;
            }
        }
    }
}
