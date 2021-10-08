using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ASMGD1
{
    class Program
    {
        // cơ sở dữ liệu cần kết nối

        static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.Unicode;

				
				// set lại background color
                ConsoleColor background = Console.BackgroundColor;
                ConsoleColor foreground = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Magenta;
			// gọi ra Hàm menu 
            Menu.menu();
            }
        }
    }