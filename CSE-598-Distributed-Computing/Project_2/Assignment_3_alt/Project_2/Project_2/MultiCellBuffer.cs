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
        private readonly int n;
        private readonly string[] cells;
        private readonly Semaphore semaphore;
        private readonly object[] locks;
        private const int totalCells = 5;

        // making an instance so I can access without making a new instance
        private static MultiCellBuffer instance;

        public static MultiCellBuffer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MultiCellBuffer(totalCells); // Set the number of cells here
                }
                return instance;
            }
        }

        private MultiCellBuffer(int n)
        {
            this.n = n;
            this.cells = new string[n];
            this.semaphore = new Semaphore(n, n);
            this.locks = new object[n];
            for (int i = 0; i < n; i++)
            {
                locks[i] = new object();
            }
        }

        public void SetOneCell(string data)
        {
            semaphore.WaitOne(); // Wait for an available cell

            lock (cells)
            {
                for (int i = 0; i < totalCells; i++)
                {
                    if (cells[i] == null)
                    {
                        cells[i] = data;
                        break;
                    }
                }
            }
        }

        
        public string GetOneCell()
        {
            semaphore.WaitOne();

            lock (cells)
            {
                for (int i = 0; i < totalCells; i++)
                {
                    if (cells[i] != null)
                    {
                        return cells[i];
                    }
                }
            }

            // release the semaphore once we've gotten an item back
            semaphore.Release();

            // return null if nothing found
            return null;
        }
    }
}
