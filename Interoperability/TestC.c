#include <stdio.h>
#include <stdlib.h>
#include "TestC.h"

int Add(int a, int b)
{
    return a+b;
}

void WriteString(char *content)
{
    printf("%s\n", content);
}

void AddInt(int *i)
{
    (*i)++;
}

void AddIntArray(int arr[10])
{
    int *currentPointer = &(arr[0]);
    for (int i = 0; i < 10; i++)
    {
        printf("%d", *currentPointer);
        currentPointer++;
    }
    printf("\n");
}

int* GetArrayFromCPP()
{
    int *arrPtr=(int*)malloc(10*sizeof(int));
    for (int i = 0; i < 10; i++)
    {
        arrPtr[i]=i;
    }

    return arrPtr;
}

void ReleaseMemory(int* ptr)
{
    free(ptr);
}

void SetCallback(CCallback callback)
{
    int tick=100;
    //下面的代码是对C#中委托进行调用
    callback(tick);
}

void SendStructFromCSToCPP(Vector3 vector)
{
    printf("got vector3 in c, x:%f, y:%f, z:%f\n", vector.x, vector.y, vector.z);
}
