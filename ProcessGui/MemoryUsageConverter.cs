using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace ProcessGui {
	internal sealed class MemoryUsageConverter : IValueConverter {
		private readonly string[] _suffixes = {"KB", "MB", "GB"};

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			Debug.Assert(value != null);
			var data = (long) value;
			if (data < 1024) return $"{data} B";

			var dataFloat = (double) data;
			foreach (var suffix in _suffixes) {
				dataFloat /= 1024;
				if (dataFloat < 1024) return $"{Math.Round(dataFloat, 2)} {suffix}";
			}

			return $"{Math.Round(dataFloat, 2)} GB";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
			throw new NotImplementedException();
	}
}