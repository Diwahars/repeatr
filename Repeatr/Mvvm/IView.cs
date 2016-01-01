using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myriatek.Cube.Repeatr.Mvvm
{
    /// <summary>
    /// To make view having a type strict view model. Basically delegate the view DataContext property.
    /// </summary>
    /// <typeparam name="T">View model type.</typeparam>
    public interface IView<T>
    {
        T ViewModel { get; set; }
    }
}
