using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 스쿼드_도서관
{
    public partial class UserSearchDetails : Form
    {
        public UserSearchDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserMypage mpg = new UserMypage();
            mpg.Show();
        }

        private void User_Search2_Load(object sender, EventArgs e)
        {
            label1.Text = textBox10.Text;


            if (label1.Text == "서울의 맛집")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\서울의 맛집.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "리얼 제주")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\리얼 제주.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "선량한 차별주의자")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\선량한 차별주의자.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "떨림과 울림")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\떨림과 울림.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "나의 문화유산답가기 365일")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\나의 문화유산 답사기.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "장면들")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\장면들.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "7일,168시간")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\7일, 168시간.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "직장인들을 위한 실무 엑셀")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\직장인들을 위한 실무 엑셀.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "디지털이다")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\디지털이다.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "이상한 정상가족")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\이사한 정상가족.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "노예의 길")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\노예의 길.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label1.Text == "전쟁의 기술")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\전쟁의 기술.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\Do it! BERT와 GPT로 배우는 자연어 처리.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
