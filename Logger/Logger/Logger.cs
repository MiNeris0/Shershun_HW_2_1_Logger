using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger
    {
        private static Logger _instance = new Logger();
        private LogRecord[] _record;
        private int _index;

        private Logger()
        {
            _record = new LogRecord[200];
        }

        public static Logger Instance => _instance;

        public void Log(LogRecord record)
        {
            Console.WriteLine(GetStringText(record));

            _record[_index] = record;

            _index++;
        }

        public LogRecord[] GetRecord()
        {
            return _record;
        }

        public string GetText()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _index; i++)
            {
                sb.AppendLine(GetStringText(_record[i]));
            }

            return sb.ToString();
        }

        private string GetStringText(LogRecord record)
        {
            return $"{record.Date.ToLongDateString()}: {record.Type}: {record.Message}";
        }
    }
}
