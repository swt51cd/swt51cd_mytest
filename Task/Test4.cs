using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task
{
    class Test4
    {
        public static void OneTask()
        {
            Console.WriteLine("主线程执行业务处理.");
            //创建任务
            System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(() =>
            {
                Console.WriteLine("使用System.Threading.Tasks.Task执行异步操作.");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                }
            });
            //启动任务,并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
            task.Start();
            Console.WriteLine("主线程执行其他处理");
            //主线程挂起1000毫秒，等待任务的完成。
            Thread.Sleep(1000);
            Console.WriteLine("END 主线程完成");
        }

        /// <summary>
        /// 等待任务的完成并获取返回值
        /// </summary>
        public static void TaskWait()
        {
            Task<int> task = new Task<int>(() =>
                            {
                                int sum = 0;
                                Console.WriteLine("使用Task执行异步操作.");
                                for (int i = 0; i < 100; i++)
                                {
                                    sum += i;
                                }
                                return sum;
                            });
            //启动任务,并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
            task.Start();
            Console.WriteLine("主线程执行其他处理");
            //等待任务的完成执行过程。

            task.Wait();
            //获得任务的执行结果
            Console.WriteLine("任务执行结果：{0}", task.Result.ToString());
        }

        /// <summary>
        /// 在使用能够Task类的Wait方法等待一个任务时或派生类的Result属性获得任务执行结果都有可能阻塞线程，
        /// 为了解决这个问题可以使用ContinueWith方法，他能在一个任务完成时自动启动一个新的任务来处理执行结果
        /// </summary>
        public static void TaskContinueWith()
        {
            Task<int> task = new Task<int>(() =>
            {
                int sum = 0;
                Console.WriteLine("使用Task执行异步操作.");
                for (int i = 0; i < 100; i++)
                {
                    sum += i;
                }
                return sum;
            });
            //启动任务,并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
            task.Start();
            Console.WriteLine("主线程执行其他处理");

            //任务完成时执行处理。
            System.Threading.Tasks.Task cwt = task.ContinueWith(t =>
            {
                Console.WriteLine("任务完成后的执行结果：{0}", t.Result.ToString());
            });
            Thread.Sleep(1000);
        }
        /// <summary>
        /// 创建父子任务和任务工厂的使用
        /// 通过Task类创建的任务是顶级任务，可以通过使用 TaskCreationOptions.AttachedToParent 标识把这些任务与创建他的任务相关联，
        /// 所有子任务全部完成以后父任务才会结束操作
        /// </summary>
        public static void ParentChildTask()
        {
            Task<string[]> parent = new Task<string[]>(state =>
            {
                Console.WriteLine(state);
                string[] result = new string[2];
                //创建并启动子任务
                new System.Threading.Tasks.Task(() => { result[0] = "我是子任务1。"; }, TaskCreationOptions.AttachedToParent).Start();
                new System.Threading.Tasks.Task(() => { result[1] = "我是子任务2。"; }, TaskCreationOptions.AttachedToParent).Start();
                return result;
            }, "我是父任务，并在我的处理过程中创建多个子任务，所有子任务完成以后我才会结束执行。");
            //任务处理完成后执行的操作
            parent.ContinueWith(t =>
            {
                Array.ForEach(t.Result, r => Console.WriteLine(r));
            });
            //启动父任务
            parent.Start();
            Console.WriteLine("END");
        }
        /// <summary>
        /// 如果需要创建一组具有相同状态的任务时，可以使用TaskFactory类或TaskFactory<TResult>类。这两个类创建一组任务时可以指定任务的
        /// CancellationToken、TaskCreationOptions、TaskContinuationOptions和TaskScheduler默认值。
        /// </summary>
        public static void TaskFactoryApply()
        {
            System.Threading.Tasks.Task parent = new System.Threading.Tasks.Task(() =>
                 {
                     CancellationTokenSource cts = new CancellationTokenSource(5000);
                     //创建任务工厂
                     TaskFactory tf = new TaskFactory(cts.Token, TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
                     //添加一组具有相同状态的子任务
                     System.Threading.Tasks.Task[] task = new System.Threading.Tasks.Task[]{
                                        tf.StartNew(() => { Console.WriteLine("我是任务工厂里的第一个任务。"); }),
                                        tf.StartNew(() => { Console.WriteLine("我是任务工厂里的第二个任务。"); }),
                                        tf.StartNew(() => { Console.WriteLine("我是任务工厂里的第三个任务。"); })
                            };
                 });
            parent.Start();
            Console.Read();
        }

    }
}
