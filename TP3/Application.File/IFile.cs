using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.File
{
    public interface IFile<T>
    {
        bool Save(string file, T data) ;

    }
}
