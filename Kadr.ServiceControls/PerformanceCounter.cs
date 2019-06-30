using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Asbt.ServiceControls
{
    public class UWSPerformanceCounter1
    {

        [DllImport("Kernel32.dll")]
        public static extern void QueryPerformanceCounter(ref long ticks);

        public static long GetPCTime()
        {
            long startTime = 0;
            QueryPerformanceCounter(ref startTime);
            return startTime;
        }


        private static PerformanceCounter _TotalConnection;
        private static PerformanceCounter _TotalOperations;
        private static PerformanceCounter _OperationsPerSecond;
        private static PerformanceCounter _AverageDuration;

       

        public static void SetAverageDuration(long ticks)
        {
            if (!PerformanceCounterCategory.Exists("UniWcfServive"))
                CreatePCC();

            _AverageDuration = new PerformanceCounter();
            _AverageDuration.CategoryName = "UniWcfServive";
            _AverageDuration.CounterName = "average time per operation";
            _AverageDuration.MachineName = ".";
            _AverageDuration.ReadOnly = false;
            _AverageDuration.RawValue = 0;

            _AverageDuration.IncrementBy(ticks);
        }

        public static void SetOperationsPerSecond(bool IsInc)
        {
            if (!PerformanceCounterCategory.Exists("UniWcfServive"))
                CreatePCC();

            _OperationsPerSecond = new PerformanceCounter();
            _OperationsPerSecond.CategoryName = "UniWcfServive";
            _OperationsPerSecond.CounterName = "# operations / sec";
            _OperationsPerSecond.MachineName = ".";
            _OperationsPerSecond.ReadOnly = false;
            _OperationsPerSecond.RawValue = 0;

            if (IsInc)
                _OperationsPerSecond.Increment();
            else
                _OperationsPerSecond.Decrement();
        }

        public static void SetTotalOperations(bool IsInc)
        {
            if (!PerformanceCounterCategory.Exists("UniWcfServive"))
                CreatePCC();

            _TotalOperations = new PerformanceCounter();
            _TotalOperations.CategoryName = "UniWcfServive";
            _TotalOperations.CounterName = "# operations executed";
            _TotalOperations.MachineName = ".";
            _TotalOperations.ReadOnly = false;
            _TotalOperations.RawValue = 0;

            if (IsInc)
                _TotalOperations.Increment();
            else
                _TotalOperations.Decrement();
        }

        public static void SetTotalConnection(bool IsInc)
        {
            if (!PerformanceCounterCategory.Exists("UniWcfServive"))
                CreatePCC();

            _TotalConnection = new PerformanceCounter();
            _TotalConnection.CategoryName = "UniWcfServive";
            _TotalConnection.CounterName = "# Active connections";
            _TotalConnection.MachineName = ".";
            _TotalConnection.ReadOnly = false;
            _TotalConnection.RawValue = 0;

            if (IsInc)
                _TotalConnection.Increment();
            else
                _TotalConnection.Decrement();
        }

        public static void CreatePCC()
        {
            CounterCreationDataCollection counters = new CounterCreationDataCollection();

            CounterCreationData totalConn = new CounterCreationData();
            totalConn.CounterName = "# Active connections";
            totalConn.CounterHelp = "All Connection";
            totalConn.CounterType = PerformanceCounterType.NumberOfItems32;
            counters.Add(totalConn);


            // 1. counter for counting totals: PerformanceCounterType.NumberOfItems32
            CounterCreationData totalOps = new CounterCreationData();
            totalOps.CounterName = "# operations executed";
            totalOps.CounterHelp = "Total number of operations executed";
            totalOps.CounterType = PerformanceCounterType.NumberOfItems32;
            counters.Add(totalOps);

            // 2. counter for counting operations per second: PerformanceCounterType.RateOfCountsPerSecond32
            CounterCreationData opsPerSecond = new CounterCreationData();
            opsPerSecond.CounterName = "# operations / sec";
            opsPerSecond.CounterHelp = "Number of operations executed per second";
            opsPerSecond.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
            counters.Add(opsPerSecond);

            // 3. counter for counting average time per operation: PerformanceCounterType.AverageTimer32
            CounterCreationData avgDuration = new CounterCreationData();
            avgDuration.CounterName = "average_time_per_operation";
            avgDuration.CounterHelp = "Average duration per operation execution";
            avgDuration.CounterType = PerformanceCounterType.AverageTimer32;
            counters.Add(avgDuration);

            CounterCreationData avgDurationBase = new CounterCreationData();
            avgDurationBase.CounterName = "average time per operation base";
            avgDurationBase.CounterHelp = "Average duration per operation execution base";
            avgDurationBase.CounterType = PerformanceCounterType.AverageBase;
            counters.Add(avgDurationBase);

            // create new category with the counters above
            PerformanceCounterCategory.Create("UniWcfServive", "Asbt Uni Wcf Servive", PerformanceCounterCategoryType.SingleInstance,  counters);
        }
    }

}

