/*
                                                                                                                                                                                                                                              
                                                                                                                                                                                                                                             
MMMMMMMM               MMMMMMMM               AAA               DDDDDDDDDDDDD      EEEEEEEEEEEEEEEEEEEEEE     BBBBBBBBBBBBBBBBB   YYYYYYY       YYYYYYY     XXXXXXX       XXXXXXXDDDDDDDDDDDDD      PPPPPPPPPPPPPPPPP   XXXXXXX       XXXXXXX
M:::::::M             M:::::::M              A:::A              D::::::::::::DDD   E::::::::::::::::::::E     B::::::::::::::::B  Y:::::Y       Y:::::Y     X:::::X       X:::::XD::::::::::::DDD   P::::::::::::::::P  X:::::X       X:::::X
M::::::::M           M::::::::M             A:::::A             D:::::::::::::::DD E::::::::::::::::::::E     B::::::BBBBBB:::::B Y:::::Y       Y:::::Y     X:::::X       X:::::XD:::::::::::::::DD P::::::PPPPPP:::::P X:::::X       X:::::X
M:::::::::M         M:::::::::M            A:::::::A            DDD:::::DDDDD:::::DEE::::::EEEEEEEEE::::E     BB:::::B     B:::::BY::::::Y     Y::::::Y     X::::::X     X::::::XDDD:::::DDDDD:::::DPP:::::P     P:::::PX::::::X     X::::::X
M::::::::::M       M::::::::::M           A:::::::::A             D:::::D    D:::::D E:::::E       EEEEEE       B::::B     B:::::BYYY:::::Y   Y:::::YYY     XXX:::::X   X:::::XXX  D:::::D    D:::::D P::::P     P:::::PXXX:::::X   X:::::XXX
M:::::::::::M     M:::::::::::M          A:::::A:::::A            D:::::D     D:::::DE:::::E                    B::::B     B:::::B   Y:::::Y Y:::::Y           X:::::X X:::::X     D:::::D     D:::::DP::::P     P:::::P   X:::::X X:::::X   
M:::::::M::::M   M::::M:::::::M         A:::::A A:::::A           D:::::D     D:::::DE::::::EEEEEEEEEE          B::::BBBBBB:::::B     Y:::::Y:::::Y             X:::::X:::::X      D:::::D     D:::::DP::::PPPPPP:::::P     X:::::X:::::X    
M::::::M M::::M M::::M M::::::M        A:::::A   A:::::A          D:::::D     D:::::DE:::::::::::::::E          B:::::::::::::BB       Y:::::::::Y               X:::::::::X       D:::::D     D:::::DP:::::::::::::PP       X:::::::::X     
M::::::M  M::::M::::M  M::::::M       A:::::A     A:::::A         D:::::D     D:::::DE:::::::::::::::E          B::::BBBBBB:::::B       Y:::::::Y                X:::::::::X       D:::::D     D:::::DP::::PPPPPPPPP         X:::::::::X     
M::::::M   M:::::::M   M::::::M      A:::::AAAAAAAAA:::::A        D:::::D     D:::::DE::::::EEEEEEEEEE          B::::B     B:::::B       Y:::::Y                X:::::X:::::X      D:::::D     D:::::DP::::P                X:::::X:::::X    
M::::::M    M:::::M    M::::::M     A:::::::::::::::::::::A       D:::::D     D:::::DE:::::E                    B::::B     B:::::B       Y:::::Y               X:::::X X:::::X     D:::::D     D:::::DP::::P               X:::::X X:::::X   
M::::::M     MMMMM     M::::::M    A:::::AAAAAAAAAAAAA:::::A      D:::::D    D:::::D E:::::E       EEEEEE       B::::B     B:::::B       Y:::::Y            XXX:::::X   X:::::XXX  D:::::D    D:::::D P::::P            XXX:::::X   X:::::XXX
M::::::M               M::::::M   A:::::A             A:::::A   DDD:::::DDDDD:::::DEE::::::EEEEEEEE:::::E     BB:::::BBBBBB::::::B       Y:::::Y            X::::::X     X::::::XDDD:::::DDDDD:::::DPP::::::PP          X::::::X     X::::::X
M::::::M               M::::::M  A:::::A               A:::::A  D:::::::::::::::DD E::::::::::::::::::::E     B:::::::::::::::::B     YYYY:::::YYYY         X:::::X       X:::::XD:::::::::::::::DD P::::::::P          X:::::X       X:::::X
M::::::M               M::::::M A:::::A                 A:::::A D::::::::::::DDD   E::::::::::::::::::::E     B::::::::::::::::B      Y:::::::::::Y         X:::::X       X:::::XD::::::::::::DDD   P::::::::P          X:::::X       X:::::X
MMMMMMMM               MMMMMMMMAAAAAAA                   AAAAAAADDDDDDDDDDDDD      EEEEEEEEEEEEEEEEEEEEEE     BBBBBBBBBBBBBBBBB       YYYYYYYYYYYYY         XXXXXXX       XXXXXXXDDDDDDDDDDDDD      PPPPPPPPPP          XXXXXXX       XXXXXXX
                                                                                                                                                                                                                                             
                                                                                                                                                                                                                                             
                                                                                                                                                                                                                                             
                                                                                                                                                                                                                                             
                                                                                                                                                                                                                                             
                                                                                                                                                                                                                                             
                                                                                                                                                                                                                                             
 
 
 
 */


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

namespace PS3_Save_Data_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Param_SFO.PARAM_SFO> Params = new List<Param_SFO.PARAM_SFO>();

   

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            dataGridView1.Rows.Clear();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                textBox1.Text = folderPath;
                var items = Directory.GetFiles(folderPath, "*.SFO", SearchOption.AllDirectories);
                for (int i = 0; i < items.Length; i++)
                {
                    Param_SFO.PARAM_SFO sfo = new Param_SFO.PARAM_SFO(items[i]);
                    Params.Add(sfo);
                    //GET BLUES
                    string SaveDataDir = "";

                    Bitmap Icon = null;
                    Bitmap Background = null;
                    string PathToItem = Path.GetDirectoryName(items[i]);
                    if(File.Exists(PathToItem + @"\ICON0.PNG"))
                    {
                        Icon =new Bitmap(PathToItem + @"\ICON0.PNG");
                    }
                    if (File.Exists(PathToItem + @"\PIC1.PNG"))
                    {
                        Background = new Bitmap(PathToItem + @"\PIC1.PNG");
                    }

                    dataGridView1.Rows.Add(sfo.GetSpesificValue("SAVEDATA_DIRECTORY").Substring(0, 9), sfo.Title, sfo.GetSpesificValue("ACCOUNT_ID"), Icon, Background, sfo.GetSpesificValue("DETAIL"));
                }
            } 
            
        }
    }


    public static class OverrideMethod
    {
        public static string GetSpesificValue(this Param_SFO.PARAM_SFO psfo, string ValueToFind)
        {
            for (int i = 0; i < psfo.Tables.Count; i++)
            {
                if (psfo.Tables[i].Name == ValueToFind)
                {
                    //get the value 
                    return psfo.Tables[i].Value;
                }
            }
            return null;
        }
    }
}
