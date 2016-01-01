using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myriatek.Cube.Repeatr.Mvvm.ViewModels
{

    public class MainWindowViewModel : ViewModel
    {
        private string _template = "";
        private string _repeatables = "";
        private bool _customReplaceable;

        /// <summary>
        /// The template that will be repeated.
        /// </summary>
        public string Template
        {
            get { return _template; }
            set
            {
                _template = value;
                OnPropertyChanged();
                Repeat();
            }
        }

        /// <summary>
        /// Template * Repeatables.
        /// </summary>
        public string Result
        {
            get; private set;
        }

        /// <summary>
        /// List of new line separated repeatables.
        /// </summary>
        public string Repeatables
        {
            get { return _repeatables; }
            set
            {
                _repeatables = value;
                OnPropertyChanged();
                Repeat();
            }
        }

        /// <summary>
        /// Transform the template and repeatables.
        /// </summary>
        private void Repeat()
        {
            var builder = new StringBuilder();
            var replaceMark = "{{$}}";
            if (CustomReplaceable)
            {
                replaceMark = Repeatables.Split('\n').FirstOrDefault()?.Trim();
            }
            replaceMark = replaceMark ?? "{{$}}";
            foreach (var item in Repeatables.Split('\n'))
            {
                if (item.Length == 0)
                {
                    continue;
                }
                var result = Template.Replace(replaceMark, item.Trim());
                builder.AppendLine(result);
            }
            Result = builder.ToString();
            OnManualPropertyChanged(nameof(Result));

        }

        /// <summary>
        /// Replace using first value of repeatables instead of using {{$}}
        /// </summary>
        public bool CustomReplaceable
        {
            get { return _customReplaceable; }
            set
            {
                _customReplaceable = value;
                OnPropertyChanged();
                Repeat();
            }
        }
    }
}
