Создайте WPF приложение, разместите в окне TextBox и две кнопки. При нажатии на первую
кнопку в TextBox выводится сообщение «Подключен к базе данных» при этом в обработчике
установите задержку в 3-5 сек для имитации подключения к БД, также данная кнопка запускает
таймер, который с периодичностью в несколько секунд выводит в TextBox сообщение «Данные
получены». При нажатии на вторую кнопку по аналогии с первой отключаемся от базы (с
задержкой), выводим сообщение и останавливаем таймер.