﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Orders
{
    public interface IOrder
    {
        void CompleteOrder(OrderBase order);
    }
}
