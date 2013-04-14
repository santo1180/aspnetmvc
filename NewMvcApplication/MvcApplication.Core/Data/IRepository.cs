﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication.Core.Data
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}
