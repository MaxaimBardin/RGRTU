#include <iostream>
#include <cmath>

using namespace std;

//Функция для вычисления сумм
long double* Summa(long double x[], long double y[], long double* sum) {
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
//Функция для определителя 3*3
long double Opred2(long double a11, long double a12, long double a13, long double a21,
    long double a22,long double a23, long double a31, long double a32, long double a33 ) {
    return a11 * Opred(a22, a23, a32, a33) - a21 * Opred(a12, a13, a32, a33) + a31 * Opred(a12, a13, a22, a23);
}

int main()
{
    setlocale(LC_ALL, "Russian");

    //Опишем массивы xi и yi
    long double x[10] {1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0};
    long double y[10] { 7.1, 8.6, 10.4, 12.6, 15.5, 16.8, 19.3, 20.6, 21.6, 23.0 };

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

    //Расчет аппроксимирующих значений и вычисление погрешности
    E = 0.0;
    emax = 0.0;
    for (int i = 0; i < 10; i++) {
        f[i] = a1 * x[i] + a0;
        cout << "f" << i + 1 << " = " << f[i] << endl;
        eps[i] = f[i] - y[i];
        E += eps[i] * eps[i];
        if (abs(eps[i]) > emax) {
            emax = abs(eps[i]);
        }
    }
    cout << endl << "E = " << E << "   emax = " << emax << endl;
    cout << "Реализация квадратичной аппроксимации" << endl;

    long double sum2[7]{ 0.0,0.0,0.0,0.0,0.0,0.0,0.0 };
    long double da2, a2;

    for (int i = 0; i < 10; i++) {
        sum2[0] += x[i];
        sum2[1] += pow(x[i], 2);
        sum2[2] += pow(x[i], 3);
        sum2[3] += pow(x[i], 4);
        sum2[4] += y[i];
        sum2[5] += x[i] * y[i];
        sum2[6] += pow(x[i], 2) * y[i];
    }

    //Вывод новых сумм
    cout << "Новые суммы" << endl;
    for (int i = 0; i < 7; i++) {
        cout << "s" << i+1 << " = " << sum2[i] << endl;
    }

    d = Opred2(10, sum2[0], sum2[1], sum2[0], sum2[1], sum2[2], sum2[1], sum2[2], sum2[3]);
    da0 = Opred2(sum2[4], sum2[0], sum2[1], sum2[5], sum2[1], sum2[2], sum2[6], sum2[2], sum2[3]);
    da1 = Opred2(10, sum2[4], sum2[1], sum2[0], sum2[5], sum2[2], sum2[1], sum2[6], sum2[3]);
    da2 = Opred2(10, sum2[0], sum2[4], sum2[0], sum2[1], sum2[5], sum2[1], sum2[2], sum2[6]);
    a2 = da2 / d;
    a0 = da0 / d;
    a1 = da1 / d;
    cout << "Новые определители и других параметров" << endl;
    cout << endl << "d = " << d << "   da0 = " << emax <<  "   da1 = " << da1 << "   da2 = " 
        << da2 << "   a2 = " << a2 << endl;
    
    E = 0.0;
    emax = 0.0;
    

    for (int i = 0; i < 10; i++) {
        f[i] = a2 * x[i] * x[i] + a1 * x[i] + a0;
        cout << "f" << i + 1 << " = " << f[i] << endl;
        eps[i] = f[i] - y[i];
        cout << "eps" << i + 1 << " = " << eps[i] << endl;
        E += eps[i] * eps[i];
        if (abs(eps[i]) > emax) {
            emax = abs(eps[i]);
        }
    }
    cout << endl << "E = " << E << "   emax = " << emax << endl;

    return 0;
}