using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace try1
{
    public partial class EPISODE_1 : Form
    {

        Меню menu; //объект меню для дальнейшего взаимодействия
        int army = 0; //переменные сохраняющие какой вариант выбран
        int hide = 0;
        int guyansw = 0;
        int listen = 0;
        int count = 1; //счетчик отвечающий за то какой диалог будет отображаться
        int stages = 52; //количество экранов между которыми можно переходить
        int pr = 0; //процент прогресса главы
        int gg = 0;
        bool forw = true;
        bool back = true;
        int video = 1;
        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        public WMPLib.WindowsMediaPlayer WMP2 = new WMPLib.WindowsMediaPlayer();

        public EPISODE_1(Меню меню) //это окно получает ссылку на скрытое окно меню, чтобы позже снова отобразить его перед закрытием
        {
            InitializeComponent();
            menu = меню;
            FormBorderStyle = FormBorderStyle.None; //настройки стиля окна
            WindowState = FormWindowState.Maximized;
            progresspl(count);
            this.KeyDown += new KeyEventHandler(EPISODE_1_KeyDown);
        }

        private void progresspl(int count)
        {
            if (count != stages)
            {
                pr += 100 / 50;
            }
            else
                pr = 100;
            if (pr >= 100)
                pr = 100;
            label5.Text = "ПРОГРЕСС ГЛАВЫ: " + pr + "%";
        }

        private void progressmi(int count)
        {
            if (count != 1)
            {
                pr -= 100 / 50;
            }
            else
                pr = 2;
            if (pr <= 0)
                pr = 0;
            label5.Text = "ПРОГРЕСС ГЛАВЫ: " + pr + "%";
        }

        private void forward(object sender, EventArgs e)
        {
            if (count != stages && forw)
                count++; //увеличения счетчика после чего будет выведен следующий диалог
            else
                return;
            progresspl(count);
            switch (count)
            {
                case 1:
                    label4.Text = "Двести лет назад планета Аррис оказалась на грани уничтожения. Тёмный сгусток массы неизвестного происхождения чуть не уничтожил человечество. Люди назвали эти существа - Тенями.";
                    pictureBox1.Image = Properties.Resources.frame1;
                    break;
                case 2:
                    label4.Text = "Склизкие бесформенные тёмные оболочки, что обрели разум, обрекли человечество на полное уничтожение. И только некоторым повезло остаться в живых и не заразиться.";
                    break;
                case 3:
                    label4.Text = "Эти существа проникали во внутрь человека и уничтожали изнутри. Но некоторым людям удалось сохранить дееспособность и разум. Таких обрекли на участь с экспериментами.";
                    break;
                case 4:
                    label4.Text = "Шли годы и человечество адаптировалось. Но изменения коснулись не только человека. Люди отгородились от этих сущностей. На тех участках, где ещё возможно было существовать живому организму, они возвели свои защитные стены и организовали быт.";
                    pictureBox1.Image = Properties.Resources.frame2;
                    break;
                case 5:
                    label4.Text = "В настоящее время существуют специальные организации, которые следят за мутациями и исследуют их. Военные организации имеют у себя на руках нескольуо крупных проектов по использованию особых людей. Сейчас таких людей используют как оружие, ведь они наделены сверхчеловеческими способностями. А некоторые даже способны управлять Тенями.";
                    break;
                case 6:
                    label4.Text = "Эти люди сейчас могут жить мирно, но только если не будут отобраны в армию или спецслужбами. Планета Аррис сейчас больше похожа на раздробленную по частям землю, на которых где-то живут люди, а где-то обитают неизвестные пораженные сущностями твари и Тени. Для защиты населения от таких вот ужасов и устривают отбор детей от 16-ти до 18-ти лет для первой группы, и для второй группы от 20 до 35 лет. Почему есть бреш между возрастами, никому неизвестно, точнее гражданам. Скорее всего это связанно с мутациями организма, и именно в этот период происходит спад активности мутации.";
                    break;
                case 7:
                    label4.Text = "Сегодня день отбора. И один участик - наша главная героиня. Рэй МаКкей, девятнадцать лет. Ей уже удавалось увернуться от армии. Но получится ли в этот раз?\nНеожиданно кто-то похлопал её по плечу сзади и она повернулась.";
                    pictureBox1.Image = Properties.Resources.frame3;
                    pictureBox2.Visible = true;
                    WMP2.URL = "Resources/second.mp3";
                    WMP2.controls.play();
                    break;
                case 8:
                    label4.Text = "Парень\n— Привет, ты также не горишь желанием служить как и больштнство собравшихся?";
                    pictureBox7.Visible = true;
                    hideuiarmy();
                    break;
                case 9:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = true;
                    chtxtarmy();
                    break;
                case 10:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Парень быстро посмотрел по сторонам, словно в замешательстве. Он не знал куда деться. А затем закричал и убежал. За ним сразу выдвинулась группа людей в военной форме.";
                    break;
                case 11:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Девушка молча смотрела за всеми действиями незнакомца, а затем повернулась в сторону приготовленной сцены. Вот-вот начнётся речь.";
                    break;
                case 12:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Оккола Наиса\n— Добрый день, я Оккола Наиса, командир старшей поисковой группы ФПС (прим. федеральная поисковая служба). Вы здесь, потому что нужны своей планете. Чтобы защитить ее от атак и угроз извне. Молодые и сильные, вы способны на многое, некоторые из вас даже на нечто невероятное. Ваши мутации и то, кто вы есть привели вас сюда. Вы - спасение человечества. И помните, Организация заботится о Вас.";
                    break;
                case 13:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Да возможно это так, но скорее всего, все эти дети здесь всего лишь пушечное мясо. Так же размышляет и МаКкей. Ей уже доволилось видеть ужасы битв против Теней, когда ее родители отправились в путешествие на остров Кайа, чтобы вдохнавится новыми дикими пейзажами, что остались после бойни. Но досталась им лишь кровавая баня и психологическая травма.";
                    break;
                case 14:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\nВозможно стоит спрятаться или убежать пока есть шанс?";
                    hideuihide();
                    break;
                case 15:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    chtxthide();
                    break;
                case 16:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\nДосадно, не выйдет.";
                    break;
                case 17:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Будущих бойцов повели по коридору. Всюду стояли солдаты, и от этого Рэй стало не по себе.";
                    break;
                case 18:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Image = Properties.Resources.frame4;
                    WMP2.URL = "Resources/beforevideo2.mp3";
                    WMP2.controls.play();
                    label4.Text = "Оккола Наиса\n— Пройдите в комнату, чтобы переодеться в специальное оборудывание. Мы будем следить за вашим состоянием. В костюмах установлены датчики, что позволят нам узнать о вашем физическом и психическом состоянии. Всё это ради вашего блага.";
                    break;
                case 19:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Оккола Наиса\n— Первым испытанием будет выдержка. Мы определим по уровню вашего стресса, сколько времени вы можете продержаться под воздействием Теней. Не беспокойтесь, до летального исхода не дойдёт.";
                    break;
                case 20:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Оккола Наиса\n— Специальная группа ликвидации как только обнаружит высокий выплеск энергии, тут же прибудет в комнату и обезвредит Тень, а вас выведут и направят на осмотр. И помните, Организация заботится о Вас.";
                    break;
                case 21:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\nНичего себе «безопасно». А если они не успеют? Мда. Вот это я понимаю з-забота. Остаётся только надеяться, что я не умру.";
                    break;
                case 22:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    video1();
                    label4.Text = "Рэй\n— Что это было?";
                    break;
                case 23:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй в ужасе стояла некоторое время, пока её не подтолкнул какой-то паренёк.";
                    break;
                case 24:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = true;
                    label4.Text = "Парень\n— Чего стоишь? Двигай, давай.";
                    hideuiguyansw();
                    break;
                case 25:
                    if (guyansw == 1)
                    {
                        pictureBox2.Visible = true;
                        pictureBox7.Visible = true;
                        label4.Text = "Рэй\n— Я сейчас тебе двину.";
                    }
                    else if (guyansw == 2)
                    {
                        pictureBox7.Visible = false;
                        pictureBox2.Visible = false;
                        label4.Text = "Рэй смиренно продолжила шагать в сторону комнаты.";
                    }
                    break;
                case 26:
                    if (guyansw == 1)
                    {
                        pictureBox2.Visible = false;
                        pictureBox7.Visible = false;
                        label4.Text = "Резко заявила девушка. Парень не выдержал такого отношения к себе, и они уже было замахнулись друг на друга, как позади послышалось:";
                    }
                    else if (guyansw == 2)
                    {
                        pictureBox2.Visible = true;
                        pictureBox7.Visible = false;
                        label4.Text = "Рэй\nЧто же это было?";
                    }
                    break;
                case 27:
                    if (guyansw == 1)
                    {
                        pictureBox2.Visible = false;
                        pictureBox7.Visible = false;
                        label4.Text = "Оккола Наиса\n— До начала испытания две минуты. Опоздавшие будут считаться беглецами и понесут наказание. И помните Организация заботится о Вас.";
                    }
                    else if (guyansw == 2)
                    {
                        pictureBox2.Visible = false;
                        pictureBox7.Visible = false;
                        label4.Text = "Эта мысль ещё долго крутилась в её голове.";
                    }
                    break;
                case 28:
                    if (guyansw == 1)
                    {
                        pictureBox2.Visible = false;
                        pictureBox7.Visible = false;
                        label4.Text = "В этот момент оба охладели, понимая, что если продолжат бессмысленную перепалку, окажутся в печальном положении, и как можно быстрее направились в комнату.";
                    }
                    else if (guyansw == 2)
                    {
                        pictureBox2.Visible = false;
                        pictureBox7.Visible = false;
                        label4.Text = "Оккола Наиса\n— До начала испытания две минуты. Опоздавшие будут считаться беглецами и понесут наказание. И помните Организация заботится о Вас.";
                    }
                    break;
                case 29:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "В комнате, в которую заходили люди, висели костюмы. И все одинаковые. Пространство было предельно на две части. Для мужчин и женщин соответственно.";
                    break;
                case 30:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй схватила первый попавшийся костюм. Быстро стянула с себя верхнюю одежду на глазах у всех и, запрыгивая на ходу в костюм, направилась в следующую комнату.";
                    break;
                case 31:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "\"Ненормальная какая-то.\", сказал кто-то позади Рэй.";
                    break;
                case 32:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Image = Properties.Resources.Pictures3;
                    label4.Text = "В этой комнате было достаточно темно. Но в начале, откуда вышла девушка, было больше всего света. Поэтому Рэй там и осталась.";
                    break;
                case 33:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Остальные же заняли свои места ближе к концу комнаты в более тёмных условиях.";
                    break;
                case 34:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Image = Properties.Resources.Pictures1;
                    label4.Text = "Оккола Наиса\n— Счастливого вам испытания и пусть удача всегда будет на вашей стороне. И помните, Организация заботится о вас.";
                    break;
                case 35:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\n— Где-то я это уже слышала...";
                    break;
                case 36:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй осмотрела лица присутствующих. На одной из девушек лица не было. Другая пыталась её взбодрить. Но видимо безуспешно. У стенки сидели парни и о чем-то разговаривали. Больше всего было жаль того паренька, которого тогда поймали на собрании. Он в ужасе стоял у одной из колонн.";
                    break;
                case 37:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Девушка 1\n— Та брехня это всё!\nДевушка 2\n— Да тише ты.";
                    break;
                case 38:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Кто-то что-то бурно обсуждал.";
                    break;
                case 39:
                    hideuilisten();
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\nМожет мне стоит подслушать?";
                    break;
                case 40:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    if (listen == 1)
                        label4.Text = "Рэй уже было хотела подползти послушать, но...";
                    else if (listen == 2)
                        label4.Text = "Рэй\n— Зачем мне слушать чьи-то бредни.";
                    break;
                case 41:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    video2();
                    pictureBox1.Image = Properties.Resources.Pictures2;
                    label4.Text = "Паника воцарилась в комнате. Истошные крики резали уши. Кто-то начал плакать.";
                    break;
                case 42:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Напуганный парень\n— Нет! О нет! Только не это! Я еще так молод, чтобы умирать!";
                    break;
                case 43:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Такие выходки лишь забавляли Рэй, ведь ей было совсем не страшно.";
                    break;
                case 44:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Голос неизвестного\n— Чего смеёшься?";
                    break;
                case 45:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Вдруг послышалось из ниоткуда.";
                    break;
                case 46:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\n— Кто здесь?";
                    break;
                case 47:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Голос неизвестного\n— Я?";
                    break;
                case 48:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\n— Я, это кто?";
                    break;
                case 49:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй было испугалась, но после этого диалога снова развеселилась.";
                    break;
                case 50:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Голос неизвестного\n— А ты посмотри вверх.";
                    break;
                case 51:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Девушка подняла голову и увидела...";
                    break;
                case 52:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    video3();
                    break;
                default:break;
            }
        }

        private void hideuiarmy()
        {
            forw = false;
            button2.Visible = false; //скрывается навигация по диалогам и появляются варианты для выбора
            pictureBox8.Visible = true; //вывод на экран кнопок с вариантами выбора
            pictureBox9.Visible = true;
        }

        private void hideuihide()
        {
            forw = false;
            button2.Visible = false; //скрывается навигация по диалогам и появляются варианты для выбора
            pictureBox3.Visible = true; //вывод на экран кнопок с вариантами выбора
            pictureBox4.Visible = true;
        }

        private void hideuiguyansw()
        {
            forw = false;
            button2.Visible = false; //скрывается навигация по диалогам и появляются варианты для выбора
            pictureBox11.Visible = true; //вывод на экран кнопок с вариантами выбора
            pictureBox12.Visible = true;
        }

        private void hideuilisten()
        {
            forw = false;
            button2.Visible = false; //скрывается навигация по диалогам и появляются варианты для выбора
            pictureBox13.Visible = true; //вывод на экран кнопок с вариантами выбора
            pictureBox14.Visible = true;
        }

        private void EPISODE_1_Load(object sender, EventArgs e) //функция задает начальное изображение и текст в диалоге, а также делает фон объектов интерфейса прозрачным
        {
            pictureBox1.Image = Properties.Resources.frame1;
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            label4.Text = "Двести лет назад планета Аррис оказалась на грани уничтожения. Тёмный сгусток массы неизвестного происхождения чуть не уничтожил человечество. Люди назвали эти существа - Тенями.";
            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
            pictureBox2.Visible = false;
            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Visible = false;
            pictureBox4.Parent = pictureBox1;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Visible = false;
            pictureBox5.Parent = pictureBox1;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.Parent = pictureBox1;
            pictureBox6.BackColor = Color.Transparent;
            pictureBox7.Parent = pictureBox1;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Visible = false;
            pictureBox8.Parent = pictureBox1;
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Visible = false;
            pictureBox9.Parent = pictureBox1;
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label7.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Parent = pictureBox1;
            pictureBox11.BackColor = Color.Transparent;
            pictureBox11.Visible = false;
            pictureBox12.Parent = pictureBox1;
            pictureBox12.BackColor = Color.Transparent;
            pictureBox12.Visible = false;
            pictureBox13.Parent = pictureBox1;
            pictureBox13.BackColor = Color.Transparent;
            pictureBox13.Visible = false;
            pictureBox14.Parent = pictureBox1;
            pictureBox14.BackColor = Color.Transparent;
            pictureBox14.Visible = false;
            WMP2.URL = "Resources/first.mp3";
            WMP2.controls.play();
            WMP2.settings.volume = 100;
        }

        private void main(object sender, EventArgs e) //переход от игры к меню
        {
            menu.Show();
            Close();
        }

        private void backward(object sender, EventArgs e)
        {
            if (count != 1 && back)
                count--; //уменьшение счетчика после чего будет выведен предыдущий диалог
            else
                return;
            progressmi(count);
            switch (count)
            {
                case 1:
                    label4.Text = "Двести лет назад планета Аррис оказалась на грани уничтожения. Тёмный сгусток массы неизвестного происхождения чуть не уничтожил человечество. Люди назвали эти существа - Тенями.";
                    pictureBox1.Image = Properties.Resources.frame1;
                    break;
                case 2:
                    label4.Text = "Склизкие бесформенные тёмные оболочки, что обрели разум, обрекли человечество на полное уничтожение. И только некоторым повезло остаться в живых и не заразиться.";
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.frame1;
                    label4.Text = "Эти существа проникали во внутрь человека и уничтожали изнутри. Но некоторым людям удалось сохранить дееспособность и разум. Таких обрекли на участь с экспериментами.";
                    break;
                case 4:
                    label4.Text = "Шли годы и человечество адаптировалось. Но изменения коснулись не только человека. Люди отгородились от этих сущностей. На тех участках, где ещё возможно было существовать живому организму, они возвели свои защитные стены и организовали быт.";
                    pictureBox1.Image = Properties.Resources.frame2;
                    break;
                case 5:
                    label4.Text = "В настоящее время существуют специальные организации, которые следят за мутациями и исследуют их. Военные организации имеют у себя на руках нескольуо крупных проектов по использованию особых людей. Сейчас таких людей используют как оружие, ведь они наделены сверхчеловеческими способностями. А некоторые даже способны управлять Тенями.";
                    break;
                case 6:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Image = Properties.Resources.frame2;
                    WMP2.URL = "Resources/first.mp3";
                    WMP2.controls.play();
                    label4.Text = "Эти люди сейчас могут жить мирно, но только если не будут отобраны в армию или спецслужбами. Планета Аррис сейчас больше похожа на раздробленную по частям землю, на которых где-то живут люди, а где-то обитают неизвестные пораженные сущностями твари и Тени. Для защиты населения от таких вот ужасов и устривают отбор детей от 16-ти до 18-ти лет для первой группы, и для второй группы от 20 до 35 лет. Почему есть бреш между возрастами, никому неизвестно, точнее гражданам. Скорее всего это связанно с мутациями организма, и именно в этот период происходит спад активности мутации.";
                    break;
                case 7:
                    hidech();
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Сегодня день отбора. И один участик - наша главная героиня. Рэй МаКкей, девятнадцать лет. Ей уже удавалось увернуться от армии. Но получится ли в этот раз?\nНеожиданно кто-то похлопал её по плечу сзади и она повернулась.";
                    pictureBox1.Image = Properties.Resources.frame3;
                    WMP2.controls.play();
                    break;
                case 8:
                    label4.Text = "Парень\n— Привет, ты также не горишь желанием служить как и больштнство собравшихся?";
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = true;
                    hideuiarmy();
                    break;
                case 9:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = true;
                    chtxtarmy();
                    break;
                case 10:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Парень быстро посмотрел по сторонам, словно в замешательстве. Он не знал куда деться. А затем закричал и убежал. За ним сразу выдвинулась группа людей в военной форме.";
                    break;
                case 11:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Девушка молча смотрела за всеми действиями незнакомца, а затем повернулась в сторону приготовленной сцены. Вот-вот начнётся речь.";
                    break;
                case 12:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Оккола Наиса\n— Добрый день, я Оккола Наиса, командир старшей поисковой группы ФПС (прим. федеральная поисковая служба). Вы здесь, потому что нужны своей планете. Чтобы защитить ее от атак и угроз извне. Молодые и сильные, вы способны на многое, некоторые из вас даже на нечто невероятное. Ваши мутации и то, кто вы есть привели вас сюда. Вы - спасение человечества. И помните, Организация заботится о Вас.";
                    break;
                case 13:
                    hidech();
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Да возможно это так, но скорее всего, все эти дети здесь всего лишь пушечное мясо. Так же размышляет и МаКкей. Ей уже доволилось видеть ужасы битв против Теней, когда ее родители отправились в путешествие на остров Кайа, чтобы вдохнавится новыми дикими пейзажами, что остались после бойни. Но досталась им лишь кровавая баня и психологическая травма.";
                    break;
                case 14:
                    hideuihide();
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\nВозможно стоит спрятаться или убежать пока есть шанс?";
                    break;
                case 15:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    chtxthide();
                    break;
                case 16:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\nДосадно, не выйдет.";
                    break;
                case 17:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Image = Properties.Resources.frame3;
                    pictureBox2.Visible = true;
                    WMP2.URL = "Resources/second.mp3";
                    label4.Text = "Будущих бойцов повели по коридору. Всюду стояли солдаты, и от этого Рэй стало не по себе.";
                    break;
                case 18:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Image = Properties.Resources.frame4;
                    label4.Text = "Оккола Наиса\n— Пройдите в комнату, чтобы переодеться в специальное оборудывание. Мы будем следить за вашим состоянием. В костюмах установлены датчики, что позволят нам узнать о вашем физическом и психическом состоянии. Всё это ради вашего блага.";
                    break;
                case 19:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Оккола Наиса\n— Первым испытанием будет выдержка. Мы определим по уровню вашего стресса, сколько времени вы можете продержаться под воздействием Теней. Не беспокойтесь, до летального исхода не дойдёт.";
                    break;
                case 20:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Оккола Наиса\n— Специальная группа ликвидации как только обнаружит высокий выплеск энергии, тут же прибудет в комнату и обезвредит Тень, а вас выведут и направят на осмотр. И помните, Организация заботится о Вас.";
                    break;
                case 21:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\nНичего себе «безопасно». А если они не успеют? Мда. Вот это я понимаю з-забота. Остаётся только надеяться, что я не умру.";
                    break;
                case 22:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    video1();
                    label4.Text = "Рэй\n— Что это было?";
                    break;
                case 23:
                    hidech();
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй в ужасе стояла некоторое время, пока её не подтолкнул какой-то паренёк.";
                    break;
                case 24:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = true;
                    label4.Text = "Парень\n— Чего стоишь? Двигай, давай.";
                    hideuiguyansw();
                    break;
                case 25:
                    if (guyansw == 1)
                    {
                        pictureBox2.Visible = true;
                        pictureBox7.Visible = true;
                        label4.Text = "Рэй\n— Я сейчас тебе двину.";
                    }
                    else if (guyansw == 2)
                    {
                        pictureBox7.Visible = false;
                        pictureBox2.Visible = false;
                        label4.Text = "Рэй смиренно продолжила шагать в сторону комнаты.";
                    }
                    break;
                case 26:
                    if (guyansw == 1)
                    {
                        pictureBox2.Visible = false;
                        pictureBox7.Visible = false;
                        label4.Text = "Резко заявила девушка. Парень не выдержал такого отношения к себе, и они уже было замахнулись друг на друга, как позади послышалось:";
                    }
                    else if (guyansw == 2)
                    {
                        pictureBox2.Visible = true;
                        pictureBox7.Visible = false;
                        label4.Text = "Рэй\nЧто же это было?";
                    }
                    break;
                case 27:
                    if (guyansw == 1)
                    {
                        pictureBox2.Visible = false;
                        pictureBox7.Visible = false;
                        label4.Text = "Оккола Наиса\n— До начала испытания две минуты. Опоздавшие будут считаться беглецами и понесут наказание. И помните Организация заботится о Вас.";
                    }
                    else if (guyansw == 2)
                    {
                        pictureBox2.Visible = false;
                        pictureBox7.Visible = false;
                        label4.Text = "Эта мысль ещё долго крутилась в её голове.";
                    }
                    break;
                case 28:
                    if (guyansw == 1)
                    {
                        pictureBox2.Visible = false;
                        pictureBox7.Visible = false;
                        label4.Text = "В этот момент оба охладели, понимая, что если продолжат бессмысленную перепалку, окажутся в печальном положении, и как можно быстрее направились в комнату.";
                    }
                    else if (guyansw == 2)
                    {
                        pictureBox2.Visible = false;
                        pictureBox7.Visible = false;
                        label4.Text = "Оккола Наиса\n— До начала испытания две минуты. Опоздавшие будут считаться беглецами и понесут наказание. И помните Организация заботится о Вас.";
                    }
                    break;
                case 29:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "В комнате, в которую заходили люди, висели костюмы. И все одинаковые. Пространство было предельно на две части. Для мужчин и женщин соответственно.";
                    break;
                case 30:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй схватила первый попавшийся костюм. Быстро стянула с себя верхнюю одежду на глазах у всех и, запрыгивая на ходу в костюм, направилась в следующую комнату.";
                    break;
                case 31:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Image = Properties.Resources.frame4;
                    label4.Text = "\"Ненормальная какая-то.\", сказал кто-то позади Рэй.";
                    break;
                case 32:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Image = Properties.Resources.Pictures3;
                    label4.Text = "В этой комнате было достаточно темно. Но в начале, откуда вышла девушка, было больше всего света. Поэтому Рэй там и осталась.";
                    break;
                case 33:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Image = Properties.Resources.Pictures3;
                    label4.Text = "Остальные же заняли свои места ближе к концу комнаты в более тёмных условиях.";
                    break;
                case 34:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Image = Properties.Resources.Pictures1;
                    label4.Text = "Оккола Наиса\n— Счастливого вам испытания и пусть удача всегда будет на вашей стороне. И помните, Организация заботится о вас.";
                    break;
                case 35:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\n— Где-то я это уже слышала...";
                    break;
                case 36:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй осмотрела лица присутствующих. На одной из девушек лица не было. Другая пыталась её взбодрить. Но видимо безуспешно. У стенки сидели парни и о чем-то разговаривали. Больше всего было жаль того паренька, которого тогда поймали на собрании. Он в ужасе стоял у одной из колонн.";
                    break;
                case 37:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Девушка 1\n— Та брехня это всё!\nДевушка 2\n— Да тише ты.";
                    break;
                case 38:
                    hidech();
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Кто-то что-то бурно обсуждал.";
                    break;
                case 39:
                    hideuilisten();
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\nМожет мне стоит подслушать?";
                    break;
                case 40:
                    pictureBox1.Image = Properties.Resources.Pictures1;
                    WMP2.URL = "Resources/beforevideo2.mp3";
                    WMP2.controls.play();
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    if (listen == 1)
                        label4.Text = "Рэй уже было хотела подползти послушать, но...";
                    else if (listen == 2)
                        label4.Text = "Рэй\n— Зачем мне слушать чьи-то бредни.";
                    break;
                case 41:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    video2();
                    pictureBox1.Image = Properties.Resources.Pictures2;
                    label4.Text = "Паника воцарилась в комнате. Истошные крики резали уши. Кто-то начал плакать.";
                    break;
                case 42:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Напуганный парень\n— Нет! О нет! Только не это! Я еще так молод, чтобы умирать!";
                    break;
                case 43:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Такие выходки лишь забавляли Рэй, ведь ей было совсем не страшно.";
                    break;
                case 44:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Голос неизвестного\n— Чего смеёшься?";
                    break;
                case 45:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Вдруг послышалось из ниоткуда.";
                    break;
                case 46:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\n— Кто здесь?";
                    break;
                case 47:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Голос неизвестного\n— Я?";
                    break;
                case 48:
                    pictureBox2.Visible = true;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй\n— Я, это кто?";
                    break;
                case 49:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Рэй было испугалась, но после этого диалога снова развеселилась.";
                    break;
                case 50:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Голос неизвестного\n— А ты посмотри вверх.";
                    break;
                case 51:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    label4.Text = "Девушка подняла голову и увидела...";
                    break;
                case 52:
                    pictureBox2.Visible = false;
                    pictureBox7.Visible = false;
                    video3();
                    break;
                default: break;
            }

        }

        private void hidech()
        {
            forw = true;
            button2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            forw = true;
            button2.Visible = true;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            army = 2;
            forward(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            forw = true;
            button2.Visible = true; //вывод навигации по диалогам и скрывание вариантов для выбора
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            army = 1;
            forward(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            forw = true;
            button2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            hide = 1;
            forward(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            forw = true;
            button2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            hide = 2;
            forward(sender, e);
        }

        public void chtxtarmy() //функция проверяет какой вариант выбран и выводит диалог на основании выбора
        {
            switch (army)
            {
                case 1:
                    label4.Text = "Парень\nХа, я тоже не особо хочу, но выбирать не приходится. Смотри, речь начинается.";
                    break;
                case 2:
                    label4.Text = "Парень\n— Неужели они и тебе мозги промыли? Куда не пойду, всюду вы! Так и с ума можно сойти!? О чем это я?";
                    break;
                default:
                    label4.Text = "Если вы видите этот текст, сообщите об ошибке разработчику";
                    break;
            }
        }

        public void chtxthide() //функция проверяет какой вариант выбран и выводит диалог на основании выбора
        {
            switch (hide)
            {
                case 1:
                    label4.Text = "Рэй пытается спрятаться до окончания собрания. Но охрана замечает, как она уходит со своего места, быстро направляется к ней. Девушка это замечает и возвращается обратно.";
                    break;
                case 2:
                    label4.Text = "Рэй\nНет, это  глупо, а охраны столько, что заметят любое лишнее движение.";
                    break;
                default:
                    label4.Text = "Если вы видите этот текст, сообщите об ошибке разработчику";
                    break;
            }
        }
        public void chtxtending() //функция проверяет какие варианты были выбраны и выводит диалог концовки на основании выборов
        {
            switch (army)
            {
                case 1:
                    if (hide == 1)
                    {
                        label4.Text = "Концовка 1\n Не хочешь служить и прячешься.";
                    }
                    else if (hide == 2)
                    {
                        label4.Text = "Концовка 2\n Не хочешь служить и не прячешься.";
                    }
                    else label4.Text = "Если вы видите этот текст, сообщите об ошибке разработчику";
                    break;
                case 2:
                    if (hide == 1)
                    {
                        label4.Text = "Концовка 3\n Хочешь служить и прячешься.";
                    }
                    else if (hide == 2)
                    {
                        label4.Text = "Концовка 4\n Хочешь служить и не прячешься.";
                    }
                    else label4.Text = "Если вы видите этот текст, сообщите об ошибке разработчику";
                    break;
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            label7.Visible = true;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            switch (gg)
            {
                case 0:
                    gg = 1;
                    pictureBox2.Image = Properties.Resources.sewse3_1;
                    break;
                case 1:
                    pictureBox2.Image = Properties.Resources.sewse3;
                    gg = 0;
                    break;
                default:
                    break;
            }
        }

        private void EPISODE_1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    backward(sender, e);
                    break;
                case Keys.D:
                case Keys.Space:
                case Keys.Enter:
                case Keys.Right:
                    forward(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
            label4.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            AboutBox1 программа = new AboutBox1();
            программа.Show();
        }

        private void video2()
        {
            WMP2.controls.stop();
            forw = false;
            back = false;
            video = 2;
            pictureBox10.Image = Properties.Resources.video;
            pictureBox10.Visible = true;
            timer2.Interval = 2500;
            timer1.Start();
            timer2.Start();
        }

        private void video1()
        {
            WMP2.controls.stop();
            forw = false;
            back = false;
            video = 1;
            pictureBox10.Image = Properties.Resources.video2;
            pictureBox10.Visible = true;
            timer1.Start();
            timer2.Start();
        }

        private void video3()
        {
            forw = false;
            back = false;
            video = 3;
            pictureBox10.Image = Properties.Resources.ending;
            pictureBox10.Visible = true;
            timer1.Interval = 3500;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            forw = true;
            back = true;
            pictureBox10.Visible = false;
            pictureBox10.Image = Properties.Resources.frame1;
            switch (video)
            {
                case 1:
                    WMP2.URL = "Resources/beforevideo2.mp3";
                    break;
                case 2:
                    WMP2.URL = "Resources/aftervideo2.mp3";
                    break;
                case 3:
                    main(sender, e);
                    break;
            }
                
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            switch (video)
            {
                case 1:
                    WMP.URL = "Resources/video2.mp3";
                    break;
                case 2:
                    WMP.URL = "Resources/video.mp3";
                    break;
            }
            WMP.controls.play();
            timer2.Stop();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            forw = true;
            button2.Visible = true;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            guyansw = 2;
            forward(sender, e);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            forw = true;
            button2.Visible = true;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            guyansw = 1;
            forward(sender, e);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            forw = true;
            button2.Visible = true;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            listen = 2;
            forward(sender, e);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            forw = true;
            button2.Visible = true;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            listen = 1;
            forward(sender, e);
        }

        private void EPISODE_1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WMP.controls.stop();
            WMP2.controls.stop();
        }
    }
}
