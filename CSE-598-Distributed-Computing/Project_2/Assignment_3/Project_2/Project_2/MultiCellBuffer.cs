using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_2
{
    internal class MultiCellBuffer
    {
        private List<string> cells;
        private readonly Semaphore semaphore;
        private const int totalCells = 5;

        // making an instance so I can access without making a new instance
        private static MultiCellBuffer instance;

        public static MultiCellBuffer Instance
        {
            get
            {
                // hacky way to call an instance for multi cell buffer
                if (instance == null)
                {
                    instance = new MultiCellBuffer(totalCells);
                }
                return instance;
            }
        }

        private MultiCellBuffer(int n)
        {
            this.cells = new List<string>(n);
            this.semaphore = new Semaphore(n, n);
        }

        // using lists for cells since arrays were too problematic
        public void SetOneCell(string data)
        {
            // wait for available cells by setting semaphore
            semaphore.WaitOne();

            lock (cells)
            {
               cells.Add(data);
            }
            
            // release the resource
            semaphore.Release();
        }

        
        public string GetOneCell()
        {
            // set the semaphore so we dont get access errors
            semaphore.WaitOne();

            // lock all cells before we access
            lock (cells)
            {
                int index = 0;
                foreach (string cell in cells)
                {
                    string cellData = cell;
                    cells.RemoveAt(index);
                    index++;
                    return cellData;
                }
            }

            // release the semaphore once we've gotten an item back
            semaphore.Release();

            // return null if nothing found
            return null;
        }
    }
}
