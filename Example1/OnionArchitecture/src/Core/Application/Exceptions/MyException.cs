﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class MyException:Exception
    {
        public MyException() : base("My error occured")
        {

        }

        public MyException(string message):base(message)
        {

        }

        public MyException(Exception exception):base(exception.Message)
        {

        }
    
    }
}
