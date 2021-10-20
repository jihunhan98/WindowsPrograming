using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   
  

    class MainJumin
    {
        static void Main(string[] args)
        {
            JuminJudge jumin = new JuminJudge();
            Console.WriteLine("주민번호를 입력하세요");
            jumin.setNumber(Console.ReadLine());
            jumin.run();
        }
    }

    class JuminJudge
    {
        private string juminNumb;
        private int whenBorn;
        private int keyNumber;
        private int time_now = Convert.ToInt32((Convert.ToString(DateTime.Now)).Substring(0, 4));

        public void setNumber(string s)
        {
            this.juminNumb = s;
            this.keyNumber = Convert.ToInt32(s.Substring(6, 1));
        }

        private void getBorn()
        {
            if (keyNumber == 1 || keyNumber == 2)
                this.whenBorn = 1900 + Convert.ToInt32(juminNumb.Substring(0, 2));
            else
                this.whenBorn = 2000 + Convert.ToInt32(juminNumb.Substring(0, 2));
            Console.WriteLine("태어난 년도는 " + whenBorn);
        }

        private void getMonth()
        {
            Console.WriteLine("월 : " + juminNumb.Substring(2,2));
        }

        private void getDay()
        {
            Console.WriteLine("일 : " + juminNumb.Substring(4, 2));

        }

        private void getAge()
        {
            Console.WriteLine("나이 : " + (this.time_now-this.whenBorn));
        }

        private void getSex()
        {
            if(keyNumber == 1 || keyNumber == 3)
                Console.WriteLine("성별 = 남자");
            else
                Console.WriteLine("성별 = 여자");

        }
        public void run()
        {
            getBorn();
            getMonth();
            getDay();
            getAge();
            getSex();
        }


    }
   
}
