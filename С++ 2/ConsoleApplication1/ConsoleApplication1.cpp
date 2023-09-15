#include <iostream>
#include <cmath>

int main()
{
	//14
	setlocale(LC_ALL, "Russian");
    double x;
    int n, nMax;
    double sum = 0.0;

    std::cout << "Введите значение x: ";
    std::cin >> x;
    std::cout << "Введите количество членов ряда n: ";
    std::cin >> nMax;

    n = 1;
    do {
        double term = pow(-1, n) * (pow(x, 2 * n - 1)) / (2 * n - 1);
        sum += term;
        n++;
    } while (n <= nMax);

    std::cout << "Сумма бесконечного ряда: " << sum << std::endl;
    system("PAUSE");
	return 0;
    /*
    //3
    float x, y, z;
    std::cout << "Введите значение x: ";
    std::cin >> x;
    std::cout << "Введите значение y: ";
    std::cin >> y;

    if (x < -2) 
        return 0;
        else  if (x < 0) 
                z = x + exp(y);
              else if (x < 5)
                     z = x - (2 * exp(y));
                   else z = x * x + y * y;
           

    std::cout << "Результат " << z;
    system("PAUSE");
    return 0;
    //9
    int A, B;
    int sum = 0;

    std::cout << "Введите значение A: ";
    std::cin >> A;
    std::cout << "Введите значение B: ";
    std::cin >> B;

    for (int i = A; i <= B; i+=2) {
            sum += i;
    }

    std::cout << "Сумма нечетных чисел от " << A << " до " << B << ": " << sum << std::endl;

    return 0;
    int main() {
        int A, B;
        int sum = 0;

        std::cout « "Введите значение A: ";
        std::cin » A;
        std::cout « "Введите значение B: ";
        std::cin » B;

        int i = A;
        while (i <= B) {
                sum += i;
            i+=2;
        }

        std::cout « "Сумма нечетных чисел от " « A « " до " « B « ": " « sum « std::endl;

        return 0;
    }
    int main() {
int A, B;
int sum = 0;

std::cout « "Введите значение A: ";
std::cin » A;
std::cout « "Введите значение B: ";
std::cin » B;

int i = A;
while (i <= B) {
if (i % 2 != 0) {
sum += i;
}
i++;
}

std::cout « "Сумма нечетных чисел от " « A « " до " « B « ": " « sum « std::endl;

return 0;
}
    int main() {
        int A, B;
        int sum = 0;

        std::cout « "Введите значение A: ";
        std::cin » A;
        std::cout « "Введите значение B: ";
        std::cin » B;

        int i = A;
        do {
            sum += i;
            i+=2;
        } while (i <= B);

        std::cout « "Сумма нечетных чисел от " « A « " до " « B « ": " « sum « std::endl;

        return 0;
    }*/
    //8
    //8
    //for
    setlocale(LC_ALL, "Russian");
    double x;
    int k, b;
    double sum = 0.0;
    double pr = 1.0;
    std::cout << "Введите значение x: ";
    std::cin >> x;
    std::cout << "Введите значение k: ";
    std::cin >> k;
    std::cout << "Введите значение b: ";
    std::cin >> b;

    for (int p = 1; p <= k; p++) {
        pr = 1.0;
        for (int w = 1; w <= b; w++) {
            
            pr *= sin(p+2*w)/((2*w+1)*pow(x,2*w-1));
            std::cout << "w = " << w << " pr = "<< pr << std::endl;
        }
        std::cout << "p = " << p << " sum = " << sum << std::endl;
        sum += pr;
    }

    std::cout << "Сумма конечная членов ряда: " << sum << std::endl;

    system("PAUSE");
    return 0;/*
    //while
    setlocale(LC_ALL, "Russian");
    double x;
    int k, b;
    double sum = 0.0;
    double pr = 1.0;
    int w = 1;
    int p = 1;

    std::cout << "Введите значение x: ";
    std::cin >> x;
    std::cout << "Введите значение k: ";
    std::cin >> k;
    std::cout << "Введите значение b: ";
    std::cin >> b;

    while (p <= k) {
        while (w <= b) {
            pr *= sin(p + 2 * w) / ((2 * w + 1) * pow(x, 2 * w - 1));;
            w += 1;
        }
        sum += pr;
        p += 1;
        w = 1;
    }

    std::cout << "Сумма от произведения членов ряда: " << sum << std::endl;

    system("PAUSE");
    return 0;
    //do-while
    setlocale(LC_ALL, "Russian");
    double x;
    int k, b;
    double sum = 0.0;
    double pr = 1.0;
    int w = 1;
    int p = 1;

    std::cout << "Введите значение x: ";
    std::cin >> x;
    std::cout << "Введите значение k: ";
    std::cin >> k;
    std::cout << "Введите значение b: ";
    std::cin >> b;

    do {
        do {
            pr*= sin(p + 2 * w) / ((2 * w + 1) * pow(x, 2 * w - 1));;
            w += 1;
        } while (w <= b);
        sum += pr;
        p += 1;
        w = 1;
    } while (p <= k);

    std::cout << "Сумма от произведения членов ряда: " << sum << std::endl;

    return 0;

    system("PAUSE");
    return 0;*/
}