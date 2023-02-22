using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphVisualizingApp
{
    public class Edge
    {
        public bool isConnected;
        public int rowNum;
        public int colNum;

        public Edge(string val, string _rowNum, string _colNum)
        {
            if (val == "0")
            {
                isConnected = false;
            } else
            {
                isConnected = true;
            }

            rowNum = Int32.Parse(_rowNum);
            colNum = Int32.Parse(_colNum);
        }
    }
}
