//setlocale(LC_ALL, "Russian");
#include <iostream>
#include <limits>

int main() {
    char* person[] = { "Max","Tom","Vova","Chert" };
    for (int i = 0; i < 3; i++) {
        printf("%s\n", person[i]);
    }
    return 0;
}
