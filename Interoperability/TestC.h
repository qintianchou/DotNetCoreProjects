int Add(int a, int b);

void WriteString(const char *content);

const char* ReturnString();

//传入一个整型指针，将其所指向的内容加1
void AddInt(int *i);

//传入一个整型数组，遍历每一个元素并且输出
void AddIntArray(int *arr, int length);

//在C++中生成一个整型数组，并且数组指针返回给C#
int* GetArrayFromCPP();

void ReleaseMemory(int* ptr);

//定义一个函数指针
typedef void (*CCallback)(int tick);

//定义一个用于设置函数指针的方法，并在该函数中调用C#中传递过来的委托
void SetCallback(CCallback callback);

typedef struct Vector3
{
    float x,y,z;
}Vector3;

Vector3 SendStructFromCSToCPP(Vector3 vector);
