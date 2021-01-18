using System;
using System.Threading;
public class deadlockk
{/// <summary>
/// 
/// </summary>
    static object locker1 = new object();
    static object locker2 = new object();
    static void aa()
    {
        
         lock (locker1)         
        {
            try
            {
                //Monitor.Enter(locker1);
                   Thread.Sleep (100);                    
                Console.WriteLine
         (Thread.CurrentThread.Name + " locks(locker1)");

                lock (locker2) ;
                Console.WriteLine(Thread.CurrentThread.Name + " Requests to  lock  (locker2");

            }
            finally
            {
                //Monitor.Exit(locker1);
            }

        }
    }
    static void bb()
    {
         lock (locker2)       
        {
            try
            {
               // Monitor.Enter(locker2);


                  Thread.Sleep (100);        
                Console.WriteLine
               (Thread.CurrentThread.Name + " locks(locker2)");
                lock (locker1) ;

                Console.WriteLine
                (Thread.CurrentThread.Name + " Requests to  lock  (locker1)");
            }
            finally
            {
               // Monitor.Exit(locker2);
            }
        }
    }


    static public void Main()
    {
        Console.WriteLine
 ("Deadlock...........");
        Thread t1 = new Thread(aa);

        Thread t2 = new Thread(bb);
        t1.Name = "T1";
        t2.Name = "T2";
        t1.Start();
        t2.Start();
        t2.Join();
        Console.WriteLine("end   xxxxxxxxxxvxxxvxxvx");
    }

} 