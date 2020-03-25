#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "TestC.h"

int Add(int a, int b)
{
    return a+b;
}

void WriteString(const char *content)
{
    printf("%s\n", content);
}

const char* ReturnString()
{
    char* str = "hello";
    char* result = (char*)malloc(strlen(str) + 1);
    strcpy(result, str);
    return result;
}

void AddInt(int *i)
{
    (*i)++;
}

void AddIntArray(int *arr, int length)
{
    for (int i = 0; i < length; i++)
    {
        printf("%d", arr[i]);
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

Vector3 SendStructFromCSToCPP(Vector3 vector)
{
    printf("got vector3 in c, x:%f, y:%f, z:%f\n", vector.x, vector.y, vector.z);
    vector.x += 1;
    vector.y += 1;
    vector.z += 1;
    return vector;
}
