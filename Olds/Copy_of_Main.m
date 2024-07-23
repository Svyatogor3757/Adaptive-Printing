%% Загрузка слоя из файла
% Загружаем слой из изображения
image = imread('Images/Image3.png');

% Преобразуем слой в оттенки серого
image_gs = imbinarize(image);
image_gs = image_gs(:,:,1) | image_gs(:,:,2) | image_gs(:,:,3);
% Размер изображения
image_size = size(image_gs)
%% Параметры адаптивной печати
% Разрешение печати в дюймах
dpi = 360
% Коэффициент преобразования миллиметров в пиксели 
dpmm = dpi/25.4
% По какому измерению работаем высота=1, ширина=2
% Измерение для нарезания подизображений
subimage_sep_dim = 1;
% Измерение для оценки на пустоту (белые пиксели)
if subimage_sep_dim == 1
    subimage_white_dim = 2;
else
    subimage_white_dim = 1;
end
% На сколько частей делим изображения
subimages_count = 6;
% Размер подизображения
subimage_size = floor(image_size(subimage_sep_dim)/subimages_count);
% Запас для установления постоянной скорости в пикселях
% Можно указать в миллиметрах, умножить на коэффициент преобразования dpmm
% и округлить в большую сторону (пиксель - неделимая величина)
% Например: subimages_margin = ceil(100 * dpmm);
subimages_margin = 200
% Размер рабочей зоны высотаХширина
workspace_size = [4000 8000]
% рабочая зона (для визуализации)
workspace = zeros([workspace_size 3]) + 150/255;
% Смещение от начала рабочей зоны в пикселях
Xstart_workspace = 100;
Ystart_workspace = 100;

%% Анализ фрагментов на начало и конец
dh = 0;
sub_offsetX = 0;
Xborder = zeros(subimages_count, 2);
for i = (1 - (mod(image_size(subimage_sep_dim),subimages_count) > 0)):subimages_count
    % !!!!! Отключена поддержка дробного разделения изображения на подслои,
    % при использовании в качестве входных данных неделимого нацело
    % изображения могут возникать ошибки.
    
    % Определяем, можем ли мы поделить изображение по частям нацело
    if i == 0
        % Если нет, то дорезаем остаток от изображения
        continue;
        dh2 = mod(image_size(subimage_sep_dim),subimages_count);
        sub_offsetX = dh2;
    else
        dh2 = subimage_size * i + sub_offsetX;
    end
    % Получаем 1 фрагмент изображения
    if(subimage_sep_dim == 1)
        sub = image_gs(dh+1:dh2,:);
    else
        sub = image_gs(:, dh+1:dh2);
    end
    sub_find_white = all(sub,subimage_sep_dim);
    if ~all(sub_find_white,'all')
       sub_find_black_index = find(sub_find_white==0); % ищем заполнители
       % Если нет начала или конца
       if length(sub_find_black_index) < 2
          if( sub_find_black_index > 1 && sum(sub(:,sub_find_black_index-1)) == 0)
              Xborder(i,1) = sub_find_black_index;
              Xborder(i,2)   = image_size(subimage_white_dim);
          else
              Xborder(i,1) = 1;
              Xborder(i,2)   = sub_find_black_index;
          end
       else
           Xborder(i,1)= sub_find_black_index(1);
           Xborder(i,2)  = sub_find_black_index(end);
       end
    end
    dh = dh2;
end

%% Формирование траектории печати с запасом subimages_margin
trackXY = [0 0];
sub_OffsetY = 0;
i = length(Xborder(:,1));
direction = 0;
while i > 1 
    if(Xborder(i,1) == 0 || Xborder(i,2) == 0)
        i = i + 1;
        sub_OffsetY = sub_OffsetY + subimage_size;
        trackXY(end+1,:) = [trackXY(end,1) sub_OffsetY];
        continue;
    end
    
    [OFFSETX, j] = get_offsetX(Xborder, i, subimages_margin, direction);
    if i == 2 && length(Xborder(:,1)) ~= subimages_count
        sub_OffsetY = sub_OffsetY + mod(image_size(subimage_sep_dim),subimages_count);
    else
        sub_OffsetY = sub_OffsetY + subimage_size * (i-j);
    end
    
    trackXY(end+1,:) = [OFFSETX sub_OffsetY];
    i = j;
    direction = ~direction;
end

%% Функция получения смещения по X
function [OFFSETX, j] = get_offsetX(Xborder, i, subimages_margin, direction)
OFFSETX = 0;
for j=i-1:-1:1
    if(Xborder(j,1) == 0 || Xborder(j,2) == 0)
        continue;
    end
    if mod(direction, 2) > 0
       % нечетный
       if Xborder(i,1) <= Xborder(j,1) - subimages_margin % Если первый больше заданного смещения
           OFFSETX = Xborder(i,1);
       else
           OFFSETX = Xborder(j,1) - subimages_margin;
       end
    else
       % четный 
       if Xborder(i,2) >= Xborder(j,2) + subimages_margin % Если первый больше заданного смещения
           OFFSETX = Xborder(i,2);
       else
           OFFSETX = subimages_margin + Xborder(j,2) ; %+  Xborder(j,1)
       end
    end
    break; 
end
end