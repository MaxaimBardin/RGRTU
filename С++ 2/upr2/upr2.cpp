// upr2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>

int main()
{
	//1
	//1.1
	/*
	double n = 10.1;
	double *pn = &n;
	printf("Address: %p \n", (void*)pn);
	printf("Value %d \n", *pn);
	return 0;*/
	//1.2
	/*
	unsigned int n = 10;
	unsigned int* pn = &n;
	printf("Address: %p \n", (void*)pn);
	printf("Value %d \n", *pn);
	return 0;*/
	//1.3
	/*
	char n = 10;
	char *pn = &n;
	printf("Address: %p \n", (void*)pn);
	printf("Value %d \n", *pn);
	return 0;*/
	/*
	//2
	//2.1
	char n = 10;
	char *pn = &n;
	printf("Befor change: %d \n", *pn);
	*pn = 22;
	printf("After change: %d \n", *pn);
	//2.2
	unsigned long long n = 10;
	unsigned long long*pn = &n;
	printf("Befor change: %d \n", *pn);
	*pn = 22;
	printf("After change: %d \n", *pn);
	//2.3
	double n = 10;
	double *pn = &n;
	printf("Befor change: %d \n", *pn);
	*pn = 22;
	printf("After change: %d \n", *pn);*/
	/*
	//3 онлайн компилятор 
	setlocale(LC_ALL, "Russian");
	float n = 1.1;
	float *pn = &n;

	char *const Pract = "Практическая";

	printf("Constant: %ld\n", *pn);
	printf("Const pointer: %s\n", Pract);
	return 0;*/
	//4
	/*
	unsigned int array[] = { 1,2,3,4,5,6,7,8,9,10 };
	unsigned int *p = array;
	for (int i = 0; i < 10; i++) {
		printf("%d", p[i]);
		printf(" ");
	}
	printf("\n");
	for (int i = 0; i < 10; i++) {
		printf("%d", *(p + i));
		printf(" ");
	}
	return 0;*/
	//5 онлайн компилятор 
	/*
	setlocale(LC_ALL, "Russian");
	char* messge = "Доброе утро, товарищи радисты!!";
	printf("%s", messge);
	return 0;*/
	/*
	//6
	unsigned int array[] = { 3,4,5,6,7,8 };
	unsigned int* p = array;
	p = p + 2;
	printf("array[2] = %d\n", *p);
	p += 1;
	printf("array[3] = %d\n", *p);
	return 0;*/
	//7 онлайн компилятор
	char* person[] = { "Tom","Bob","Sam","Jack","Ivan","Vadim","Nikita","Sergey"};
	for (int i = 0; i < 3; i++)
	{
		printf("%s\n", person[i]);
	}
	return 0;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
