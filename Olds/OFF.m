% Создание трехмерной матрицы, содержащей значения цвета RGB
rgb_values = zeros(100, 100, 3);
rgb_values(:,:,1) = 0/255; % Значение красного цвета
rgb_values(:,:,2) = 0/255; % Значение зеленого цвета
rgb_values(:,:,3) = 255/255; % Значение синего цвета
% Вывод трехмерной матрицы как изображения
%colormap(gca, jet(256));
imshow(rgb_values);

%   % Анализ 1 фрагмента
%     dswd = 1:subimages_margin:image_size(subimage_white_dim);
%     if dswd(end) ~= image_size(subimage_white_dim)
%         dswd(end) =  image_size(subimage_white_dim);
%     end
%     if mod(i,2) > 0
%     % Если текущий фрагмент нечетный
%         dswd = flip(dswd);
%     end
%     
%     for j=2:length(dswd)
%         % Проврка на четность
%         if  mod(i,2) == 0
%             sub_borders = dswd(j-1):dswd(j);
%         else
%             sub_borders = dswd(j):dswd(j-1);
%         end
%         sub_find_white = all(sub(:, sub_borders));
%         if all(sub_find_white)
%            continue;
%         end
%         
%     end
%     
%     
%     
%     %%%%%%%%%%%%%%
%      dh2 = floor(image_size(subimage_sep_dim)/6) * (i-1);
%     % Получаем 1 фрагмент изображения
%     if(subimage_sep_dim == 1)
%         sub = image_gs(dh2 +1:dh,:);
%     else
%         sub = image_gs(:, dh2 +1:dh);
%     end
%     
%       % Анализ 1 фрагмента
%     sub_find_white = all(sub);
%     if all(sub_find_white)
%        % Если весь фрагмент пустой
%     else
%        sub_find_black_index = find(sub_find_white==0); % ищем заполнители
%        if mod(i,2) > 0
%             % Если текущий фрагмент нечетный
%              sub_black_index = sub_find_black_index(end);
%        else
%             sub_black_index = sub_find_black_index(1);
%             if sub_black_index - subimages_margin > 0
%                 
%             end
%        end
%     
%     end