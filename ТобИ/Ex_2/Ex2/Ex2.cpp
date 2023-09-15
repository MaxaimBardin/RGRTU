#include <iostream>
#include <cmath>

using namespace std;

//Функция для вычисления сумм
long double* Summa(long double x[], long double y[], long double* sum) {
    long double s1, s2, s3, s4;
    for (int i = 0; i < 10; i++) {
        sum[0] += x[i];
        sum[1] += pow(x[i], 2);
        sum[2] += y[i];
        sum[3] += x[i] * y[i];
    }
    return sum;
}
//Функция для определителя
long double Opred(long double a11, long double a12, long double a21, long double a22) {
    return a11 * a22 - (a12 * a21);
}

int main()
{
    setlocale(LC_ALL, "Russian");

    //Опишем массивы xi и yi
    long double x[10] {1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0};
    long double y[10] { 7.1,8.6,10.4,12.6,15.5,16.8,19.3,20.6,21.6,23.0 };

    //Вывод массивов X и Y
    cout << "   X   Y" << endl;
    for (int i = 0; i < 10;i++) {
        cout << i+1 << ". " << x[i] << "  " << y[i] << endl;
    }
    cout << endl;


    //Опишим массив суммы
    long double sum[4]{0.0,0.0,0.0,0.0};

    long double f[10];
    long double eps[10];

    long double E, emax, d, da0, da1,a0,a1;
    
    Summa(x, y, sum);
    cout << "Вычисление сумм"<<endl;
    for (int i = 0; i < 4; i++) {
        cout << "";
        cout <<"s"<<i+1<<" = " << sum[i] << endl;
    }

    cout << "Вычисление определителей"<<endl;
    d = Opred(sum[1], sum[0], sum[0], 10);
    cout << "d = " << d << endl;
    da0 = Opred(sum[1], sum[3], sum[0], sum[2]);
    cout << "da0 = " << da0 << endl;
    da1 = Opred(sum[3], sum[0], sum[2], 10);
    cout << "da1 = " << da1 << endl;

    a0 = da0 / d;
    a1 = da1 / d;
    cout << "Вычисление параметров" << endl;
    cout << "a0 = " << a0 <<"   a1 = " << a1 << endl;

    return 0;
}