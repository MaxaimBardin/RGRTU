#include <iostream>
#include <cmath>
using namespace std;
int N, M;
int main() {
	setlocale(LC_CTYPE, "Russian");
	const int N = 6;
	const int M = 9;
	int f, d;
	double matr1[N][M];
	double matr[N][N]
	{
	{0, 1, 1, 0, 0, 1 },
	{1, 0, 1, 1, 0, 1 },
	{1, 1, 0, 0, 1, 0 },
	{0, 1, 0, 0, 1, 1 },
	{0, 0, 1, 1, 0, 0 },
	{1, 1, 0, 1, 0, 0 },
	};
	cout << "Преобразованная матрица смежности:" << endl;
	for (f = 0; f < 6; f++)
	{
		for (d = 0; d < 6; d++)
		{
			if ((matr[f][d] == 1) && (matr[f][d] == matr[d][f]))
			{
				matr[d][f] = 0;
			}
			cout << matr[f][d] << "  ";
		}
		cout << endl;
	};
	cout << endl;
	int h = 0;
	int m = 0;
	for (f = 0; f < 6; f++)
	{
		for (d = 0; d < 6; d++)
		{
			if (matr[f][d] == 1)
			{
				for (m = 0; m < 6; m++)
				{
					matr1[m][h] = 0;
				}
				matr1[f][h] = 1;
				matr1[d][h] = 1;
				h++;
			}
		}
	}
	cout << "Матрица инцидентности:" << endl;
	for (f = 0; f < 6; f++)
	{
		for (d = 0; d < 9; d++)
		{
			cout << matr1[f][d] << "  ";
		}
		cout << endl;
	};
	cout << endl;
}
