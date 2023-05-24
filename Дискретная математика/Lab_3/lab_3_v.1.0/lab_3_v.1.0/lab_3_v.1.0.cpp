#include <iostream>
#include <cmath>
using namespace std;
int N, M;
int main() {
	setlocale(LC_CTYPE, "Russian");
	const int N = 6;
	int f, d;
	double matr1[N][N] =
	{
	{0, 0, 0, 0, 0, 0 },
	{0, 0, 0, 0, 0, 0 },
	{0, 0, 0, 0, 0, 0 },
	{0, 0, 0, 0, 0, 0 },
	{0, 0, 0, 0, 0, 0 },
	{0, 0, 0, 0, 0, 0 }
	};
	double matr[N][N] =
	{
	{0, 4, 9, 0, 0, 17 },
	{0, 0, 6, 22, 0, 15 },
	{0, 0, 0, 0, 22, 0 },
	{0, 0, 0, 0, 12, 11 },
	{0, 0, 0, 0, 0, 0 },
	{0, 0, 0, 0, 0, 0 }
	};

	cout << "Ishodnaya matrix: " << endl;
	for (f = 0; f < 6; f++)
	{
		for (d = 0; d < 6; d++)
		{

			cout << matr[f][d] << "  ";
		};
		cout << endl;
	};
	cout << endl;
	cout << " L = ";

	int min;
	int l = 1;
	int k;
	int j = 1;
	int s = 0;
	for (int p = 0; p < 5; p++)
	{
		min = 100;
		for (f = 0; f < j; f++)
		{
			for (d = 0; d <= 5; d++)
			{
				if ((matr[f][d] < min) && (matr[f][d] != 0))
				{
					l = d;
					k = f;
					min = matr[k][l];
				};
			};
		};
		for (int b = 0; b < 6; b++)
		{
			matr[b][l] = 0;
		};
		matr1[k][l] = min;
		matr1[l][k] = min;
		cout << min;
		if (p == 4)
		{
			p = p;
		}
		else
		{
			cout << " + ";
		}
		j = j + 1;
		s = s + min;
	};
	cout << " = ";
	cout << s << endl;
	cout << endl;
	cout << "ostoviy graph: " << endl;

	for (f = 0; f < 6; f++)
	{
		for (d = 0; d < 6; d++)
		{

			cout << matr1[f][d] << "  ";
		};
		cout << endl;
	};
	system("pause");
	return 0;
}
