using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectDetectionApp
{
    // класс для удобного формата получения данных из базы
    public class DataShowFormat
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int DefectCount { get; set; }
        public string DefectCoordinates { get; set; }
    }
}
