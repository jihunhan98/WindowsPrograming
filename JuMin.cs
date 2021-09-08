using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH1
{
    class JuMin
    {
        public static string number = "";        //주민번호와 현재 시각은 쓰일 일이 많기 때문에 전역변수로 선언
        public static string this_times = Convert.ToString(DateTime.Now);
        static void Main(string[] args)
        {
            Console.WriteLine("주민번호 13자리를 를 입력하시오 : ");
            number = Console.ReadLine();        //주민번호 13자리 입력
            
            GetInfo info = new GetInfo();   //정보를 찾는 클래스 GetInfo의 객체  생성

            info.setKeyNumber(Convert.ToInt32(JuMin.number.Substring(6, 1)));

            Console.WriteLine("태어난 년도는 : " + info.bornYear());
            Console.WriteLine("태어난 월은 : " + info.bornMonth());
            Console.WriteLine("태어난 일은 : " + info.bornmDay());
            Console.WriteLine("올해 나이는 : " + info.getAge());
            Console.WriteLine("성별은 : " + info.getSex());
        }
    }

    class GetInfo   //주민번호를 통해 각 정보들을 반환하는 클래스 GetInfo
    {
        int keynumber;

        public void setKeyNumber(int x)
        {
            this.keynumber = x;
        }
        public string getSex()  //성별 판별해주는 메소드
        {
            if (keynumber == 1 || keynumber == 3)
                return "남자";
            
            else
                return "여자";
        }
        public int bornYear()   //태어난 년도를 반환하는 메소드
        {
            if (keynumber == 1 || keynumber == 3)
                return 1900 + Convert.ToInt32(JuMin.number.Substring(0, 2));
            
            else
                return 2000 + Convert.ToInt32(JuMin.number.Substring(0, 2));
        }
        public int bornMonth()  //태어난 월을 반환하는 메소드
        {
            return Convert.ToInt32(JuMin.number.Substring(2, 2));
        }
        public int bornmDay()   //태어난 일을 반환하는 메소드    
        {
            return Convert.ToInt32(JuMin.number.Substring(4, 2));
        }
        public int getAge()   //지금 시간 기준으로 나이를 반환하는 메소드
        {
            int this_years = Convert.ToInt32(JuMin.this_times.Substring(0, 4));
            
            return this_years - bornYear();
        }
    }
}
