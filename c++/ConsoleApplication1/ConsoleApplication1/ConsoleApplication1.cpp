#include <iostream>
#include <cmath>

int main()
{
	setlocale(LC_ALL, "Russian");
	double xmin, xmax, ymin, ymax;
	int nx, ny;

	std::cout << "Введите минимальное и максимальное значение x: ";
	std::cin >> xmin >> xmax;
	std::cout << "Введите минимальное и максимальное значение y: ";
	std::cin >> ymin >> ymax;
	std::cout << "Введите количество шагов по x и y: ";
	std::cin >> nx >> ny;

	double dx = (xmax - xmin) / nx;
	double dy = (ymax - ymin) / ny;

	std::cout << "x\t\ty\t\tf(x,y)" << std::endl;

	double x = xmin;
	double y;

	do {
		y = ymin;
		do {
			double result = 2 * sin(0.75 * x) + 3 * cos(2 * y);
			std::cout << x << "\t\t" << y << "\t\t" << result << std::endl;
			y += dy;
		} while (y <= ymax);
		x += dx;
	} while (x <= xmax);
	system("PAUSE");
	return 0;


	/*
    double x, present = 1.0, result = 0.0;
    int k, s;

    std::cout << "Введите значение x: ";
    std::cin >> x;
    std::cout << "Введите значение k: ";
    std::cin >> k;
    std::cout << "Введите значение s: ";
    std::cin >> s;

    for (int i = 1; i <= k; i++) {
        for (int n = 1; n <= s; n++) {
            double pr = sin(i + 2 * n) / ((2 * n + 1) * pow(x, 2 * n - 1));
            present *= pr;
            std::cout << "При i = " << i << " ,n = " << n << " Произведение: " << present << std::endl;
        }
        result += present;
        std::cout << "i = "<< i << " Сумма: " << result << std::endl;
    }

    std::cout << "Сумма произведений рядов: " << result;

	//while
	setlocale(LC_ALL, "Russian");
	double x;
	int k, s;
	double sum1 = 0.0;
	double sum2 = 0.0;
	int n = 1;
	int i = 1;

	std::cout << "Введите значение x: ";
	std::cin >> x;
	std::cout << "Введите значение k: ";
	std::cin >> k;
	std::cout << "Введите значение s: ";
	std::cin >> s;

	while (i <= k) {
		while (n <= s) {
			sum2 = sin(i + 2 * n) / ((2 * n + 1) * pow(x, 2 * n - 1));
			sum2 *= sum2;
			n++;
		}
		sum1 += sum2;
		i++;
		n = 1;
	}

	std::cout << "Сумма от произведения членов ряда: " << sum1 << std::endl;

	//do-while
	setlocale(LC_ALL, "Russian");
	double x;
	int k, s;
	double sum1 = 0.0;
	double sum2 = 0.0;
	int n = 1;
	int i = 1;

	std::cout << "Введите значение x: ";
	std::cin >> x;
	std::cout << "Введите значение k: ";
	std::cin >> k;
	std::cout << "Введите значение s: ";
	std::cin >> s;

	do {
		do {
			sum2 = sin(i + 2 * n) / ((2 * n + 1) * pow(x, 2 * n - 1));
			sum2 *= sum2;
			n++;
		} while (n <= s);
		sum1 += sum2;
		i++;
		n = 1;
	} while (i <= k);
	*/
    
}