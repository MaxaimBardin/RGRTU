#include <iostream>

int main()
{
    int A, k;
    std::cout << "A: ";
    std::cin >> A;
    std::cout << "k: ";
    std::cin >> k;

    int mask = (1 << k) - 1;

    int result = A & mask;

    std::cout << result << std::endl;

    return 0;
}