using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Automobile
    {
        /*В классе описываются такие атрибуты как, Марка, модель, год выпуска, год прохождения технического осмотра, владелец, и некоторые другие, 
            * которые требуются для реализации методов класса. При создании объекта все эти характеристики передаются пользователем. 
            * Т.е. сделать конструктор с параметрами. 
            Класс содержит методы
            1. Пройти ТехОсмотр(ГОД СЛЕДУЮЩЕГО ТЕХОСМОТРА), в метод передается год следующего техосмотра, если автомобиль прошел техосмотр, и -1 если техосмотр не пройден.
            2. Выписать штраф(Сумма штрафа);
            3. Продать Автомобиль(ФИО НОВОГО Владельца) если -1 то автомобиль списан в утилизацию
            4. Получить данные об автомобиле()
            5. Получить ФИО Владельца()
            Разработать тестовое приложение демонстрирующее работу с классом из DLL.
            */

        private string brand;
        private string model;
        private short yearOFIssue;
        private short yearOfTecnicalInspection;
        private string owner;
        private int debt;

        /// <summary>
        /// марка машины 
        /// </summary>
        public string Brand { get => brand;}
        /// <summary>
        /// модель машины 
        /// </summary>
        public string Model { get => model;}
        /// <summary>
        /// Год Выпуска машины 
        /// </summary>
        public int YearOFIssue1 { get => yearOFIssue; }
        /// <summary>
        /// год технического осмотра yearOfTecnicalInspection > 0
        /// </summary>
        public int YearOfTecnicalInspection { get => yearOfTecnicalInspection; }
        /// <summary>
        /// текущий владелец
        /// </summary>
        public string Owner
        {
            get
            {
                return owner ?? "car in scrapped";
            }
        }
        /// <summary>
        /// сумма долга 
        /// </summary>
        public int Debt { get => debt;}

        Automobile()
        {
            brand = null;
            model = null;
            yearOFIssue = 0;
            yearOfTecnicalInspection = -1;
            owner = null;
            debt = 0;
        }

        public Automobile(string brand, string model, short yearOFIssue, short yearOfTecnicalInspection, string owner)
        {
            this.brand = brand ?? throw new ArgumentNullException(nameof(brand));
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.yearOFIssue = yearOFIssue;
            this.yearOfTecnicalInspection = yearOfTecnicalInspection;
            this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public Automobile(string brand, string model, short yearOFIssue, short yearOfTecnicalInspection, string owner, int debt) : this(brand, model, yearOFIssue, yearOfTecnicalInspection, owner)
        {
             
            this.debt = debt > 0 ? debt : throw new ArgumentException(nameof(debt));
        }

        /// <summary>
        ///Пройти ТехОсмотр(ГОД СЛЕДУЮЩЕГО ТЕХОСМОТРА), в метод передается год следующего техосмотра, если автомобиль прошел техосмотр, и -1 если техосмотр не пройден.
        /// </summary>
        /// <param name="yearOfNewTecnicalInspection"></param>
        public void PassMOT(short yearOfNewTecnicalInspection)
        {
            if (yearOfNewTecnicalInspection == -1)
            {
                yearOfTecnicalInspection = -1;
                return;
            }
            else if(yearOfNewTecnicalInspection < 0)
            {
                throw new ArgumentException("invalid data, year must be positive");
            }
            yearOfTecnicalInspection = yearOfNewTecnicalInspection;
           
        }
        /// <summary>
        /// Продать Автомобиль(ФИО НОВОГО Владельца) если -1 то автомобиль списан в утилизацию
        /// </summary>
        /// <param name="newOwner"></param>
        public void SellCar(string newOwner)
        {
            if(newOwner == "-1")
            {
                owner = null;
                return;
            }
            owner = newOwner;
        }
        /// <summary>
        ///  Выписать штраф(Сумма штрафа)
        /// </summary>
        /// <param name="AmountOfFine"></param>
        /// <returns></returns>
        public int IssueFine(int AmountOfFine)
        {
            if( AmountOfFine <= 0)
            {
                throw new ArgumentException("invalid data, AmountOfFine must be greater than zero");
            }
            debt += AmountOfFine;
            return debt;
        }
    }
}
