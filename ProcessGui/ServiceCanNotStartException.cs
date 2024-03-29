﻿#nullable enable
using System;

namespace ProcessGui {
	internal sealed class ServiceCanNotStartException : Exception {
		public ServiceCanNotStartException(string? message) : base(message) { }
		public ServiceCanNotStartException(string? message, Exception? innerException) : base(message, innerException) { }
	}
}
