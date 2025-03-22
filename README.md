# mute this please

Программа для изменения громкости процессов по нажатию на горячую клавишу. / A program for changing the volume of processes by pressing a hotkey.

[Один из сценариев использования / One of the usage scenarios](https://github.com/hlhpage/mute-this-please?tab=readme-ov-file#один-из-сценариев-использования--one-of-the-usage-scenarios)

[Скачать / Download](https://github.com/hlhpage/mute-this-please?tab=readme-ov-file#скачать--download)

[Если захотите забилдить программу самостоятельно / If you want to build the program by yourself](https://github.com/hlhpage/mute-this-please?tab=readme-ov-file#если-захотите-забилдить-программу-самостоятельно--if-you-want-to-build-the-program-by-yourself)

[Интерфейс | Русский язык](https://github.com/hlhpage/mute-this-please?tab=readme-ov-file#русский-язык)

[Interface | English language](https://github.com/hlhpage/mute-this-please?tab=readme-ov-file#english-language)

[Локализация / Localization](https://github.com/hlhpage/mute-this-please?tab=readme-ov-file#локализация--localization)

[Ссылки / Links](https://github.com/hlhpage/mute-this-please?tab=readme-ov-file#ссылки--links)

## Один из сценариев использования / One of the usage scenarios

Играя в сессионные игры в одиночку, я часто включал на фон видео из браузера, однако были нередки моменты, когда необходимо прислушаться к происходящему в игре, а сворачивать приложение и ставить видео на паузу не очень удобно и забирает немало драгоценного времени. При помощи этой программы можно нажатием одной клавиши изменить громкость только у необходимых процессов.

When playing session games alone, I often turned on a video from the browser in the background, but there were often times when I needed to listen to what was happening in the game, and minimizing the application and pausing the video was not very convenient and took up a lot of precious time. With this program, you can change the volume of only the necessary processes by pressing a single key.

## Скачать / Download

Программа работает только на Windows / The program only works on Windows

[Релизы на GitHub / GitHub releases](https://github.com/hlhpage/mute-this-please/releases)

Программа портативная и не требует установки. Просто распакуйте содержимое архива в любое место. Все пользовательские настройки сохраняются в preferences.json в директории запуска. / The program is portable and does not require installation. Just unpack the contents of the archive to any location. All user settings are saved in preferences.json in the startup directory.

## Если захотите забилдить программу самостоятельно / If you want to build the program by yourself

В директории откуда запускается программа обязательно должны находится два файла "[mute.mp3](https://github.com/hlhpage/mute-this-please/blob/master/mute.mp3)" и "[unmute.mp3](https://github.com/hlhpage/mute-this-please/blob/master/unmute.mp3)". Потенциально вы можете использовать свои звуки, однако в качестве примера в корневой директории репозитория есть примеры таких файлов. Если билдите программу, то поместите эти файлы в директорию билда. Так же локализации на разные языки лежат в папке "[languages](https://github.com/hlhpage/mute-this-please/tree/master/languages)" в директории откуда запускается программа, однако если ни одного файла локализации внутри не будет, то программа автоматически создаст файл локализации на русском языке в директории исполнения exe файла, но препятствием для запуска отсутствие файлов локализаций не будет. Тоже применимо к файлу с настройками "preferences.json". При его отсутствии программа создаст его в директории исполнения exe файла.

In the directory from where the program is launched, there must be two files "[mute.mp3](https://github.com/hlhpage/mute-this-please/blob/master/mute.mp3)" and "[unmute.mp3](https://github.com/hlhpage/mute-this-please/blob/master/unmute.mp3)". You can potentially use your own sounds, however, as an example, there are examples of such files in the root directory of the repository. If you are building a program, then place these files in the build directory. Localizations for different languages are also located in the "[languages](https://github.com/hlhpage/mute-this-please/tree/master/languages)" folder in the directory from where the program is launched, however, if there are no localization files inside, the program will automatically create a localization file in Russian in the exe file execution directory, but the lack of localization files will not be an obstacle to launching. The same applies to the settings file "preferences.json". If it is missing, the program will create it in the executable directory of the exe file.

## Интерфейс / Interface

### Русский язык

[![ru-Numbered.webp](https://i.postimg.cc/yxwL0Fsf/ru-Numbered.webp)](https://postimg.cc/H890g8J5)

__1 - Кнопка "За работу!"__ переводит программу в режим работы с установленными настройками. Активна только если в списке сфокусированных программ есть хотя бы одна позиция. В режиме работы изменение настроек невозможно, поэтому для внесения изменений необходимо сначала прекратить работу.
#### Устройство воспроизведения звука

__2 - Список устройств воспроизведения звука__ в котором можно выбрать устройство для которого будет работать программа. Автоматически обновляется только при первом запуске программы.

__3 - Кнопка "Обновить список активных устройств"__ обновляет список (2) и показывает доступные на момент нажатия устройства воспроизведения звука.
#### Режим работы

__4 - Список с доступными локализациями__. Подробнее про локализации [тут](https://github.com/hlhpage/mute-this-please/blob/master/README.md#локализация--localization).

__5 - Радиокнопка "Чёрный список"__ определяет режим работы программы. В режиме чёрного списка громкость будет меняться только у процессов, которые находятся в списке сфокусированных программ.

__6 - Радиокнопка "Белый список"__ определяет режим работы программы. В режиме белого списка громкость будет меняться у всех процессов, кроме тех которые находятся в списке сфокусированных программ.

__7 - Чекбокс "Сворачивать программу в трей"__. Если он активный, то при сворачивании программы она будет сворачиваться в трей. В противном случае программа будет сворачиваться в пуск.
#### Уровень громкости

__8 - Ползунок__, который позволяет регулировать уровень громкости до которого будет изменяться громкость программ во время работы по нажатию на горячую клавишу.
#### Горячие клавиши

__9 - Текущая горячая клавиша изменения громкости__ во время работы программы.

__10 - Кнопка "Изменить"__ позволяет поменять горячую клавишу изменения громкости.

__11 - Текущая горячая клавиша прекращения работы__ программы. В режиме работы изменение настроек недоступно, поэтому для чтобы внести изменения в параметры, необходимо завершить режим работы. 

__12 - Кнопка "Изменить"__ позволяет поменять горячую клавишу прекращения работы.
#### Громкость звуковой индикации

__13 - Ползунок__, который позволяет регулировать уровень громкости звукового эффекта при нажатии на горячую клавишу изменения громкости во время режима работы.
#### Список сфокусированных программ

__14 - Список сфокусированных программ__ сообщает программе с какими процессами необходимо взаимодействовать. Манера взаимодействия зависит от того какой режим работы выбран (белый список или чёрный список).

__15 - Кнопка "Добавить программу из микшера"__ позволяет выбрать из процессов, которые активны в микшере громкости, и добавить их в список сфокусированных программ.

__16 - Кнопка "Добавить программу по названию процесса"__ позволяет добавить программу в список сфокусированных программ по названию.

__17 - Кнопка "Удалить программу из списка"__  позволяет выбрать программы из списка сфокусированных программ и удалить ненужные пункты.

### English language

[![en-Numbered.webp](https://i.postimg.cc/T2WF3wRk/en-Numbered.webp)](https://postimg.cc/YjMbXtLg)

__1 - Button "Let's get to work!"__ puts the program into operation mode with the set settings. It is active only if there is at least one position in the list of focused programs. It is not possible to change the settings in the operating mode, therefore, to make changes, you must first stop working.
#### Audio output device

__2 - List of audio playback devices__ in which you can select the device for which the program will run. It is automatically updated only when the program is started for the first time.

__3 - Button "Update active devices list"__ updates list (2) and shows the audio playback devices available at the time of pressing.
#### Work mode

__4 - List with available localizations__. Learn more about localization [here](https://github.com/hlhpage/mute-this-please/blob/master/README.md#локализация--localization).

__5 - Radio button "Blacklist"__ determines the operating mode of the program. In blacklist mode, the volume will only change for processes that are in the list of focused programs.

__6 - Radio button "Whitelist"__ determines the program's operating mode. In whitelist mode, the volume will change for all processes except those in the list of focused programs.

__7 - Checkbox "Minimize to tray"__. If it is active, then when the program is minimized, it will be minimized to the tray. Otherwise, the program will collapse to start.
#### Volume level

__8 - Trackbar__ that allows you to adjust the volume level to which the volume of programs will change during operation by pressing a hotkey.
#### Hotkeys

__9 - Current hotkey for changing the volume__ while the program is running.

__10 - Button "Change"__ allows you to change the volume control hotkey.

__11 - Current hotkey for terminating the program__. Changing the settings is not available in the operating mode, so in order to make changes to the parameters, you must end the operating mode. 

__12 - Button "Change"__ allows you to change the exit hotkey.
#### Sound indication volume

__13 - Trackbar__ that allows you to adjust the volume level of the sound effect when pressing the volume control hotkey during operation.
#### Focused programs list

__14 - Focused programs list__ tells the program which processes need to be interacted with. The manner of interaction depends on which operating mode is selected (whitelist or blacklist).

__15 - Button "Add program from Mixer"__ allows you to select from the processes that are active in the volume mixer and add them to the focused programs list. 

__16 - Button "Add program by process name"__ allows you to add a program to the focused programs list by name.

__17 - The "Delete program from the list" button__ allows you to select programs from the focused programs list and delete unnecessary items.

## Локализация / Localization

В корневой директории есть папка languages, внутри которой лежат файлы локализаций, которые используются для отображения всех текстов в программе. По желанию вы можете можете отредактировать уже существующий файл или дублировать один из файлов, переименовать его и перевести существующие строчки на свой язык без ущерба другим локализациям. Важно, чтобы в строчке под номером 32 содержалось два идентификатора [KEY] (программа заменяет их на горячие клавиши, установленные пользователем). Ещё рекомендуется сохранять все переносы строк (\n). Никто не мешает вам удалить ненужные файлы локализаций, если это необходимо. Оригинальный язык программы - русский, но в релизной версии есть переводы на английский, упрощённый китайский, испанский, бразильский португальский, немецкий, японский, французский и польский с использованием ChatGPT.

There is a languages folder in the root directory, which contains localization files that are used to display all texts in the program. Optionally, you can edit an existing file or duplicate one of the files, rename it and translate the existing lines into your language without prejudice to other localizations. It is important that the line number 32 contains two [KEY] identifiers (the program replaces them with user-defined keyboard shortcuts). It is also recommended to save all line breaks (\n). No one prevents you from deleting unnecessary localization files, if necessary. The original language of the program is Russian, but the release version has translations into English, Simplified Chinese, Spanish, Brazilian Portuguese, German, Japanese, French and Polish using ChatGPT.

## Ссылки / Links

Телеграм канал / Telegram channel

https://t.me/hlhpage

Почта для связи / Contact email

hlhmail@vk.com
