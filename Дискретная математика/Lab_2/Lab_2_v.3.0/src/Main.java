package Maks;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import javax.swing.JFrame;

    // Метод класса, с которого начинает всё выполняться
public static void main(String[] args) {
        GraphDemo gd = new GraphDemo();
// Определяем заголовок окна
        gd.setTitle("Пример графики на Java");
// Определяем размер окна
        gd.setSize(300, 300);
// Запрещаем пользователю изменять размеры окна
        gd.setResizable(false);
// Определяем, что при закрытии окна заканчивается работа
// программы
        gd.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
// Делаем окно видимым
        gd.setVisible(true);
    }
}