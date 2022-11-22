<h1>Приложение для хранения файлов</h1>
<p>Необходимо реализовать:</p>
<ol>
	<li>Вход в аккаунт. Аккаунт содержит личные данные пользователя и загруженные файлы.</li>
	<li>Просмотр списка загруженных файлов.</li>
	<li>Загрузку файла в хранилище.</li>
	<li>Удаление файла. После удаления файл перемещается в корзину</li>
	<li>Скачивание файла.</li>
	<li>Поиск файла по имени (или маске), расширению (может быть).</li>
	<li>Просмотр файла.</li>
	<li>Сортировку списка файлов по:
	<ul>
		<li>дате создания;</li>
		<li>имени файла;</li>
	</ul>
	</li>
</ol>
	
<p>Запись о файле содержит следующие данные:</p>
<ol>
	<li>Имя файла.</li>
	<li>Путь к файлу.</li>
	<li>Дата создания.</li>
	<li>Дата последнего изменения.</li>
</ol>

<h2>База данных</h2>
![image](https://user-images.githubusercontent.com/87008317/197803590-91aeed0b-b7f7-4ccf-bb5b-f7f347988ec4.png)


<h3>Описание к базе:</h3>
<h4>Таблица user содержит информацию о пользователе.</h4>
<p>id — pk</p>
<p>Логин</p>
<p>Пароль</p>
<p>Email — ak</p>

<p>У каждого пользователя есть возможность добавлять файлы в хранилище.</p>
<h4>Таблица file содержит информацию о файле:</h4>
<p>id — pk</p>
<p>Имя файла</p>
<p>Дата добавления</p>
<p>Дата последнего изменения</p>
<p>Путь к файлу (расположение)</p>
<p>Тип файла</p>
