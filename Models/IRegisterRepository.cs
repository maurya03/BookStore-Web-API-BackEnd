using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface IRegisterRepository
    {
        int register(Register user);

        string login(Register user);
    }
}