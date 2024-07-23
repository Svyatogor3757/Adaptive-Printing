% Количество запусков скрипта
scriptN = 100;

% Запускаем скрипт N раз и сохраняем время выполнения
scripttimes = zeros(scriptN,1);
set(groot, 'DefaultFigureVisible', 'off');
for scripti = 1:scriptN
    scripti
    tic;
    % Отключаем графический вывод для текущей итерации
    run('Copy_of_Main.m'); % название вашего скрипта
    scripttimes(scripti) = toc;
end

% Строим график зависимости времени от запуска
set(groot, 'DefaultFigureVisible', 'on');
figure
plot(1:scriptN, scripttimes, 'o-', 'LineWidth', 2)
xlabel('Номер запуска')
ylabel('Время выполнения, с')
grid on