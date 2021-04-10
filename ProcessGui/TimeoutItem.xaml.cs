using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProcessGui {
	/// <summary>
	/// Логика взаимодействия для TimeoutItem.xaml
	/// </summary>
	internal partial class TimeoutItem {
		private int _value;

		public int Value {
			get => _value;
			set {
				_value = value;

				if (Value < 1000) InnerText.Text = $"{value} ms";
				else InnerText.Text = value % 1000 == 0 ? $"{value / 1000} s" : $"{(double) value / 1000} s";
			}
		}

		public TimeoutItem() { InitializeComponent(); }
	}
}