using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Interoperability
{
    //定义一个委托，返回值为空，存在一个整型参数
    public delegate void CSCallback(int tick);

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        public float x, y, z;
    }

    class Program
    {
        #region DllImport

        [DllImport("TestC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int a, int b);

        [DllImport("TestC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void WriteString(string c);

        [DllImport("TestC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ReturnString();

        [DllImport("TestC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddInt(ref int i);

        [DllImport("TestC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddIntArray(int[] arr, int length);

        [DllImport("TestC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetArrayFromCPP();

        [DllImport("TestC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReleaseMemory(IntPtr ptr);

        //这里使用CSCallback委托类型来兼容C里的CCallback函数指针
        [DllImport("TestC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCallback(CSCallback callback);

        [DllImport("TestC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 SendStructFromCSToCPP(Vector3 vector);

        #endregion

        //定义一个用于回调的方法，与前面定义的委托的原型一样，该方法会被C所调用
        public static void CSCallbackFunction(int tick)
        {
            Console.WriteLine(tick.ToString());
        }

        //定义一个委托类型的实例，在主程序中该委托实例将指向前面定义的CSCallbackFunction方法
        public static CSCallback callback;

        public static void Main(string[] args)
        {
            int c = Add(1, 2);
            Console.WriteLine(c);

            //调用c中的WriteString
            WriteString("hello");

            var ptr = ReturnString();
            Console.WriteLine(Marshal.PtrToStringAnsi(ptr));
            ReleaseMemory(ptr);

            // 调用C中的AddInt方法
            int i = 10;
            AddInt(ref i);
            Console.WriteLine(i);

            //调用C++中的AddIntArray方法将C#中的数据传递到C++中，并在C++中输出
            int[] CSArray = new int[10];
            for (int iArr = 0; iArr < 10; iArr++)
            {
                CSArray[iArr] = iArr;
            }
            AddIntArray(CSArray, CSArray.Length);

            //调用C++中的GetArrayFromCPP方法获取一个C中建立的数组
            IntPtr pArrayPointer = GetArrayFromCPP();
            int[] result = new int[10];
            Marshal.Copy(pArrayPointer, result, 0, 10);
            for (int iArr = 0; iArr < 10; iArr++)
            {
                Console.Write(result[iArr]);
            }
            Console.WriteLine();

            //释放内存
            ReleaseMemory(pArrayPointer);

            //让委托指向将被回调的方法
            callback = CSCallbackFunction;

            //将委托传递给C++
            SetCallback(callback);

            //建立一个Vector3的实例
            Vector3 vector = new Vector3(){ x = 10, y = 20, z = 30 };

            //将vector传递给C++并在C++中输出
            Vector3 v = SendStructFromCSToCPP(vector);
            Console.WriteLine("({0}, {1}, {2})", v.x, v.y, v.z);
        }
    }
}
