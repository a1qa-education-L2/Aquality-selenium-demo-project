# Демо проект по работе с корпоративным фреймворком Aquality selenium dotnet

# В проекте реализованы следующие тест-кейсы:

# TC - TC-0001 Check the cookie form

1) Перейти по url - https://www.a1qa.com/
2) Убедиться что cookies форма и кнопка подтверждения куки присутствует.
3) Нажать 'Подтвердить куки'.
4) Кнопка подтвержения куки отсутствует.
5) Форма cookies не отображается.

# TC - TC-0002 Check all navigation panel elements are present

1) Перейти по url - https://www.a1qa.com/ и подтвердить cookies.
2) Убедиться что все элементы меню присутствуют. 

# TC - TC-0003 Check how the Contact Us form works with an incorrect email

1) Перейти по url - https://www.a1qa.com/ и подтвердить cookies.
2) Перейти к Contact Us форме.
3) Убедиться что title правильный и все элементы формы присутствуют.
4) Заполнить все поля текстом. 
4) Убедиться как работает Terms check box.
5) Нажать 'Отправить'.
6) Убедиться что сообщение об неверном email отображается и оно правильное.

# TC - TC-0004 Check the footer form is correct with visual testing

1) Перейти по url - https://www.a1qa.com/ и подтвердить cookies.
2) Перейти к футеру.
3) Убедиться что элементы футера правильные (используя image comparator).

# TC - TC-0005 Check Custom Image Comparator

1) Используя кастомный image comparator сравнить 2 изображения.
