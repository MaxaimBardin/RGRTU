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
    return a11 * Opred(a22, a23, a32, a33) - a21 * Opred(a12, a13, a32, a33) +
        a31 * Opred(a12, a13, a22, a23);
}

long double Opred3(long double a11, long double a12, long double a13, long double a14,
    long double a21, long double a22, long double a23, long double a24,
    long double a31, long double a32, long double a33, long double a34,
    long double a41, long double a42, long double a43, long double a44) {
    return a11 * Opred2(a22, a23, a24, a32, a33, a34, a42, a43, a44)
        - a21 * Opred2(a12, a13, a14, a32, a33, a34, a42, a43, a44)
        + a31 * Opred2(a12, a13, a14, a22, a23, a24, a42, a43, a44)
        - a41 * Opred2(a12, a13, a14, a22, a23, a24, a32, a33, a34);
}
long double Opred4(long double a11, long double a12, long double a13, long double a14, long double a15,
    long double a21, long double a22, long double a23, long double a24, long double a25,
    long double a31, long double a32, long double a33, long double a34, long double a35,
    long double a41, long double a42, long double a43, long double a44, long double a45,
    long double a51, long double a52, long double a53, long double a54, long double a55) {
    return a11 * Opred3(a22, a23, a24, a25,
        a32, a33, a34, a35,
        a42, a43, a44, a45,
        a52, a53, a54, a55)
        - a21 * Opred3(a12, a13, a14, a15,
            a32, a33, a34, a35,
            a42, a43, a44, a45,
            a52, a53, a54, a55)
        + a31 * Opred3(a12, a13, a14, a15,
            a22, a23, a24, a25,
            a42, a43, a44, a45,
            a52, a53, a54, a55)
        - a41 * Opred3(a12, a13, a14, a15,
            a22, a23, a24, a25,
            a32, a33, a34, a35,
            a52, a53, a54, a55)
        + a51 * Opred3(a12, a13, a14, a15,
            a22, a23, a24, a25,
            a32, a33, a34, a35,
            a42, a43, a44, a45);
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
        cout << "eps" << i + 1 << " = " << eps[i] << endl;
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

    cout << "Вычисление кубической аппроксимации" << endl;
    long double sum3[10]{ 0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0 };
    long double da3, a3;

    for (int i = 0; i < 10; i++) {
        sum3[0] += x[i];
        sum3[1] += pow(x[i], 2);
        sum3[2] += pow(x[i], 3);
        sum3[3] += pow(x[i], 4);
        sum3[4] += pow(x[i], 5);
        sum3[5] += pow(x[i], 6);
        sum3[6] += y[i];
        sum3[7] += x[i] * y[i];
        sum3[8] += pow(x[i], 2) * y[i];
        sum3[9] += pow(x[i], 3) * y[i];
    }

    cout << "Суммы" << endl;
    for (int i = 0; i < 10; i++) {
        cout << "s" << i + 1 << " = " << sum3[i] << endl;
    }
    cout << "Определители" << endl;
    da3 = 0.0;
    a3 = 0.0;
    d = Opred3(10, sum3[0], sum3[1], sum3[2],
        sum3[0], sum3[1], sum3[2], sum3[3],
        sum3[1], sum3[2], sum3[3], sum3[4],
        sum3[2], sum3[3], sum3[4], sum3[5]);
    da0 = Opred3(sum3[6], sum3[0], sum3[1], sum3[2],
        sum3[7], sum3[1], sum3[2], sum3[3],
        sum3[8], sum3[2], sum3[3], sum3[4],
        sum3[9], sum3[3], sum3[4], sum3[5]);
    da1 = Opred3(10, sum3[6], sum3[1], sum3[2], 
        sum3[0], sum3[7], sum3[2], sum3[3], 
        sum3[1], sum3[8], sum3[3], sum3[4], 
        sum3[2], sum3[9], sum3[4], sum3[5]);
    da2 = Opred3(10, sum3[0], sum3[6], sum3[2], 
        sum3[0], sum3[1], sum3[7], sum3[3], 
        sum3[1], sum3[2], sum3[8], sum3[4], 
        sum3[2], sum3[3], sum3[9], sum3[5]);
    da3 = Opred3(10, sum3[0], sum3[1], sum3[6], 
        sum3[0], sum3[1], sum3[2], sum3[7], 
        sum3[1], sum3[2], sum3[3], sum3[8], 
        sum3[2], sum3[3], sum3[4], sum3[9]);
    a2 = da2 / d;
    a0 = da0 / d;
    a1 = da1 / d;
    a3 = da3 / d;
    cout << "Определители и другие параметры в кубической аппроксимации" << endl;
    cout << endl << "d = " << d << "   da0 = " << emax
        << "   da1 = " << da1 <<endl << "   da2 = "
        << da2 <<"  da3 = "<< da3 << endl << "a0 = " << a0 << "  a1 = " << a1 << "   a2 = " << a2
        << "  a3 = " << a3<<endl;

    for (int i = 0; i < 10; i++) {
        f[i] = a3* pow(x[i],3)+ a2 * x[i] * x[i] + a1 * x[i] + a0;
        cout << "f" << i + 1 << " = " << f[i] << endl;
        eps[i] = f[i] - y[i];
        cout << "eps" << i + 1 << " = " << eps[i] << endl;
        E += eps[i] * eps[i];
        if (abs(eps[i]) > emax) {
            emax = abs(eps[i]);
        }
    }
    cout << endl << "E = " << E << "   emax = " << emax << endl;
    cout << "Реализация аппроксимации полинома 4-й степени" << endl;
    long double sum4[13] = { 0.0, 0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0 };
    long double da4, a4;
    for (int i = 0; i < 10; i++) {
        sum4[0] += x[i];
        sum4[1] += pow(x[i], 2);
        sum4[2] += pow(x[i], 3);
        sum4[3] += pow(x[i], 4);
        sum4[4] += pow(x[i], 5);
        sum4[5] += pow(x[i], 6);
        sum4[6] += pow(x[i], 7);
        sum4[7] += pow(x[i], 8);
        sum4[8] += y[i];
        sum4[9] += x[i] * y[i];
        sum4[10] += pow(x[i], 2) * y[i];
        sum4[11] += pow(x[i], 3) * y[i];
        sum4[12] += pow(x[i], 4) * y[i];
    }
    cout << "Суммы" << endl;
    for (int i = 0; i < 13; i++) {
        cout << "s" << i + 1 << " = " << sum4[i] << endl;
    }
    d = Opred4(10, sum4[0], sum4[1], sum4[2], sum4[3],
        sum4[0], sum4[1], sum4[2], sum4[3], sum4[4],
        sum4[1], sum4[2], sum4[3], sum4[4], sum4[5], 
        sum4[2], sum4[3], sum4[4], sum4[5], sum4[6], 
        sum4[3], sum4[4], sum4[5], sum4[6], sum4[7]);
    da0 = Opred4(sum4[8], sum4[0], sum4[1], sum4[2], sum4[3],
        sum4[9], sum4[1], sum4[2], sum4[3], sum4[4],
        sum4[10], sum4[2], sum4[3], sum4[4], sum4[5],
        sum4[11], sum4[3], sum4[4], sum4[5], sum4[6],
        sum4[12], sum4[4], sum4[5], sum4[6], sum4[7]);
    da1 = Opred4(10, sum4[8], sum4[1], sum4[2], sum4[3], 
        sum4[0], sum4[9], sum4[2], sum4[3], sum4[4], 
        sum4[1], sum4[10], sum4[3], sum4[4], sum4[5], 
        sum4[2], sum4[11], sum4[4], sum4[5], sum4[6],
        sum4[3], sum4[12], sum4[5], sum4[6], sum4[7]);
    da2 = Opred4(10, sum4[0], sum4[8], sum4[2], sum4[3],
        sum4[0], sum4[1], sum4[9], sum4[3], sum4[4], 
        sum4[1], sum4[2], sum4[10], sum4[4], sum4[5], 
        sum4[2], sum4[3], sum4[11], sum4[5], sum4[6], 
        sum4[3], sum4[4], sum4[12], sum4[6], sum4[7]);
    da3 = Opred4(10, sum4[0], sum4[1], sum4[8], sum4[3],
        sum4[0], sum4[1], sum4[2], sum4[9], sum4[4],
        sum4[1], sum4[2], sum4[3], sum4[10], sum4[5],
        sum4[2], sum4[3], sum4[4], sum4[11], sum4[6],
        sum4[3], sum4[4], sum4[5], sum4[12], sum4[7]);
    da4 = Opred4(10, sum4[0], sum4[8], sum4[2], sum4[8],
        sum4[0], sum4[1], sum4[2], sum4[3], sum4[9],
        sum4[1], sum4[2], sum4[3], sum4[4], sum4[10],
        sum4[2], sum4[3], sum4[4], sum4[5], sum4[11],
        sum4[3], sum4[4], sum4[5], sum4[6], sum4[12]);
    
    a0 = da0 / d;
    a1 = da1 / d;
    a2 = da2 / d;
    a3 = da3 / d;
    a4 = da4 / d;
    cout << "Определители и другие параметры в аппроксимации полинома 4-й степени" << endl;
    cout << endl << "d = " << d << "   da0 = " << emax
        << "   da1 = " << da1 << endl << "da2 = "
        << da2 << "  da3 = " << da3 <<"  da4 = "<< da4 << endl << "a0 = " << a0 << "  a1 = " << a1 << "   a2 = " << a2
        << "  a3 = " << a3 << "  a4 = "<< a4 << endl;

    for (int i = 0; i < 10; i++) {
        f[i] = a4 * pow(x[i], 4) + a3 * pow(x[i], 3) + a2 * x[i] * x[i] + a1 * x[i] + a0;
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