﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop1.ViewModel
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
