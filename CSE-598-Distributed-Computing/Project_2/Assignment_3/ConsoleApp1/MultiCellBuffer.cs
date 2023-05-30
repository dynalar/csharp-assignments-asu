using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OperationScenario
{
    internal class MultiCellBuffer
    {
        private const int DefaultBufferSize = 5;

        private static Semaphore cellPool;

        public void setOneCell(string order) 
        {
            try
            {
                cellPool = Semaphore.OpenExisting(order);
            } catch(Exception e)
            {
                // if the semaphore doesnt exist, create a new one
                cellPool = new Semaphore(0, DefaultBufferSize, order);
            }


        }

        public void getOneCell(int index) 
        {

        }
    }
}
